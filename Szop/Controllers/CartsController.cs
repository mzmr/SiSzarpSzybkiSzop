using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
        public int Add([FromBody]DBCart value)
        {
            var authenticationIdentity = Thread.CurrentPrincipal.Identity as JWTAuthenticationIdentity;
            int UserId = authenticationIdentity.UserId;
            DBCart toAdd = new DBCart
            {
                Id = value.Id,
                UserId = UserId,
                ProductId = value.ProductId,
                Quantity = value.Quantity
            };
            DBCart added = db.Carts.Add(toAdd);
            db.SaveChanges();

            return added.Id;
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
        public IHttpActionResult Delete(int id)
        {
            var authenticationIdentity = Thread.CurrentPrincipal.Identity as JWTAuthenticationIdentity;
            int userId = authenticationIdentity.UserId;

            DBCart cart = db.Carts.Where(c =>
                c.UserId == userId &&
                c.ProductId == id
            ).First();

            if (cart == null)
            {
                return NotFound();
            }

            db.Carts.Remove(cart);
            db.SaveChanges();

            return Ok(cart);
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