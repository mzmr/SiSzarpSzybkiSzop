using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Szop.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string ISBN { get; set; }
        public int PageCount { get; set; }

        public virtual Author Author { get; set; }
    }
}