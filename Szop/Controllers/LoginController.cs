using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Szop.Models;

namespace Szop.Controllers
{
    public class LoginController : ApiController
    {
        public int Post([FromBody]User value)
        {
            return value.Id;
        }
    }
}