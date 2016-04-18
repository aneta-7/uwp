using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiShop.Models;

namespace WebApiShop.Controllers
{
    public class CategoriesController : ApiController
    {
        Category[] categories = new Category[]
       {
            new Category { Id = 1, Name = "Eat" },
            new Category { Id = 2, Name = "Clothes" },
            new Category { Id = 3, Name = "AGD" }
       };

        public IEnumerable<Category> GetAllCategories()
        {
            return categories;
        }

        public IHttpActionResult GetCategory(int id)
        {
            var category = categories.FirstOrDefault((p) => p.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

    }
}
