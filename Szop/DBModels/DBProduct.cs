﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Szop.DBModels
{
    public class DBProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}