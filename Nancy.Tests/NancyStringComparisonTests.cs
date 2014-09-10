using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
			var expectedXml = EmbeddedResource.GetContent("Expected.xml", GetType())
			                                  .Replace("\r\n", string.Empty)
			                                  .Replace("\t", string.Empty)
			                                  .Replace(" ", string.Empty);

			Assert.That(CreateRequestAndGetResponse("xml"), Is.EqualTo(expectedXml));
		}

		[Test]
		public void Json_returned_matches_expected_json()
		{
			var expectedJson = EmbeddedResource.GetContent("Expected.json", GetType());
											  //.Replace("\r\n", string.Empty)
											  //.Replace("\t", string.Empty)
											  //.Replace(" ", string.Empty);

			Assert.That(CreateRequestAndGetResponse("Json"), Is.EqualTo(expectedJson));
		}



		private string CreateRequestAndGetResponse(string contentType)
		{
			var url = "http://localhost:8084/tracks?requestData=true";

			using (var request = new HttpRequest(url))
			{
				request.Headers["Accept"] = String.Format("application/{0}", contentType);

				var response = request.Send();

				Assert.That(response.StatusCode, Is.EqualTo(200));

				var xmlToReturn = response.Body;
				xmlToReturn = xmlToReturn.Replace("\r\n", string.Empty).Replace("\t", string.Empty).Replace(" ", string.Empty);
				return xmlToReturn;
			}
		}
	}
}
