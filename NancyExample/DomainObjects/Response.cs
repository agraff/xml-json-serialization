using System.Xml.Serialization;
using Nancy.Json;
using Newtonsoft.Json;

namespace NancyExample.DomainObjects
{
	public class Response
	{
		[XmlAttribute("status")]
		public string Status = "ok";

		[XmlAttribute("version")]
		public string Version = "1.2";

		[XmlAttribute(AttributeName = "noNamespaceSchemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public string Schema = @"http://api.7digital.com/1.2/static/7digitalAPI.xsd";
	}
}
