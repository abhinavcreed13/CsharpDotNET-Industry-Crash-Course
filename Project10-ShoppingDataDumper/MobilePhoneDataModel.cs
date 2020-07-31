using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Project10_ShoppingDataDumper
{
    public class MobilePhoneDataModel
    {
        [Key]
        public int DeviceNumber { get; set; }
            
        [JsonPropertyName("DeviceName")]
        public string DeviceName { get; set; }

        [JsonPropertyName("Brand")]
        public string Brand { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("price")]
        public string Price { get; set; }
    }
}
