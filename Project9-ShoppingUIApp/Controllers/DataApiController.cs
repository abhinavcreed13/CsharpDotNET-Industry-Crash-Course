using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project9_ShoppingUIApp.Controllers
{
    public class DataApiController : ApiController
    {
        public string Get()
        {
            return "Welcome to Mobile Shop!";
        }
    }
}
