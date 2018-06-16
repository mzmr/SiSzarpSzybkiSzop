using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Szop.Models;

namespace Szop.DAL
{
    public class ShopInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "gry planszowe" },
                new Category { Id = 2, Name = "gry komputerowe" },
                new Category { Id = 3, Name = "pluszaki" },
                new Category { Id = 4, Name = "książeczki" },
                new Category { Id = 5, Name = "wózki" },
                new Category { Id = 6, Name = "edukacyjne" },
                new Category { Id = 7, Name = "klocki" },
                new Category { Id = 8, Name = "pojazdy" }
            };

            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            var products = new List<Product>
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
        }
    }
}