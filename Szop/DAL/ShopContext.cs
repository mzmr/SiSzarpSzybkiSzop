using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Szop.DBModels;
using Szop.Models;

namespace Szop.DAL
{
    public class ShopContext : DbContext
    {
        public ShopContext() : base("ShopContext") {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<DBProduct> Products { get; set; }
        public DbSet<DBUser> Users { get; set; }
        public DbSet<DBCategory> Categories { get; set; }
        public DbSet<DBCart> Carts { get; set; }
    }
}