using System;
using System.IO;
using System.Xml.Linq;
using NUnit.Framework;
using Newtonsoft.Json;
using Tests.Properties;

namespace Tests
{
	[TestFixture]
	[Explicit]
	public class PrettyPrintExpectedContent
	{
		[Test]
		public void PrettyPrintXml()
		{
			var xml = Resources.ExpectedXml;
			
			var xDocument = XDocument.Parse(xml);
			var formattedXml = xDocument.Declaration + Environment.NewLine + xDocument;

			Print(formattedXml, "Expected.xml");
		}

		[Test]
		public void PrettyPrintJson()
		{
			var json = Resources.ExpectedJson;
			var formattedJson = JsonConvert.DeserializeObject<dynamic>(json).ToString();

			Print(formattedJson, "Expected.json");
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