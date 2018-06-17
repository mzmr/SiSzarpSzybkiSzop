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
            IEnumerable<DBProduct> dbList = db.Products;
            List<Product> list = new List<Product>();
            foreach (DBProduct prod in dbList){
                list.Add(Map(prod));
            }
            return list;
        }
        
        public IEnumerable<Product> Get(string q, int c = -1, string pmin = null, string pmax = null)
        {

            IEnumerable<DBProduct> dbList = db.Products.Where(x =>
                x.Name.ToLower().Contains(q.ToLower())// &&
                //(c == null || x.CategoryId)
            );
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
        public int Post([FromBody]Product value)
        {
            db.Products.Add(InverseMap(value));
            db.SaveChanges();

            return value.Id;
        }

        internal Product Map(DBProduct dbProduct)
        {
            DBCategory c = db.Categories.Find(dbProduct.CategoryId);
            if (dbProduct == null)
                return null;
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
