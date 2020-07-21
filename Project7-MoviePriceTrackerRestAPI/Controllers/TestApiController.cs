using MoviePriceTrackerRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoviePriceTrackerRestAPI.Controllers
{
    public class TestApiController : ApiController
    {
        [Route("api/testapi")]
        public IEnumerable<CustomListItem> Get()
        {
            List<CustomListItem> items = new List<CustomListItem>()
            {
                new CustomListItem {Id = 1, Text = "Text1"},
                new CustomListItem {Id = 2, Text = "Text2"}
            };
            return items;
        }

        [Route("api/testapi/getitems")]
        public IEnumerable<CustomListItem> GetItems()
        {
            List<CustomListItem> items = new List<CustomListItem>()
            {
                new CustomListItem {Id = 1, Text = "Text1"},
                new CustomListItem {Id = 2, Text = "Text2"},
                new CustomListItem {Id = 3, Text = "Text3"},
                new CustomListItem {Id = 4, Text = "Text4"},
                new CustomListItem {Id = 5, Text = "Text5"}
            };
            return items;
        }


    }
}
