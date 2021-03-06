﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Nancy;
using Nancy.Responses;
using Nancy.Responses.Negotiation;
using Response = Nancy.Response;

namespace NancyExample.Serializers
{
	/// <summary>
	/// Processes the model for json media types and extension.
	/// </summary>
	public class ExampleJsonProcessor : IResponseProcessor
	{
		private readonly ISerializer _serializer;
		private static readonly IEnumerable<Tuple<string, MediaRange>> ExtensionMappingsCache =
			new[] { new Tuple<string, MediaRange>("json", new MediaRange("application/json")) };

		/// <summary>
		/// Initializes a new instance of the <see cref="ExampleJsonProcessor"/> class,
		/// with the provided <see cref="serializers"/>.
		/// </summary>
		/// <param name="serializers">The serializes that the processor will use to process the request.</param>
		public ExampleJsonProcessor(IEnumerable<ISerializer> serializers)
		{
			_serializer = serializers.FirstOrDefault(x => x.CanSerialize("application/json"));
		}

		/// <summary>
		/// Gets a set of mappings that map a given extension (such as .json)
		/// to a media range that can be sent to the client in a vary header.
		/// </summary>
		public IEnumerable<Tuple<string, MediaRange>> ExtensionMappings
		{
			get { return ExtensionMappingsCache; }
		}

		/// <summary>
		/// Determines whether the the processor can handle a given content type and model
		/// </summary>
		/// <param name="requestedMediaRange">Content type requested by the client</param>
		/// <param name="model">The model for the given media range</param>
		/// <param name="context">The nancy context</param>
		/// <returns>A ProcessorMatch result that determines the priority of the processor</returns>
		public ProcessorMatch CanProcess(MediaRange requestedMediaRange, dynamic model, NancyContext context)
		{
			if (IsExactJsonContentType(requestedMediaRange))
			{
				return new ProcessorMatch
				{
					ModelResult = MatchResult.DontCare,
					RequestedContentTypeResult = MatchResult.ExactMatch
				};
			}
			if (IsWildcardJsonContentType(requestedMediaRange))
			{
				return new ProcessorMatch
				{
					ModelResult = MatchResult.DontCare,
					RequestedContentTypeResult = MatchResult.NonExactMatch
				};
			}
			return new ProcessorMatch
			{
				ModelResult = MatchResult.DontCare,
				RequestedContentTypeResult = MatchResult.NoMatch
			};
		}

		/// <summary>
		/// Process the response
		/// </summary>
		/// <param name="requestedMediaRange">Content type requested by the client</param>
		/// <param name="model">The model for the given media range</param>
		/// <param name="context">The nancy context</param>
		/// <returns>A response</returns>
		public Response Process(MediaRange requestedMediaRange, dynamic model, NancyContext context)
		{	
			Type modelType = model.GetType();
			var modelToSerialize = (object)model;
			var properties = modelType.GetProperties().ToList();
			var jsonRootProperty = properties.FirstOrDefault(HasJsonRootObjectAttribute);
			if (jsonRootProperty != null)
			{
				var m = (dynamic)jsonRootProperty.GetGetMethod().Invoke(modelToSerialize, new object[0]);
				return new JsonResponse<dynamic>(m, _serializer);
			}
			return new JsonResponse(model, _serializer);
		}

		private bool HasJsonRootObjectAttribute(PropertyInfo property)
		{
			var attributes = property.GetCustomAttributes(true);
			return attributes.OfType<JsonRootObject>().Any();
		}

		private static bool IsExactJsonContentType(MediaRange requestedContentType)
		{
			if (requestedContentType.Type.IsWildcard && requestedContentType.Subtype.IsWildcard)
			{
				return true;
			}
			return requestedContentType.Matches("application/json") || requestedContentType.Matches("text/json");
		}

		private static bool IsWildcardJsonContentType(MediaRange requestedContentType)
		{
			if (!requestedContentType.Type.IsWildcard && !string.Equals("application", requestedContentType.Type, StringComparison.InvariantCultureIgnoreCase))
			{
				return false;
			}
			if (requestedContentType.Subtype.IsWildcard)
			{
				return true;
			}
			var subtypeString = requestedContentType.Subtype.ToString();
			return (subtypeString.StartsWith("vnd", StringComparison.InvariantCultureIgnoreCase) &&
			subtypeString.EndsWith("+json", StringComparison.InvariantCultureIgnoreCase));
		}
	}
}