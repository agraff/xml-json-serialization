using System;
using System.IO;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WebApiApplication
{
	public class WrappedResponseXmlFormatter : BufferedMediaTypeFormatter
	{
		public WrappedResponseXmlFormatter()
		{
			SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/xml"));
			SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/xml"));
		}

		public override bool CanReadType(Type type)
		{
			return false;
		}

		public override bool CanWriteType(Type type)
		{
			return true;
		}

		public override void WriteToStream(Type type, object value, Stream writeStream, System.Net.Http.HttpContent content)
		{
			var valueXDoc = SerializeToXDoc(type, value);

			var rootResponseElement = CreateRootResponseElement();
			rootResponseElement.Add(valueXDoc.Root);
			
			var responseXDoc = new XDocument(rootResponseElement);
			WriteXDocToStream(responseXDoc, writeStream);
		}

		private static XDocument SerializeToXDoc(Type type, object value)
		{
			using (var ms = new MemoryStream())
			{
				using (var writer = XmlWriter.Create(ms))
				{
					var ns = new XmlSerializerNamespaces();
					ns.Add("", "");
					var xmlSerializer = new XmlSerializer(type);
					xmlSerializer.Serialize(writer, value, ns);
				}
				ms.Position = 0;
				return XDocument.Load(ms);
			}
		}

		private static XElement CreateRootResponseElement()
		{
			const string xsi = "http://www.w3.org/2001/XMLSchema-instance";
			const string xsd = "http://www.w3.org/2001/XMLSchema";
			const string noNamespaceSchemaLocation = "http://api.7digital.com/1.2/static/7digitalAPI.xsd";
			return new XElement("response",
				new XAttribute(XNamespace.Xmlns + "xsi", xsi),
				new XAttribute(XNamespace.Xmlns + "xsd", xsd),
				new XAttribute(XNamespace.Get(xsi) + "noNamespaceSchemaLocation", noNamespaceSchemaLocation),
				new XAttribute("status", "ok"),
				new XAttribute("version", "1.2"));
		}

		private static void WriteXDocToStream(XDocument xDoc, Stream stream)
		{
			var xmlWriterSettings = new XmlWriterSettings 
			{
				Indent = false, 
				Encoding = new UTF8Encoding(false, true)
			};
			using (var writer = XmlWriter.Create(stream, xmlWriterSettings))
			{
				xDoc.Save(writer);
			}
		}
	}
}