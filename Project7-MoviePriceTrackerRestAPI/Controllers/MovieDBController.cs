using MoviePriceTrackerRestAPI.Helpers;
using MoviePriceTrackerRestAPI.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoviePriceTrackerRestAPI.Controllers
{
    public class MovieDBController : ApiController
    {
        [Route("api/moviedb")]
        public string Get()
        {
            return "MovieDB API is running";
        }

        [HttpGet]
        [Route("api/moviedb/getmoviedetails/{id}")]
        public MovieDetails GetMovieDetails(int id)
        {
            // HttpClient
            //using(var httpClient = new HttpClient())
            //{
            //  string url = "https://api.themoviedb.org/3/movie/550?api_key=8f75bbc25b1c0ad27a1f06f54bd64c7f";

            //    var responseTask = httpClient.GetStringAsync(new Uri(url));
            //    responseTask.Wait();

            //    return responseTask.Result;
            //}

            //RestSharp
            //string url = "https://api.themoviedb.org/3/movie/550?api_key=8f75bbc25b1c0ad27a1f06f54bd64c7f";
            //var client = new RestClient(url);

            //var response = client.Execute<MovieDetails>(new RestRequest());

            //return response.Data;

            return MovieDbWrapper.GetMovieDetails(id);
        }
    }
}
