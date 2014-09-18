using NUnit.Framework;

namespace Tests.Json
{
	[TestFixture]
	public class WebApiJsonTests : JsonTestsBase
	{
		protected override string ApiUrl
		{
			get { return "http://localhost/api-examples/webapi/api"; }
		}
	}
}