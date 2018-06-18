using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Szop.Models
{
    public class Cart
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}