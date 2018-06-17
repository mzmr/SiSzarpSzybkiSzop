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
    public class CartsController : ApiController
    {
        private ShopContext db = new ShopContext();
        Cart[] carts = new Cart[]
        {
           new Cart {
            User = new User {Id = 1, Email = "aaa", PassHash = "sss" },
            Product = new Product {
                Id = 2,
                Name = "Yo-yo",
                Price = 3.75M,
                Category = new Category { Id = 2, Name = "Toys" },
                Image = "adgsrvjtchsegc4w5gc",
                Description = "funny toys"
                }
            }
        };
        //get add delete buy
        // POST <controller>
        public int Add(int Id)
        {
            return Id;
        }

        // GET <controller>
        public IEnumerable<Cart> Get()
        {
            return carts;
        }

        public int delete(int id)
        {
            return 1;
        }

        internal Cart Map(DBCart dbCart)
        {
            DBProduct prod = db.Products.Find(dbCart.ProductId);
            DBUser user = db.Users.Find(dbCart.UserId);
            DBCategory c = db.Categories.Find(prod.CategoryId);
            if (dbCart == null)
                return null;
            return new Cart()
            {
                Id = dbCart.Id,
                User = new User {Id = user.Id, Email = user.Email, PassHash = user.PassHash },
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

        internal DBCart InverseMap(Cart cart)
        {
            return new DBCart()
            {
                Id = cart.Id,
                UserId = cart.User.Id,
                ProductId = cart.Product.Id,
                Quantity = cart.Quantity
            };
        }
    }
}