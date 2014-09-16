using NUnit.Framework;
using Test.Common;

namespace Test.Common
{
	[SetUpFixture]
	public class FixtureSetup
	{
		[SetUp]
		public void RunBeforeAnyTestsInNamespace()
		{
			var client = CreateWebApiClient("http://localhost:8084/");
			var response = client.GetXml("tracks");

			if (string.IsNullOrEmpty(response))
				Assert.Fail("The WebAPI server did not return any content. Make sure the server is manually started before running the tests.");
		}

		public static ApiClient CreateWebApiClient(string uri)
		{
			return new ApiClient(uri);
		}
	}
}