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
			// Serviços e configuração da API da Web

			// Routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "Brands",
				routeTemplate: "api/insurance/cars/brands",
				//defaults: new { id = RouteParameter.Optional }
				defaults: new { controller = "CarBrands" }
			);

			config.Routes.MapHttpRoute(
				name: "BrandsModels",
				routeTemplate: "api/insurance/cars/brands/{brand}",
				//defaults: new { id = RouteParameter.Optional }
				defaults: new { controller = "CarBrands" }
			);

			config.Formatters.JsonFormatter.SupportedMediaTypes
				.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
		}
    }
}
