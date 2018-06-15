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
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Price = 1, Category = "Groceries", Image = "asdfasd", Description = "a nice suop" },
            new Product { Id = 2, Name = "Yo-yo", Price = 3.75M, Category = "Toys", Image = "adgsrvjtchsegc4w5gc", Description = "funny toys" },
            new Product { Id = 3, Name = "Hammer", Price = 16.99M, Category = "Hardware", Image = "", Description = "pricy hardware isn't cheap" }
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
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
    }
}
