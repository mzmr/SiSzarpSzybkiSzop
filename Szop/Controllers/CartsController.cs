using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using Szop.Authentication;
using Szop.DAL;
using Szop.DBModels;
using Szop.Models;

namespace Szop.Controllers
{
    [JWTAuthenticationFilter]
    public class CartsController : ApiController
    {
        private ShopContext db = new ShopContext();

        //get add delete buy
        // POST <controller>
        public HttpResponseMessage Add([FromBody]DBCart value)
        {
            var authenticationIdentity = Thread.CurrentPrincipal.Identity as JWTAuthenticationIdentity;
            int userId = authenticationIdentity.UserId;

            if (db.Carts.Any(c => c.UserId == userId && c.ProductId == value.ProductId))
                return Request.CreateResponse(HttpStatusCode.Forbidden, $"Product with id {value.ProductId} is already in the cart.", Configuration.Formatters.JsonFormatter);

            DBCart toAdd = new DBCart
            {
                Id = value.Id,
                UserId = userId,
                ProductId = value.ProductId,
                Quantity = value.Quantity
            };
            db.Carts.Add(toAdd);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // GET <controller>
        public IEnumerable<Cart> Get()
        {
            var authenticationIdentity = Thread.CurrentPrincipal.Identity as JWTAuthenticationIdentity;
            int userId = authenticationIdentity.UserId;
            return db.Carts.AsEnumerable().Where(x => x.UserId == userId).Select(p => Map(p));
        }


        // DELETE carts/{productId}
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var authenticationIdentity = Thread.CurrentPrincipal.Identity as JWTAuthenticationIdentity;
            int userId = authenticationIdentity.UserId;

            IEnumerable<DBCart> crds = db.Carts.Where(c =>
                c.UserId == userId &&
                c.ProductId == id
            );

            if (crds.Count() == 0)
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Product with id {id} doesn't exist.", Configuration.Formatters.JsonFormatter);

            DBCart cart = crds.First();

            if (cart == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Product with id {id} doesn't exist.", Configuration.Formatters.JsonFormatter);

            db.Carts.Remove(cart);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, cart, Configuration.Formatters.JsonFormatter);
        }

        [HttpPatch]
        public HttpResponseMessage Patch([FromBody]DBCart value)
        {
            var authenticationIdentity = Thread.CurrentPrincipal.Identity as JWTAuthenticationIdentity;
            int userId = authenticationIdentity.UserId;

            IEnumerable<DBCart> crds = db.Carts.Where(c =>
                c.UserId == userId &&
                c.ProductId == value.ProductId
            );

            if (crds.Count() == 0)
                return Request.CreateResponse(HttpStatusCode.Forbidden, $"Product with id {value.ProductId} is not in the cart.", Configuration.Formatters.JsonFormatter);

            DBCart cart = crds.First();
            cart.Quantity = value.Quantity;
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        internal Cart Map(DBCart dbCart)
        {
            DBProduct prod = db.Products.Find(dbCart.ProductId);

            if (prod == null)
                return null;
            
            DBCategory c = db.Categories.Find(prod.CategoryId);

            if (dbCart == null)
                return null;

            return new Cart()
            {
                Product = new Product
                {
                    Id = prod.Id,
                    Name = prod.Name,
                    Price = prod.Price,
                    Category = new Category { Id = c.Id, Name = c.Name },
                    Image = prod.Image,
                    Description = prod.Description
                },
                Quantity = dbCart.Quantity
            };
        }

    }
}
