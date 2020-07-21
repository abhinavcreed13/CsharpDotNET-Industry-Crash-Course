using MoviePriceTrackerWebClient.Helpers;
using MoviePriceTrackerWebClient.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviePriceTrackerWebClient.Controllers
{
    public class MovieTrackingController : Controller
    {
        //static data object
        public static List<int> TrackingMovieIds = new List<int>();

        // GET: MovieTracking
        public ActionResult Index()
        {
            List<MovieDetailsViewModel> movieDetails = new List<MovieDetailsViewModel>();
            
            foreach (int movieId in TrackingMovieIds)
            {
                var baseUrl = CustomConfigs.MovieBaseUrl;
                var detailsUrl = CustomConfigs.DetailsUrl;

                detailsUrl = string.Format(baseUrl, detailsUrl);

                detailsUrl = string.Format(detailsUrl, movieId.ToString());

                var client = new RestClient(detailsUrl);

                var viewModel = client.Execute<MovieDetailsViewModel>(new RestRequest());

                movieDetails.Add(viewModel.Data);
            }
            return View(movieDetails);
        }

        // GET: MovieTracking/Remove/5
        public ActionResult Remove(int id)
        {
            TrackingMovieIds.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
