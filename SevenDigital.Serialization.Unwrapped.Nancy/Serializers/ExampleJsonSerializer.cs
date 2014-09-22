using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NancyExample.Serializers
{
	public sealed class ExampleJsonSerializer : JsonSerializer
	{
		public ExampleJsonSerializer()
		{
			ContractResolver = new CamelCasePropertyNamesContractResolver();
			Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
			Formatting = Formatting.None;
		}
	}
}