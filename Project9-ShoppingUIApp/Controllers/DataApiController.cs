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

        public static List<MobilePhoneDataViewModel> cartItems = new List<MobilePhoneDataViewModel>();

        public DataApiController() {
            _db = new creedEntities();
        }

        public string Get()
        {
            return "Welcome to Mobile Shop!";
        }

        public List<MobilePhoneDataViewModel> GetPhoneData()
        {
            var data = _db.MobilePhoneDatas.ToList();
            var dataToSend = data.Select(row => new MobilePhoneDataViewModel
            {
                DeviceName = row.DeviceName,
                DeviceNumber = row.DeviceNumber,
                Brand = row.Brand,
                Price = row.Price,
                Status = row.Status,
                Type = row.Type,
                IsAddedInCart = cartItems.Any(item => item.DeviceNumber == row.DeviceNumber)
            }).ToList();
            return dataToSend;
        }

        public List<MobilePhoneDataViewModel> GetCartItems()
        {
            return cartItems;
        }
        
        [HttpPost]
        public object AddToCart(MobilePhoneDataViewModel phoneObject)
        {
            try
            {
                if (!cartItems.Any(item => item.DeviceNumber == phoneObject.DeviceNumber))
                {
                    cartItems.Add(phoneObject);
                    return new
                    {
                        added = true
                    };
                }
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public object RemoveFromCart(MobilePhoneDataViewModel phoneObject)
        {
            try
            {
                if (cartItems.Any(item => item.DeviceNumber == phoneObject.DeviceNumber))
                {
                    cartItems.RemoveAll(item => item.DeviceNumber == phoneObject.DeviceNumber);
                    return new
                    {
                        removed = true
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
