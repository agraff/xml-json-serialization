using System.Text.RegularExpressions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Json
{
	[TestFixture("Nancy", "http://localhost/api-examples/nancy")]
	public class DifferingResponseJsonTests
	{
		private readonly string _apiType;
		private readonly string _apiUrl;

		public DifferingResponseJsonTests(string apiType, string apiUrl)
		{
			_apiType = apiType;
			_apiUrl = apiUrl;
		}

		private string GetJsonResponse(string endpoint)
		{
			var client = new ApiClient(_apiUrl);
			var content = client.GetJson(endpoint);
			Console.WriteLine("--- Begin Content ---");
			Console.WriteLine(content ?? "NULL");
			Console.WriteLine("---- End Content ----");
			return content;
		}

		private static string RemoveJsonWhitespace(string json)
		{
			return Regex.Replace(json, "(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+", "$1");
		}

		[Test]
		public void Content_Matches_Expected_Json()
		{
			var expectedTracksJson = RemoveJsonWhitespace(Properties.Resources.TrackDetailsJson);

			var content = GetJsonResponse("trackdetails");

			Assert.That(content, Is.EqualTo(expectedTracksJson));
		}
	}
}
