using System;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Xml;
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
			var xmlWriterSettings = new XmlWriterSettings { Indent = false, Encoding = new UTF8Encoding(false) };

			var serializer = new XmlSerializer(value.GetType());
			serializer.Serialize(XmlWriter.Create(writeStream, xmlWriterSettings), value);
		}
	}
}