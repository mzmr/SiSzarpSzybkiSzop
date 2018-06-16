using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Szop.Models
{
    public class Cart
    {
        public User UserId { get; set; }
        public Product ProductId { get; set; }
    }
}