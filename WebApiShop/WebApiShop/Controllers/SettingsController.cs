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