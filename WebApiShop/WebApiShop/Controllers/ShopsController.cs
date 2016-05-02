using System;
using System.Collections.Generic;
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
    public class ShopsController : ApiController
    {
       
        
        Shop[] shops = new Shop[]
       {
            new Shop { Id = 1, Date = DateTime.Now, Value = 4, Descripion = "first shopping", Category = "Book", User_id = 1 },
            new Shop { Id = 2, Date= DateTime.Now, Value = 3.23, Category = "Fun", User_id = 4 },
            new Shop { Id = 3, Date = DateTime.Now, Value = 45, Category = "Eat", User_id = 4 }
       };
        private WebApiShopContext db = new WebApiShopContext();

        // GET: api/Shops
        public IQueryable<Shop> GetShops()
        {
            return db.Shops; 
        }

        // GET: api/Shops/5
        [ResponseType(typeof(Shop))]
        public IHttpActionResult GetShop(int id)
        {
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return NotFound();
            }

            return Ok(shop);
        }

        // PUT: api/Shops/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShop(int id, Shop shop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shop.Id)
            {
                return BadRequest();
            }

            db.Entry(shop).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopExists(id))
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

        // POST: api/Shops
        [ResponseType(typeof(Shop))]
        public IHttpActionResult PostShop(Shop shop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Shops.Add(shop);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = shop.Id }, shop);
        }

        // DELETE: api/Shops/5
        [ResponseType(typeof(Shop))]
        public IHttpActionResult DeleteShop(int id)
        {
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return NotFound();
            }

            db.Shops.Remove(shop);
            db.SaveChanges();

            return Ok(shop);
        }


        public IEnumerable<Shop> getFromDate(int id, Nullable<DateTime> from, Nullable<DateTime> to)
        {
            return db.Shops.Where(a => a.User_id == id).Where(b => b.Date > from ).Where(c=>c.Date <to ).ToList();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShopExists(int id)
        {
            return db.Shops.Count(e => e.Id == id) > 0;
        }
    }
}
