using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests.Xml
{
	[TestFixture("Nancy", "http://localhost/api-examples/nancy")]
	public class DifferingResponseXmlTests
	{

			private readonly string _apiType;
		private readonly string _apiUrl;

		public DifferingResponseXmlTests(string apiType, string apiUrl)
		{
			_apiType = apiType;
			_apiUrl = apiUrl;
		}

		private string GetXmlResponse(string endpoint)
		{
			var client = new ApiClient(_apiUrl);
			var content = client.GetXml(endpoint);
			Console.WriteLine("--- Begin Content ---");
			Console.WriteLine(content ?? "NULL");
			Console.WriteLine("---- End Content ----");
			return content;
		}

		private static string RemoveXmlWhitespace(string xml)
		{
			return Regex.Replace(xml, @">\s*<", "><");
		}


		[Test]
		public void Content_Matches_Expected_Xml()
		{
			var expectedTracksXml = RemoveXmlWhitespace(Properties.Resources.TrackDetailsXml);

			var content = GetXmlResponse("trackdetails");

			Assert.That(content, Is.EqualTo(expectedTracksXml));
		}
	}
}
