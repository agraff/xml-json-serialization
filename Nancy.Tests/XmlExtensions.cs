using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using NUnit.Framework;
using SevenDigital.Api.Wrapper.Responses;
using SevenDigital.Api.Wrapper.Responses.Parsing;

namespace NancyExample.Tests
{
	public static class XmlExtensions
	{
		private static XmlSchemaSet _schemas;

		public static void ValidateAgainst7dSchema(this XmlDocument xml)
		{
			Assert.That(xml.InnerXml, Is.StringStarting("<?xml version=\"1.0\""));

			xml.Schemas = Schemas;
			xml.Validate(ValidationCallBack);
		}

		public static T FromXmlTo<T>(this string xml) where T : class, new()
		{
			var serializer = new ResponseDeserializer();
			return serializer.DeserializeResponse<T>(new Response(HttpStatusCode.OK, xml), true);
		}

		public static XmlDocument ToXml(this string text)
		{
			var xml = new XmlDocument();
			xml.LoadXml(text);

			return xml;
		}

		public static string GetElementValue(this XmlNode xml, string elementName)
		{
			return xml.SelectSingleNode(elementName).InnerText;
		}

		public static bool IsElementNull(this XmlNode xml, string elementName)
		{
			return xml.SelectSingleNode(elementName).Attributes["xsi:nil"].Value == "true";
		}

		public static string GetAttributeValue(this XmlNode xml, string attributeName)
		{
			return xml.Attributes[attributeName].Value;
		}

		private static XmlSchemaSet Schemas
		{
			get
			{
				if (_schemas == null)
				{
					_schemas = new XmlSchemaSet();
					_schemas.Add(null, "http://api.7digital.uat/1.2/static/7digitalAPI.xsd");
				}

				return _schemas;
			}
		}

		private static void ValidationCallBack(object sender, ValidationEventArgs e)
		{
			throw new XmlSchemaValidationException(e.Message);
		}
	}
}
