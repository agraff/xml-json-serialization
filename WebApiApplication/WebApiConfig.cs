using System.Web.Http;
using SevenDigital.Serialization.Wrapped.WebApi;

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

			new WrappedSerializersConfiguration(GlobalConfiguration.Configuration).Setup();
		}
	}
}
