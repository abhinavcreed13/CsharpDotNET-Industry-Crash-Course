using MoviePriceTrackerWebClient.Helpers;
using MoviePriceTrackerWebClient.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviePriceTrackerWebClient.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string searchbox)
        {
            var baseUrl = CustomConfigs.MovieBaseUrl;
            var searchUrl = CustomConfigs.SearchUrl;
            searchUrl = string.Format(baseUrl, searchUrl);

            var client = new RestClient(searchUrl);
            var request = new RestRequest(Method.POST);

            var data = new
            {
                query = searchbox
            };

            request.AddJsonBody(data);
            var viewModel = client.Execute<IEnumerable<MovieDetailsViewModel>>(request);
            var trackedMovies = MovieTrackingController.TrackingMovieIds;
            foreach(var details in viewModel.Data)
            {
                details.IsTracked = trackedMovies.AsEnumerable().Any(val => val == details.Id);
            }
            return View("SearchList", viewModel.Data);
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            var baseUrl = CustomConfigs.MovieBaseUrl;
            var detailsUrl = CustomConfigs.DetailsUrl;

            detailsUrl = string.Format(baseUrl, detailsUrl);
            detailsUrl = string.Format(detailsUrl, id.ToString());

            var client = new RestClient(detailsUrl);

            var viewModel = client.Execute<MovieDetailsViewModel>(new RestRequest());

            return View(viewModel.Data);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
