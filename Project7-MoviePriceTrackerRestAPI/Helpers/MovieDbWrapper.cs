using MoviePriceTrackerRestAPI.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviePriceTrackerRestAPI.Helpers
{
    public static class MovieDbWrapper
    {
        public static MovieDetails GetMovieDetails(int movieId)
        {
            string detailsURL = URLbuilder.GetMovieDetailsUrl(movieId);

            var client = new RestClient(detailsURL);

            var response = client.Execute<MovieDetails>(new RestRequest());

            var data = response.Data;

            data.PosterPath = URLbuilder.GetFullPosterPath(data.PosterPath);

            return data;
        }

        public static List<MovieDetails> SearchMovie(string movieKeyword)
        {
            string searchUrl = URLbuilder.GetSearchMovieUrl(movieKeyword);

            var client = new RestClient(searchUrl);

            var response = client.Execute<MovieSearch>(new RestRequest());

            var data = response.Data;

            foreach (MovieDetails movieDetails in data.Results)
            {
                movieDetails.PosterPath = URLbuilder.GetFullPosterPath(movieDetails.PosterPath);
            }

            return data.Results;
        }

    }
}