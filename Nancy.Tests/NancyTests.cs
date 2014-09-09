using NUnit.Framework;
using Newtonsoft.Json;
using XmlJsonSerialization;

namespace NancyExample.Tests
{
	[TestFixture]
    public class NancyTests
	{
		private dynamic _response;


		[Test]
		public void Nancy_can_return_a_json_response()
		{
			CreateRequestAndGetJsonResponse();

			Assert.That(_response, Is.Not.EqualTo(null));
		}

		[Test]
		public void Nancy_Json_repsonse_is_in_cleaner_format()
		{
			CreateRequestAndGetJsonResponse();
			Assert.That(_response.tracks[0].title.Value, Is.EqualTo("First Track"));
		}

		[Test]
		public void Nancy_xml_response_is_in_older_format()
		{
			CreateRequestAndGetXmlResponse();
			Assert.That(_response.TracksResponse.Tracks.PageSize, Is.EqualTo(3));
		}

		private void CreateRequestAndGetXmlResponse()
		{
			var url = "http://localhost:8084/tracks?requestData=true";

			using (var request = new HttpRequest(url))
			{
				request.Headers["Accept"] = "application/xml";

				var response = request.Send();

				Assert.That(response.StatusCode, Is.EqualTo(200));

				_response = response.Body.FromXmlTo<dynamic>();
			}
		}

		public void CreateRequestAndGetJsonResponse()
		{
			var url = "http://localhost:8084/tracks?requestData=true";

			using (var request = new HttpRequest(url))
			{
				request.Headers["Accept"] = "application/json";

				var response = request.Send();

				Assert.That(response.StatusCode, Is.EqualTo(200));

				 _response = JsonConvert.DeserializeObject<dynamic>(response.Body);
			}
		}
    }
}
