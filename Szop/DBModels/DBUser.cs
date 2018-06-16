using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Szop.DBModels
{
    public class DBUser
    {
        public int Id { get; set; }
        public String Email { get; set; }
        public String PassHash { get; set; }
    }
}