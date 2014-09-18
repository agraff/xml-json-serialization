using System;
using System.Xml.Linq;
using NUnit.Framework;

namespace Tests.Xml
{
	[TestFixture("Nancy", "http://localhost/api-examples/nancy")]
	[TestFixture("WebApi", "http://localhost/api-examples/webapi/api")]
	public class JsonTests
	{
		private readonly string _apiUrl;

		public JsonTests(string apiType, string apiUrl)
		{
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

		[Test]
		public void Content_Is_Not_Empty()
		{
			var content = GetXmlResponse("tracks");

			Assert.IsNotNullOrEmpty(content);
		}

		[Test]
		public void Content_Is_Valid_Xml()
		{
			var content = GetXmlResponse("tracks");
			var deserializedObject = XDocument.Parse(content);

			Assert.That(deserializedObject, Is.Not.Null, "The deserialized object was null.");
		}

		[Test]
		public void Content_Matches_Expected_Xml()
		{
			var expectedTracksXml = Properties.Resources.TracksXml;

			var content = GetXmlResponse("tracks");

			Assert.That(content, Is.EqualTo(expectedTracksXml));
		}

		[Test]
		public void Single_Content_Is_Not_Empty()
		{
			var content = GetXmlResponse("track");

			Assert.IsNotNullOrEmpty(content);
		}

		[Test]
		public void Single_Content_Is_Valid_Xml()
		{
			var content = GetXmlResponse("track");
			var deserializedObject = XDocument.Parse(content);

			Assert.That(deserializedObject, Is.Not.Null, "The deserialized object was null.");
		}

		[Test]
		public void Single_Content_returned_matches_expected_xml()
		{
			var expectedTrackXml = Properties.Resources.TrackXml;

			var content = GetXmlResponse("track");

			Assert.That(content, Is.EqualTo(expectedTrackXml));
		}
	}
}