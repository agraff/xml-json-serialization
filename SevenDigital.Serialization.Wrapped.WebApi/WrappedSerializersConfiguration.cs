using System.Net.Http.Formatting;
using System.Web.Http;
using SevenDigital.Serialization.Wrapped.WebApi.Formatters;

namespace SevenDigital.Serialization.Wrapped.WebApi
{
	public class WrappedSerializersConfiguration
	{
		private readonly HttpConfiguration _configuration;

		public WrappedSerializersConfiguration(HttpConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void Setup()
		{
			SetupXmlSerialiser();
			SetupJsonSerialiser();
			SetupContentNegotiator();
		}

		private void SetupContentNegotiator()
		{
			// This will cause a 406 to be returned (rather than using any serialiser), when no serialiser found that matches the response's Accept type.
			_configuration.Services.Replace(typeof(IContentNegotiator), new DefaultContentNegotiator(true));
		}

		private void SetupXmlSerialiser()
		{
			var standardXmlFormatter = _configuration.Formatters.XmlFormatter;
			_configuration.Formatters.Remove(standardXmlFormatter);

			var customXmlFormatter = new WrappedXmlFormatter();
			_configuration.Formatters.Add(customXmlFormatter);
		}

		private void SetupJsonSerialiser()
		{
			var standardJsonFormatter = _configuration.Formatters.JsonFormatter;
			_configuration.Formatters.Remove(standardJsonFormatter);

			var customJsonFormatter = new WrappedJsonFormatter();
			_configuration.Formatters.Add(customJsonFormatter);
		}
	}
}
