using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Nancy;
using Nancy.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Nancy.Serialization.JsonNet;
using Newtonsoft.Json.Serialization;

namespace NancyExample
{
	public class JsonNetSerializer : ISerializer
	{
		private readonly JsonSerializer serializer;

		public IEnumerable<string> Extensions
		{
			get
			{
				yield return "json";
			}
		}

		public JsonNetSerializer()
		{
			this.serializer = new JsonSerializer();
			serializer.ContractResolver = new CamelCasePropertyNamesContractResolver();
		}

		public JsonNetSerializer(JsonSerializer serializer)
		{
			this.serializer = serializer;
			serializer.ContractResolver = new CamelCasePropertyNamesContractResolver();
		}

		public bool CanSerialize(string contentType)
		{
			return Helpers.IsJsonType(contentType);
		}

		public void Serialize<TModel>(string contentType, TModel model, Stream outputStream)
		{
			using (JsonTextWriter jsonTextWriter = new JsonTextWriter((TextWriter)new StreamWriter((Stream)new UnclosableStreamWrapper(outputStream))))
				this.serializer.Serialize((JsonWriter)jsonTextWriter, (object)model);
		}
	}

	internal static class Helpers
	{
		public static bool IsJsonType(string contentType)
		{
			if (string.IsNullOrEmpty(contentType))
				return false;
			string str = contentType.Split(new char[1]
      {
        ';'
      })[0];
			if (str.Equals("application/json", StringComparison.InvariantCultureIgnoreCase) || str.Equals("text/json", StringComparison.InvariantCultureIgnoreCase))
				return true;
			if (str.StartsWith("application/vnd", StringComparison.InvariantCultureIgnoreCase))
				return str.EndsWith("+json", StringComparison.InvariantCultureIgnoreCase);
			else
				return false;
		}
	}
}