using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Test.Common;

namespace NancyExample.Tests
{
	[TestFixture]
	class NancyJsonTests : SerialisationTestsBase
	{
		[TestFixtureSetUp]
		public void GetJsonResponse()
		{
			Client = FixtureSetup.CreateWebApiClient("http://localhost:8084/");
			Parameter = new Parameter { Name = "requestData", Value = "true" };
		}


		[Test]
		public void Json_SingleEntity_returned_matches_expected_Json()
		{
			Content = Client.GetJson("SingleTrack", Parameter);

			var expectedSingleJson = Test.Common.Properties.Resources.ExpectedSingleEntityJson;
			

			Assert.That(Content, Is.EqualTo(expectedSingleJson));
		}

		[Test]
		public void Json_collection_returned_matches_expected_json()
		{
			Content = Client.GetJson("tracks", Parameter);

			var expectedJson = Test.Common.Properties.Resources.ExpectedJson;

			Assert.That(Content, Is.EqualTo(expectedJson));
		}


	}
}
