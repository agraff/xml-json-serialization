using NUnit.Framework;
using Test.Common;

namespace WebApiApplication.Tests
{
	[SetUpFixture]
	public class FixtureSetup
	{
		[SetUp]
		public void RunBeforeAnyTestsInNamespace()
		{
			var client = CreateWebApiClient();
			var response = client.GetXml("tracks");

			if (string.IsNullOrEmpty(response))
				Assert.Fail("The WebAPI server did not return any content. Make sure the server is manually started before running the tests.");
		}

		public static ApiClient CreateWebApiClient()
		{
			return new ApiClient("http://localhost:57007/api");
		}
	}
}