using System;
using NUnit.Framework;
using Test.Common;

namespace NancyExample.Tests
{
	[TestFixture]
	public class NancyXmlTests : SerialisationTestsBase
	{
		[TestFixtureSetUp]
		public void GetXmlResponse()
		{
			Client = FixtureSetup.CreateWebApiClient("http://localhost:8084/");
			Parameter = new Parameter {Name = "requestData", Value = "true"};
		}

		[Test]
		public void Xml_collection_returned_matches_expected_xml()
		{
			Content = Client.GetXml("tracks", Parameter);

			var expectedXml = Test.Common.Properties.Resources.ExpectedXml;

			Assert.That(Content, Is.EqualTo(expectedXml));
		}


		[Test]
		public void Xml_SingleEntity_returned_matches_expected_xml()
		{
			Content = Client.GetXml("SingleTrack", Parameter);

			var expectedSingleXml = Test.Common.Properties.Resources.ExpectedSingleEntityXml;
			
			Assert.That(Content, Is.EqualTo(expectedSingleXml));
		}
	}
}
