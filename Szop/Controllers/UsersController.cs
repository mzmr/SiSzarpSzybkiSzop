using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Szop.Authentication;
using Szop.DAL;
using Szop.DBModels;
using Szop.Models;

namespace Szop.Controllers
{
    public class UsersController : ApiController
    {
        private ShopContext db = new ShopContext();

        public IEnumerable<User> Get()
        {
            return db.Users.AsEnumerable().Select(p => Map(p));
        }

        [HttpPost]
        [Route("users/sign-up")]
        public int PostSignUp([FromBody]User user)
        {
            DBUser added = db.Users.Add(InverseMap(user));
            db.SaveChanges();
            return added.Id;
        }

        [HttpPost]
        [Route("users/sign-in")]
        public HttpResponseMessage PostSignIn([FromBody]User user)
        {
            DBUser profile = db.Users.AsEnumerable().Where(u =>
                u.Email.Equals(user.Email) &&
                SecurePasswordHasher.Verify(user.Password, u.PassHash)
            ).First();

            if (profile == null)
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid User", Configuration.Formatters.JsonFormatter);
            else
            {
                AuthenticationModule authentication = new AuthenticationModule();
                string token = authentication.GenerateTokenForUser(profile.Email, profile.Id);
                return Request.CreateResponse(HttpStatusCode.OK, token, Configuration.Formatters.JsonFormatter);
            }
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
                PassHash = SecurePasswordHasher.Hash(user.Password)
            };
        }

        [NonAction]
        internal User Map(DBUser dbUser)
        {
            if (dbUser == null)
                return null;

            return new User()
            {
                Id = dbUser.Id,
                Email = dbUser.Email,
                Password = dbUser.PassHash
            };
        }
    }
}