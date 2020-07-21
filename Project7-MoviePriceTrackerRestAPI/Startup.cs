using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MoviePriceTrackerRestAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            // default landing page
            //config.Routes.MapHttpRoute(
            //        name: "Index",
            //        routeTemplate: "{id}.html",
            //        defaults: new { id = "index" }
            //    );

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/id",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            // middleware via OWIN
            app.UseWebApi(config);
        }
    }
}