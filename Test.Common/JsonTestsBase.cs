using System;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Newtonsoft.Json;

namespace Test.Common
{
	public abstract class JsonTestsBase
	{
		protected abstract string ApiUrl { get; }

		public string GetJsonResponse(string endpoint)
		{
			var client = new ApiClient(ApiUrl);
			var content = client.GetJson(endpoint);
			Console.WriteLine("--- Begin Content ---");
			Console.WriteLine(content ?? "NULL");
			Console.WriteLine("---- End Content ----");
			return content;
		}

		[Test]
		public void ContentIsNotEmpty()
		{
			var content = GetJsonResponse("tracks");

			Assert.IsNotNullOrEmpty(content);
		}

		[Test]
		public void ContentIsValidJson()
		{
			var content = GetJsonResponse("tracks");
			var deserializedObject = JsonConvert.DeserializeObject<dynamic>(content);

			Assert.That(deserializedObject, Is.Not.Null, "The deserialized object was null.");
		}

		[Test]
		public void ContentMatchesExpectedJson()
		{
			var expectedContent = Properties.Resources.ExpectedJson;

			var content = GetJsonResponse("tracks");

			Assert.That(content, Is.EqualTo(expectedContent));
		}

		[Test]
		public void SingleContentIsNotEmpty()
		{
			var content = GetJsonResponse("singleTrack");

			Assert.IsNotNullOrEmpty(content);
		}

		[Test]
		public void SingleContentIsValidJson()
		{
			var content = GetJsonResponse("singleTrack");
			var deserializedObject = JsonConvert.DeserializeObject<dynamic>(content);

			Assert.That(deserializedObject, Is.Not.Null, "The deserialized object was null.");
		}

		[Test]
		public void Json_SingleEntity_returned_matches_expected_Json()
		{
			var expectedSingleJson = Properties.Resources.ExpectedSingleEntityJson;

			var content = GetJsonResponse("singleTrack");

			Assert.That(content, Is.EqualTo(expectedSingleJson));
		}
	}
}
