﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Szop.DBModels
{
    public class DBCart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}