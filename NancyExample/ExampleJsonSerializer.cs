using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NancyExample
{
	public sealed class ExampleJsonSerializer : JsonSerializer
	{
		public ExampleJsonSerializer()
		{
			ContractResolver = new CamelCasePropertyNamesContractResolver();
			Formatting = Formatting.None;
		}
	}
}