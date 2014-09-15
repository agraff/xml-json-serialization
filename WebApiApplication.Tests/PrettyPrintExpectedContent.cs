using System;
using System.IO;
using System.Xml.Linq;
using NUnit.Framework;
using Newtonsoft.Json;
using Test.Common;

namespace WebApiApplication.Tests
{
	[TestFixture]
	[Explicit]
	public class PrettyPrintExpectedContent
	{
		[Test]
		public void PrettyPrintXml()
		{
			const string resourceName = "Expected.xml";

			var xml = EmbeddedResource.GetContent(resourceName, GetType());
			var xDocument = XDocument.Parse(xml);
			var formattedXml = xDocument.Declaration + Environment.NewLine + xDocument;

			Print(formattedXml, resourceName);
		}

		[Test]
		public void PrettyPrintJson()
		{
			const string resourceName = "Expected.json";

			var json = EmbeddedResource.GetContent(resourceName, GetType());
			var formattedJson = JsonConvert.DeserializeObject<dynamic>(json).ToString();

			Print(formattedJson, resourceName);
		}

		private static void Print(string content, string resourceName)
		{
			Console.WriteLine(content);

			var outputFile = "Formatted_" + resourceName;
			using (var file = new StreamWriter(outputFile))
			{
				file.Write(content);
			}
		}
	}
}