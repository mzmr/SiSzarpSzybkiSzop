using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Szop.DAL;
using Szop.DBModels;
using Szop.Models;

namespace Szop.Controllers
{
    public class UsersController : ApiController
    {
        private ShopContext db = new ShopContext();

        [HttpPost]
        [Route("users/sign-up")]
        public int PostSignUp([FromBody]User user)
        {
            DBUser added = db.Users.Add(InverseMap(user));
            return user.Id;
        }

        [HttpPost]
        [Route("users/sign-in")]
        public int PostSignIn([FromBody]User user)
        {
            return 555;
        }

        [NonAction]
        internal DBUser InverseMap(User user)
        {
            if (user == null)
                return null;
            return new DBUser()
            {
                Id = user.Id,
                Email = user.Email,
                PassHash = user.PassHash
            };
        }
    }
}