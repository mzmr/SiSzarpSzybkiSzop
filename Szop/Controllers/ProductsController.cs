using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Szop.DAL;
using Szop.DBModels;
using Szop.Models;

namespace Szop.Controllers
{
    public class ProductsController : ApiController
    {
        private ShopContext db = new ShopContext();


        public IEnumerable<Product> GetAllProducts()
        {
            return db.Products.AsEnumerable().Select(p => Map(p));
        }
        
        public IEnumerable<Product> Get(string q, int c = -1, decimal pmin = -1, decimal pmax = -1)
        {
            IEnumerable<DBProduct> dbList = db.Products.Where(x =>
                x.Name.ToLower().Contains(q.ToLower()) &&
                (c == -1 || x.CategoryId == c) &&
                (pmin == -1 || x.Price >= pmin) &&
                (pmax == -1 || x.Price <= pmax)
            );
            //return dbList.Select(x => new Product() {
            //    Category = x.Ca
            //});
            return null;
        }
        
        public IHttpActionResult GetProduct(int id)
        {
            DBProduct product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(Map(product));
        }

        // POST <controller>
        public int Post([FromBody]DBProduct value)
        {
            db.Products.Add(value);
            db.SaveChanges();

            return value.Id;
        }

        public IHttpActionResult DeleteProduct(int id)
        {
            DBProduct product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        internal Product Map(DBProduct dbProduct)
        {
            if (dbProduct == null)
                return null;

            DBCategory c = db.Categories.Find(dbProduct.CategoryId);
            return new Product()
            {
                Id = dbProduct.Id,
                Name = dbProduct.Name,
                Price = dbProduct.Price,
                Category = new Category { Id = c.Id, Name = c.Name },
                Image = dbProduct.Image,
                Description = dbProduct.Description
            };
        }

        internal DBProduct InverseMap(Product product)
        {
            if (product == null)
                return null;
            return new DBProduct()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.Category.Id,
                Image = product.Image,
                Description = product.Description
            };
        }
    }
}
