using System;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Tests.Json
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

		private string GetJsonResponse(string endpoint)
		{
			var client = new ApiClient(_apiUrl);
			var content = client.GetJson(endpoint);
			Console.WriteLine("--- Begin Content ---");
			Console.WriteLine(content ?? "NULL");
			Console.WriteLine("---- End Content ----");
			return content;
		}

		[Test]
		public void Content_Is_Not_Empty()
		{
			var content = GetJsonResponse("tracks");

			Assert.IsNotNullOrEmpty(content);
		}

		[Test]
		public void Content_Is_Valid_Json()
		{
			var content = GetJsonResponse("tracks");
			var deserializedObject = JsonConvert.DeserializeObject<dynamic>(content);

			Assert.That(deserializedObject, Is.Not.Null, "The deserialized object was null.");
		}

		[Test]
		public void Content_Matches_Expected_Json()
		{
			var expectedTracksJson = Properties.Resources.TracksJson;

			var content = GetJsonResponse("tracks");

			Assert.That(content, Is.EqualTo(expectedTracksJson));
		}

		[Test]
		public void Single_Content_Is_Not_Empty()
		{
			var content = GetJsonResponse("track");

			Assert.IsNotNullOrEmpty(content);
		}

		[Test]
		public void Single_Content_Is_Valid_Json()
		{
			var content = GetJsonResponse("track");
			var deserializedObject = JsonConvert.DeserializeObject<dynamic>(content);

			Assert.That(deserializedObject, Is.Not.Null, "The deserialized object was null.");
		}

		[Test]
		public void Single_Content_matches_expected_Json()
		{
			var expectedTrackJson = Properties.Resources.TrackJson;

			var content = GetJsonResponse("track");

			Assert.That(content, Is.EqualTo(expectedTrackJson));
		}
	}
}
