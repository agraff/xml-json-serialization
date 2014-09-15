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
		public void Xml_returned_matches_expected_xml()
		{
			var expectedXml = EmbeddedResource.GetContent("Expected.xml", GetType());

			Assert.That(CreateRequestAndGetResponse("xml"), Is.EqualTo(expectedXml));
		}

		[Test]
		public void Json_returned_matches_expected_json()
		{
			var expectedJson = EmbeddedResource.GetContent("Expected.json", GetType());

			Assert.That(CreateRequestAndGetResponse("Json"), Is.EqualTo(expectedJson));
		}
		
		private string CreateRequestAndGetResponse(string contentType)
		{
			var url = "http://localhost:8084/tracks?requestData=true";

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
