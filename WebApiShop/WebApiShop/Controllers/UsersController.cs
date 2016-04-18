using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiShop.Models;

namespace WebApiShop.Controllers
{
    public class UsersController : ApiController
    {
        User[] users = new User[]
       {
            new User { Login = "aneta", Password="123" },
            new User { Login = "abcd", Password = "1234" },
            new User { Login = "rewrwe", Password = "324" }
       };

        public IEnumerable<User> GetAllUsers()
        {
            return users;
        }

        public IHttpActionResult GetUser(int id)
        {
            var user = users.FirstOrDefault((p) => p.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
