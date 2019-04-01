using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CarInsuranceAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			// Routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name			: "Brands",
				routeTemplate	: "insurance/cars/brands",
				defaults		: new { controller = "CarBrands" }
			);

			config.Routes.MapHttpRoute(
				name			: "BrandsModels",
				routeTemplate	: "insurance/cars/brands/{brand}",
				defaults		: new { controller = "CarBrands" }
			);

			config.Formatters.JsonFormatter.SupportedMediaTypes
				.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
		}
    }
}
