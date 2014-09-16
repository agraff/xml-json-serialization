using System.Text.RegularExpressions;
using NUnit.Framework;
using Newtonsoft.Json;
using Test.Common;

namespace WebApiApplication.Tests
{
	[TestFixture]
	public class JsonTests : SerialisationTestsBase
	{
		[TestFixtureSetUp]
		public void GetJsonResponse()
		{
			var client = FixtureSetup.CreateWebApiClient("http://localhost:57007/api");

			Content = client.GetJson("tracks");
		}

		[Test]
		public void ContentIsNotEmpty()
		{
			Assert.IsNotNullOrEmpty(Content);
		}

		[Test]
		public void ContentIsValidJson()
		{
			var deserializedObject = JsonConvert.DeserializeObject<dynamic>(Content);
			Assert.That(deserializedObject, Is.Not.Null, "The deserialized object was null.");
		}

		[Test]
		public void ContentMatchesExpectedJson()
		{
			var expectedContent = EmbeddedResource.GetContent("Expected.json");

			Assert.That(Content, Is.EqualTo(expectedContent));
		}

		[Test]
		public void ContentMatchesExpectedJsonIgnoringWhitespace()
		{
			var expectedContent = EmbeddedResource.GetContent("Expected.json");

			var contentWithoutWhitespace = Regex.Replace(Content, @"\s", "");
			var expectedContentWithoutWhitespace = Regex.Replace(expectedContent, @"\s", "");

			Assert.That(contentWithoutWhitespace, Is.EqualTo(expectedContentWithoutWhitespace));
		}
	}
}