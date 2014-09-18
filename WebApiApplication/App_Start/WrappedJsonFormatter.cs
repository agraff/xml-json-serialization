using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WebApiApplication.DomainObjects;

namespace WebApiApplication.App_Start
{
	public class WrappedJsonFormatter : BufferedMediaTypeFormatter
	{

		public WrappedJsonFormatter()
		{
			SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
		}

		public override bool CanReadType(Type type)
		{
			return false;
		}

		public override bool CanWriteType(Type type)
		{
			return true;
		}

		public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
		{
			if (value is PagedCollectionBase)
			{
				SerializeValue(writeStream, value);
			}
			else
			{
				WrapAndSerializeValue(type, value, writeStream);	
			}
		}

		private static void SerializeValue(Stream writeStream, object value)
		{
			using (var sw = new StreamWriter(writeStream))
			using (var writer = new JsonTextWriter(sw))
			{
				var serializer = new JsonSerializer();
				serializer.ContractResolver = new CamelCasePropertyNamesContractResolver();
				serializer.Serialize(writer, value);

			}
		}

		private static void WrapAndSerializeValue(Type type, object value, Stream writeStream)
		{
			var response = new ExpandoObject() as IDictionary<string, Object>;
			response.Add(type.Name, value);
			SerializeValue(writeStream, response);
		}
	}
}