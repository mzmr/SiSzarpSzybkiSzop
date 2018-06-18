using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using Szop.Authentication;
using Szop.DAL;
using Szop.DBModels;

namespace Szop.Controllers
{
    [JWTAuthenticationFilter]
    public class BuyController : ApiController
    {
        private ShopContext db = new ShopContext();

        public HttpResponseMessage BuyProducts()
        {
            var authenticationIdentity = Thread.CurrentPrincipal.Identity as JWTAuthenticationIdentity;
            int userId = authenticationIdentity.UserId;

            IEnumerable<DBCart> crds = db.Carts.Where(c =>
                c.UserId == userId
            );

            if (crds.Count() == 0)
                return Request.CreateResponse(HttpStatusCode.OK);

            crds.ToList().ForEach(p => db.Carts.Remove(p));
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}