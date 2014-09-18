using NUnit.Framework;
using Tests;

namespace Tests
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