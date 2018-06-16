using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Szop.DBModels;
using Szop.Models;

namespace Szop.DAL
{
    public class ShopInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
            var categories = new List<DBCategory>
            {
                new DBCategory { Id = 1, Name = "gry planszowe" },
                new DBCategory { Id = 2, Name = "gry komputerowe" },
                new DBCategory { Id = 3, Name = "pluszaki" },
                new DBCategory { Id = 4, Name = "książeczki" },
                new DBCategory { Id = 5, Name = "wózki" },
                new DBCategory { Id = 6, Name = "edukacyjne" },
                new DBCategory { Id = 7, Name = "klocki" },
                new DBCategory { Id = 8, Name = "pojazdy" }
            };

            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            var products = new List<DBProduct>
            {
                new DBProduct {
                    Id = 1,
                    Name = "Dixit",
                    Price = 130,
                    CategoryId = 1,
                    Image = "https://image.ceneostatic.pl/data/products/10813131/i-dixit.jpg",
                    Description = "Gra planszowa z obrazkami"
                },
                new DBProduct {
                    Id = 2,
                    Name = "Mały Miś",
                    Price = 25,
                    CategoryId =3,
                    Image = "https://i5.walmartimages.com/asr/7617e51c-6004-42c1-ae63-006728db4ced_1.e3d0bbf4faa40c0a21af34e4f1d02546.jpeg?odnHeight=450&odnWidth=450&odnBg=FFFFFF",
                    Description = "Mały, słodki, pluszowy miś"
                },
                new DBProduct {
                    Id = 3,
                    Name = "Klocki",
                    Price = 16.99M,
                    CategoryId = 7,
                    Image = "https://maciejgnyszka.pl/wp-content/uploads/lego-1080x675.jpg",
                    Description = "Duże klocki dla małych dzieci"
                }
            };

            products.ForEach(c => context.Products.Add(c));
            context.SaveChanges();

            var users = new List<DBUser>
            {
                new DBUser { Id = 1, Email = "kasia@gmail.com", PassHash = "kuywtvkcwu4twkcejt5ki7ec54bgikcu5hcliugc" },
            };

            users.ForEach(c => context.Users.Add(c));
            context.SaveChanges();
        }
    }
}