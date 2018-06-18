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
    public class CategoriesController : ApiController
    {
        private ShopContext db = new ShopContext();

        // POST <controller>
        public int Post([FromBody]Category value)
        {
            DBCategory added = db.Categories.Add(InverseMap(value));
            db.SaveChanges();

            return added.Id;
        }

        // DELETE: api/Category/5
        public IHttpActionResult DeleteCategory(int id)
        {
            DBCategory category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categories.Remove(category);
            db.SaveChanges();

            return Ok(category);
        }

        // GET <controller>
        public IEnumerable<Category> Get()
        {
            return db.Categories.AsEnumerable().Select(c => Map(c));
        }

        internal Category Map(DBCategory dbCategory)
        {
            if (dbCategory == null)
                return null;
            return new Category()
            {
                Id = dbCategory.Id,
                Name = dbCategory.Name,
            };
        }

        internal DBCategory InverseMap(Category category)
        {
            if (category == null)
                return null;
            return new DBCategory()
            {
                Id = category.Id,
                Name = category.Name,
            };
        }
    }
}