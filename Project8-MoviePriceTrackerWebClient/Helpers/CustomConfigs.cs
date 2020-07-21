using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MoviePriceTrackerWebClient.Helpers
{
    public static class CustomConfigs
    {
        public static string MovieBaseUrl = null;
        public static string DetailsUrl = null;
        public static string SearchUrl = null;
        public static void Initilize()
        {
            var section = ApiUrls.Get();

            foreach(ApiUrl apiUrl in section.Instances)
            {
                switch(apiUrl.Name)
                {
                    case "movieBaseUrl":
                        MovieBaseUrl = apiUrl.Value;
                        break;

                    case "detailsUrl":
                        DetailsUrl = apiUrl.Value;
                        break;

                    case "searchUrl":
                        SearchUrl = apiUrl.Value;
                        break;
                }
            }
        }
    }

    public class ApiUrls : ConfigurationSection
    {
        public static ApiUrls Get()
        {
            return (ApiUrls)ConfigurationManager.GetSection("ApiUrls");
        }

        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        public ApiUrlCollection Instances
        {
            get { return (ApiUrlCollection)this[""]; }
            set { this[""] = value; }
        }
    }

    public class ApiUrlCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ApiUrl();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ApiUrl)element).Name;
        }
    }

    public class ApiUrl : ConfigurationElement
    {
        [ConfigurationProperty("key", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)this["key"]; }
            set { this["key"] = value; }
        }

        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get { return (string)this["value"]; }
            set { this["value"] = value; }
        }
    }
}