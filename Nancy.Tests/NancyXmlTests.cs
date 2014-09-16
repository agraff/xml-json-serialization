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
			
			Content = Client.GetXml("tracks",Parameter );
		}

		[Test]
		public void Xml_collection_returned_matches_expected_xml()
		{
			Content = Client.GetXml("tracks", Parameter);

			var expectedXml = EmbeddedResource.GetContent("Expected.xml");

			Assert.That(Content, Is.EqualTo(expectedXml));
		}


		[Test]
		public void Xml_SingleEntity_returned_matches_expected_xml()
		{
			Content = Client.GetXml("SingleTrack", Parameter);

			var expectedSingleXml = EmbeddedResource.GetContent("ExpectedSingleEntity.xml");

			Assert.That(Content, Is.EqualTo(expectedSingleXml));
		}
	}
}
