using System.Net;
using NUnit.Framework;
using RestSharp;

namespace Tests
{
	[TestFixture("Nancy", "http://localhost/api-examples/nancy")]
	[TestFixture("WebApi", "http://localhost/api-examples/webapi/api")]
	public class ContentNegotiationTests
	{
		private readonly string _apiUrl;

		public ContentNegotiationTests(string apiType, string apiUrl)
		{
			_apiUrl = apiUrl;
		}

		[Test]
		public void Bad_content_type_returns_406_Not_Acceptable()
		{
			var client = new RestClient(_apiUrl);
			var request = new RestRequest("track", Method.GET);
			request.AddHeader("Accept", "application/foo");

			var response = client.Execute(request);

			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotAcceptable));
			Assert.That(response.Content, Is.Empty);
		}
	}
}
