using System;
using NUnit.Framework;
using Test.Common;
using XmlJsonSerialization;

namespace NancyExample.Tests
{
	[TestFixture]
	public class NancyStringComparisonTests
	{
		[Test]
		public void Xml_collection_returned_matches_expected_xml()
		{
			var expectedXml = EmbeddedResource.GetContent("Expected.xml", GetType());

			Assert.That(CreateRequestAndGetResponse("xml", "http://localhost:8084/tracks?requestData=true"), Is.EqualTo(expectedXml));
		}

		[Test]
		public void Json_collection_returned_matches_expected_json()
		{
			var expectedJson = EmbeddedResource.GetContent("Expected.json", GetType());

			Assert.That(CreateRequestAndGetResponse("Json", "http://localhost:8084/tracks?requestData=true"), Is.EqualTo(expectedJson));
		}

		[Test]
		public void Xml_SingleEntity_returned_matches_expected_xml()
		{
			var expectedSingleXml = EmbeddedResource.GetContent("ExpectedSingleEntity.xml", GetType());

			Assert.That(CreateRequestAndGetResponse("xml", "http://localhost:8084/singleTrack?requestData=true"), Is.EqualTo(expectedSingleXml));
		}

		[Test]
		public void Json_SingleEntity_returned_matches_expected_Json()
		{
			var expectedSingleJson = EmbeddedResource.GetContent("ExpectedSingleEntity.json", GetType());

			Assert.That(CreateRequestAndGetResponse("json", "http://localhost:8084/singleTrack?requestData=true"), Is.EqualTo(expectedSingleJson));
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
