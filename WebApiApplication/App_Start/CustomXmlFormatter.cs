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
	public class CustomXmlFormatter : BufferedMediaTypeFormatter
	{
		public CustomXmlFormatter()
		{
			SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/xml"));
			SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/xml"));
		}

		public override bool CanReadType(Type type)
		{
			return true;
		}

		public override bool CanWriteType(Type type)
		{
			return true;
		}

		public override void WriteToStream(Type type, object value, System.IO.Stream writeStream, System.Net.Http.HttpContent content)
		{
			if (true)
				WriteToStreamSimple(type, value, writeStream);
			else
				WriteToStreamFullCustom(type, value, writeStream);
		}

		private static void WriteToStreamFullCustom(Type type, object value, Stream writeStream)
		{
			var serializer = new XmlSerializer(type);
			var ms = new MemoryStream();
			serializer.Serialize(XmlWriter.Create(ms), value);
			ms.Position = 0;
			var xDoc = XDocument.Load(ms);

			// wrap the TrackResponse in a xml doctype + <response>
			var trackResponseNode = xDoc.FirstNode;

			var responseElement = new XElement("response");
			responseElement.Add(trackResponseNode);


			// write the memorystream or XDocument to the writeStream
			var xmlWriter = XmlWriter.Create(writeStream);
			xDoc.WriteTo(xmlWriter);

			// profit!
		}

		private static void WriteToStreamSimple(Type type, object value, Stream writeStream)
		{
			var serializer = new XmlSerializer(type);

			var xmlWriterSettings = new XmlWriterSettings {Indent = false, Encoding = new UTF8Encoding(false)};
			serializer.Serialize(XmlWriter.Create(writeStream, xmlWriterSettings), value);
		}
	}
}