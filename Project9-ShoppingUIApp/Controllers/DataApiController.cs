using Project9_ShoppingUIApp.Models;
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
        creedEntities _db;

        public DataApiController() {
            _db = new creedEntities();
        }

        public string Get()
        {
            return "Welcome to Mobile Shop!";
        }

        public List<MobilePhoneData> GetPhoneData()
        {
            return _db.MobilePhoneDatas.ToList();
        }
    }
}
