﻿using Nancy.Bootstrapper;
using Nancy.Responses;
using Nancy.Responses.Negotiation;
using Nancy.Serialization.JsonNet;
using Newtonsoft.Json;
using JsonProcessor = Nancy.Responses.Negotiation.JsonProcessor;


namespace NancyExample
{
	using Nancy;

	public class Bootstrapper : DefaultNancyBootstrapper
	{
		protected override NancyInternalConfiguration InternalConfiguration
		{
			get { return new NancyInternalConfigurationFactory().Build(); }
		}
	}

	public class NancyInternalConfigurationFactory
	{
		public NancyInternalConfiguration Build()
		{
			return NancyInternalConfiguration.WithOverrides(c =>
			{
				c.Serializers.Clear();
				c.Serializers.Add(typeof(DefaultXmlSerializer));
				c.Serializers.Add(typeof(JsonNetSerializer));

				c.ResponseProcessors.Clear();
				c.ResponseProcessors.Add(typeof(XmlProcessor));
				c.ResponseProcessors.Add(typeof(ExampleJsonProcessor));
			});
		}
	}
}