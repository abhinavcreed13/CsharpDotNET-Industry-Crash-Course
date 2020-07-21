using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviePriceTrackerWebClient.Models
{
    public class MovieDetailsViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "overview")]
        public string Overview { get; set; }

        [JsonProperty(PropertyName = "poster_path")]
        [Display(Name = "Poster")]
        public string PosterPath { get; set; }

        public int Price { get; set; }

        public bool IsTracked { get; set; }
    }
}