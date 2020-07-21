using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MoviePriceTrackerRestAPI.Helpers
{
    public static class URLbuilder
    {
        public static string baseURL = ConfigurationManager.AppSettings["movieDBApiBaseUrl"].ToString();
        public static string apiKey = ConfigurationManager.AppSettings["movieDBApiKey"].ToString();

        public static string GetConfigValue(string configKey)
        {
            return ConfigurationManager.AppSettings[configKey].ToString();
        }

        public static string GetApiKey()
        {
            return "";
        }

        public static string GetMovieDetailsUrl(int id)
        {
            var detailsURL = GetConfigValue("movieDetailsWithId");
            detailsURL = string.Format(detailsURL, id.ToString());
            detailsURL = string.Format(baseURL, detailsURL, GetApiKey());
            return detailsURL;
        }

        public static string GetFullPosterPath(string url)
        {
            var baseUrl = GetConfigValue("movieDBposterPathBaseUrl");
            return string.Format(baseUrl, url);
        }

        public static string GetSearchMovieUrl(string keyword)
        {
            var searchMovieUrl = GetConfigValue("searchMovie");
            searchMovieUrl = string.Format(baseURL, searchMovieUrl, GetApiKey());
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("query", keyword);
            searchMovieUrl += "&"+queryString.ToString();
            return searchMovieUrl;
        }
    }
}