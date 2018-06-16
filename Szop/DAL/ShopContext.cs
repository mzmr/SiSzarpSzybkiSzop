using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Szop.DAL
{
    public class ShopContext : DbContext
    {
        public ShopContext() : base("ShopContext") {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        //public DbSet<>
    }
}