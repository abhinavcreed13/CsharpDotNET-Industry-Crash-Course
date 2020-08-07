using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project9_ShoppingUIApp.Models
{
    public class MobilePhoneDataViewModel
    {
        public int DeviceNumber { get; set; }
        public string DeviceName { get; set; }
        public string Brand { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Price { get; set; }

        public bool IsAddedInCart { get; set; }
    }
}