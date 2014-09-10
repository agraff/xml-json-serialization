using System.Xml.Serialization;
using Nancy.Json;
using Newtonsoft.Json;

namespace NancyExample.DomainObjects
{
	public class Response
	{
		[XmlAttribute("status")]
		[JsonProperty(PropertyName = "status", Order = -2)]
		public string Status = "ok";

		[XmlAttribute("version")]
		[JsonProperty(PropertyName = "version", Order = -1)]
		public string Version = "1.2";

		[XmlAttribute(AttributeName = "noNamespaceSchemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")] [ScriptIgnore]
		public string Schema = @"http://api.7digital.com/1.2/static/7digitalAPI.xsd";
	}
}
