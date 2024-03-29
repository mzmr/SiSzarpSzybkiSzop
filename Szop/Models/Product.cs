﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Szop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}