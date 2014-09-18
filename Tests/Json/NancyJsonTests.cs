using NUnit.Framework;

namespace Tests.Json
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
