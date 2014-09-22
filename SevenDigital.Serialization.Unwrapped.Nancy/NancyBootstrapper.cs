using Nancy.Bootstrapper;
using Nancy.Responses.Negotiation;
using Nancy.Serialization.JsonNet;
using Nancy.TinyIoc;
using NancyExample.Serializers;
using Newtonsoft.Json;

namespace SevenDigital.Serialization.Unwrapped.Nancy
{
	public static class NancyBootstrapper
	{
		public static NancyInternalConfiguration GetInternalConfiguration()
		{
			return NancyInternalConfiguration.WithOverrides(c =>
			{
				// This is optional because of Nancy's serializers autodiscovery and priority
				c.Serializers.Clear();
				c.Serializers.Add(typeof(ExampleXmlSerializer));
				c.Serializers.Add(typeof(JsonNetSerializer));

				c.ResponseProcessors.Clear();
				c.ResponseProcessors.Add(typeof(XmlProcessor));
				c.ResponseProcessors.Add(typeof(ExampleJsonProcessor));
			});
		}

		public static void ConfigureApplicationContainer(TinyIoCContainer container)
		{
			container.Register(typeof(JsonSerializer), typeof(ExampleJsonSerializer));
		}
	}
}
