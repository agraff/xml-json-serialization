using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json.Serialization;
using WebApiApplication.App_Start;

namespace WebApiApplication
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.Routes.MapHttpRoute(
				name: "SingleTrack",
				routeTemplate: "api/SingleTrack/{id}",
				defaults: new { controller = "SingleTrack", id = RouteParameter.Optional }
			);

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			SetupXmlSerialiser();
			SetupJsonSerialiser();
			SetupContentNegotiator();
		}

		private static void SetupContentNegotiator()
		{
			// This will cause a 406 to be returned (rather than using any serialiser), when no serialiser found that matches the response's Accept type.
			GlobalConfiguration.Configuration.Services.Replace(typeof (IContentNegotiator), new DefaultContentNegotiator(true));
		}

		private static void SetupXmlSerialiser()
		{
			var standardXmlFormatter = GlobalConfiguration.Configuration.Formatters.XmlFormatter;
			GlobalConfiguration.Configuration.Formatters.Remove(standardXmlFormatter);
			
			var customXmlFormatter = new WrappedXmlFormatter();
			GlobalConfiguration.Configuration.Formatters.Add(customXmlFormatter);
		}

		private static void SetupJsonSerialiser()
		{
			var standardJsonFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
			GlobalConfiguration.Configuration.Formatters.Remove(standardJsonFormatter);

			var customJsonFormatter = new WrappedJsonFormatter();
			GlobalConfiguration.Configuration.Formatters.Add(customJsonFormatter);
		}
	}
}
