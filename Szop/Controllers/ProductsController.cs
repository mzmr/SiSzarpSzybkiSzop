using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Szop.Models;

namespace Szop.Controllers
{
    public class ProductsController : ApiController
    {
        /*  private StoreContext db = new StoreContext();

          // GET <controller>
          public IEnumerable<Product> Get()
          {
              return db.Products;
          }

          // GET: api/Books/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

          // POST <controller>
          public void Post([FromBody]Product value)
          {
               db.Books.Add(book);
               db.SaveChanges();
          }
      }*/
        Product[] products = new Product[]
        {
            new Product {
                Id = 1,
                Name = "Tomato Soup",
                Price = 1,
                Category = new Category { Id = 1, Name = "Groceries" },
                Image = "asdfasd",
                Description = "a nice suop"
            },
            new Product {
                Id = 2,
                Name = "Yo-yo",
                Price = 3.75M,
                Category = new Category { Id = 2, Name = "Toys" },
                Image = "adgsrvjtchsegc4w5gc",
                Description = "funny toys"
            },
            new Product {
                Id = 3,
                Name = "Hammer",
                Price = 16.99M,
                Category = new Category { Id = 3, Name = "Hardware" },
                Image = "",
                Description = "pricy hardware isn't cheap"
            }
        };

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        [HttpGet]
        public string Get(string q, string c = null, string pmin = null, string pmax = null)
        {
            return $"{q}\n{c}\n{pmin}\n{pmax}";
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST <controller>
        public int Post([FromBody]Product value)
        {
            return value.Id;
        }
    }
}
