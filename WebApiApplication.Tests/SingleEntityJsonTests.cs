using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;
using Test.Common;

namespace WebApiApplication.Tests
{
	class SingleEntityJsonTests : SerialisationTestsBase
	{
		[TestFixtureSetUp]
		public void GetJsonResponse()
		{
			var client = FixtureSetup.CreateWebApiClient("http://localhost:57007/api");

			Content = client.GetJson("singleTrack");
		}

		[Test]
		public void SingleContentIsNotEmpty()
		{
			Assert.IsNotNullOrEmpty(Content);
		}

		[Test]
		public void SingleContentIsValidJson()
		{
			var deserializedObject = JsonConvert.DeserializeObject<dynamic>(Content);
			Assert.That(deserializedObject, Is.Not.Null, "The deserialized object was null.");
		}

		[Test]
		public void SingleContentMatchesExpectedJson()
		{
			var expectedContent = EmbeddedResource.GetContent("ExpectedSingleEntity.json");

			Assert.That(Content, Is.EqualTo(expectedContent));
		}

		[Test]
		public void SingleContentMatchesExpectedJsonIgnoringWhitespace()
		{
			var expectedContent = EmbeddedResource.GetContent("ExpectedSingleEntity.json");

			var contentWithoutWhitespace = Regex.Replace(Content, @"\s", "");
			var expectedContentWithoutWhitespace = Regex.Replace(expectedContent, @"\s", "");

			Assert.That(contentWithoutWhitespace, Is.EqualTo(expectedContentWithoutWhitespace));
		}
	}
}
