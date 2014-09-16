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

			var expectedXml = EmbeddedResource.GetContent("Expected.xml", GetType());

			Assert.That(Content, Is.EqualTo(expectedXml));
		}


		[Test]
		public void Xml_SingleEntity_returned_matches_expected_xml()
		{
			Content = Client.GetXml("SingleTrack", Parameter);

			var expectedSingleXml = EmbeddedResource.GetContent("ExpectedSingleEntity.xml", GetType());

			Assert.That(Content, Is.EqualTo(expectedSingleXml));
		}

		
	
		
		private string CreateRequestAndGetResponse(string contentType, string url)
		{
			using (var request = new HttpRequest(url))
			{
				request.Headers["Accept"] = String.Format("application/{0}", contentType);

				DateTime endTime;
				var startTime = new DateTime();
				startTime = DateTime.Now;

				var response = request.Send();
				endTime = DateTime.Now;

				var timeTaken = endTime.Subtract(startTime).Milliseconds;

				Assert.That(response.StatusCode, Is.EqualTo(200));

				return response.Body;;
			}
		}
	}
}
