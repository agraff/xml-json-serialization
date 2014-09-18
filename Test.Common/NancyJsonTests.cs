using NUnit.Framework;

namespace Test.Common
{
	[TestFixture]
	class NancyJsonTests : JsonTestsBase
	{
		protected override string ApiUrl
		{
			get { return "http://localhost/api-examples/nancy"; }
		}
	}
}
