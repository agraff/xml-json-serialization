using NUnit.Framework;
using Test.Common;

namespace Test.Common
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