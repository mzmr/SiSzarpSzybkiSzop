using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Szop.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}