using NUnit.Framework;

namespace Tests
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
