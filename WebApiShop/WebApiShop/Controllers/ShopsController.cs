using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiShop.Models;

namespace WebApiShop.Controllers
{
    public class ShopsController : ApiController
    {
        Shop[] shops = new Shop[]
       {
            new Shop { Id = 1, Date =" 02-03-2015", Value = "43", Descripion = "first shopping", Category = "Book", User_id = 1 },
            new Shop { Id = 2, Date = "04-05-2015", Value = "3,23", Category = "Fun", User_id = 4 },
            new Shop { Id = 3, Date = "04-05-2015", Value = "45", Category = "Eat", User_id = 4 }
       };

        public IEnumerable<Shop> GetAllShops()
        {
            return shops;
        }

        public IHttpActionResult GetShop(int id)
        {
            var shop = shops.FirstOrDefault((p) => p.Id == id);
            if (shop == null)
            {
                return NotFound();
            }
            return Ok(shop);
        }

    }
}
