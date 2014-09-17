using NUnit.Framework;

namespace Test.Common
{
	[TestFixture]
	public class WebApiXmlTests : XmlTestsBase
	{
		protected override string ApiUrl
		{
			get { return "http://localhost:57007/api"; }
		}
	}
}