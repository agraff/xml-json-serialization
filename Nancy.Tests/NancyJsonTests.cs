using NUnit.Framework;
using Test.Common;

namespace NancyExample.Tests
{
	[TestFixture]
	class NancyJsonTests : JsonTestsBase
	{
		protected override string ApiUrl
		{
			get { return "http://localhost:8084/"; }
		}
	}
}
