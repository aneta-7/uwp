using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiShop.Models;

namespace WebApiShop.Controllers
{
    public class SettingsController : ApiController
    {
        private WebApiShopContext db = new WebApiShopContext();


        // GET: api/Settings
        public IQueryable<Settings> GetSettings()
        {
            return db.Settings;
        }

        // GET: api/Settings/5
        [ResponseType(typeof(Settings))]
        public IHttpActionResult GetSettings(int id)
        {
            Settings settings = db.Settings.Find(id);
            if (settings == null)
            {
                return NotFound();
            }

            return Ok(settings);
        }

        // PUT: api/Settings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSettings(int id, Settings settings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != settings.Id)
            {
                return BadRequest();
            }

            db.Entry(settings).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SettingsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Settings
        [ResponseType(typeof(Settings))]
        public IHttpActionResult PostSettings(Settings settings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Settings.Add(settings);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = settings.Id }, settings);
        }

        // DELETE: api/Settings/5
        [ResponseType(typeof(Settings))]
        public IHttpActionResult DeleteSettings(int id)
        {
            Settings settings = db.Settings.Find(id);
            if (settings == null)
            {
                return NotFound();
            }

            db.Settings.Remove(settings);
            db.SaveChanges();

            return Ok(settings);
        }

        [ResponseType(typeof(Settings))]
        [Route("api/settings/CalulateToLiveTile/{id}")]
        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult CalulateToLiveTile(int id)
        {
            string calculate = null ;
            var exists = db.Settings.Where(a => a.Id==id).Select(b=>b.Id);
            if (exists != null)
            {
                var startValue = db.Settings.Where(a => a.User_id == id).OrderByDescending(c => c.From).Select(b => b.Limit).FirstOrDefault();
                var startDate = db.Settings.Where(a => a.User_id == id).OrderByDescending(c => c.From).Select(b => b.From).FirstOrDefault();

                var spend = db.Shops.Where(a => a.User_id == id).Where(b => b.Date >= startDate).Sum(c => (double?)c.Value) ?? 0;

                calculate = String.Format("{0:0.00}", startValue - spend);
            }

            else {
                calculate = "0";
            }

            return Ok(calculate);
        }


        [ResponseType(typeof(Settings))]
        [Route("api/settings/Spend/{id}")]
        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult Spend(int id)
        {
            var spend = 0;
            var exists = db.Settings.Where(a => a.Id == id).Select(b => b.Id);
            if (exists != null)
            {
                var startValue = db.Settings.Where(a => a.User_id == id).OrderByDescending(c => c.From).Select(b => b.Limit).FirstOrDefault();
                var startDate = db.Settings.Where(a => a.User_id == id).OrderByDescending(c => c.From).Select(b => b.From).FirstOrDefault();

                var spend2 = db.Shops.Where(a => a.User_id == id).Where(b => b.Date >= startDate).Sum(c =>(double?) c.Value) ?? 0;

                return Ok(spend2);
            }
            else {
                spend = 0;
                return Ok(spend);
            }

        }


        [ResponseType(typeof(Settings))]
        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult LastLimit(int id)
        {

            var lastLimit = 0;
            var exists = db.Settings.Where(a => a.Id == id).Select(b => b.Id);
            if (exists != null)
            {
                var lastLimit2 = db.Settings.Where(a => a.User_id == id).OrderByDescending(c => c.From).Select(b => b.Limit).FirstOrDefault();
                return Ok(lastLimit2);
            }
            else {
                lastLimit = 0;
                return Ok(lastLimit);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SettingsExists(int id)
        {
            return db.Settings.Count(e => e.Id == id) > 0;
        }
    }
}