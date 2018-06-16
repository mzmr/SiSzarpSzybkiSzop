using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Szop.DAL;
using Szop.Models;

namespace Szop.Controllers
{
    public class CategoriesController : ApiController
    {
        /*private StoreContext db = new StoreContext();

        // POST <controller>
        public void Post([FromBody]Category value)
        {
            db.Categories.Add(value);
            db.SaveChanges();
        }

        // GET <controller>
        public IEnumerable<Category> Get()
        {
            return db.Categories;
        }*/
        Category[] categories = new Category[]
       {
            new Category {
                Id = 1,
                Name = "Tomato Soup",
            },
            new Category {
                Id = 2,
                Name = "Yo-yo",
            },
            new Category {
                Id = 3,
                Name = "Hammer",
            }
       };
        // POST <controller>
        public int Post([FromBody]Category value)
        {
            return value.Id;
        }

        // GET <controller>
        public IEnumerable<Category> Get()
        {
            return categories;
        }

    }
}