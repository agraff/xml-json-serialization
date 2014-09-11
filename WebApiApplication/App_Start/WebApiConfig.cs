using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace WebApiApplication
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
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
			
			var customXmlFormatter = new CustomXmlFormatter();
			GlobalConfiguration.Configuration.Formatters.Add(customXmlFormatter);
		}

		private static void SetupJsonSerialiser()
		{
			var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;

			json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
		}
	}
}
