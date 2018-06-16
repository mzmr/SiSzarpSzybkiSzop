using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Szop.Models;

namespace Szop.Controllers
{
    public class CartsController : ApiController
    {
        Cart[] carts = new Cart[]
        {
           new Cart {
            UserId = new User {Id = 1, Email = "aaa", PassHash = "sss" },
            ProductId = new Product {
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
    }
}