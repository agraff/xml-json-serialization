using Nancy.Bootstrapper;
using Nancy.Responses.Negotiation;
using Nancy.Serialization.JsonNet;
using Nancy.TinyIoc;
using Newtonsoft.Json;

namespace NancyExample
{
	using Nancy;

	public class Bootstrapper : DefaultNancyBootstrapper
	{
		protected override NancyInternalConfiguration InternalConfiguration
		{
			get { return new NancyInternalConfigurationFactory().Build(); }
		}

		protected override void ConfigureApplicationContainer(TinyIoCContainer container)
		{
			base.ConfigureApplicationContainer(container);
			container.Register(typeof(JsonSerializer), typeof(ExampleJsonSerializer));
		}
	}

	public class NancyInternalConfigurationFactory
	{
		public NancyInternalConfiguration Build()
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
	}
}