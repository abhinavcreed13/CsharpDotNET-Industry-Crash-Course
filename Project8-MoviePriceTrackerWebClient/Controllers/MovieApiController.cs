using MoviePriceTrackerWebClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services.Description;

namespace MoviePriceTrackerWebClient.Controllers
{
    public class MovieApiController : ApiController
    { 

        public string Get()
        {
            return "MovieApi";
        }

        [HttpPost]
        [Route("api/movieapi/trackmovie")]
        public object TrackMovie(MovieParameters parameters)
        {
            MovieTrackingController.TrackingMovieIds.Add(parameters.MovieId);
            return new
            {
                message = "Tracking movie: " + parameters.MovieId.ToString()
            };
        }

        [HttpPost]
        [Route("api/movieapi/untrackmovie")]
        public object UnTrackMovie(MovieParameters parameters)
        {
            MovieTrackingController.TrackingMovieIds.Remove(parameters.MovieId);
            return new
            {
                message = "UnTracking movie: " + parameters.MovieId.ToString()
            };
        }
    }
}
