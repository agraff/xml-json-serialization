using NUnit.Framework;

namespace Tests.Xml
{
	[TestFixture]
	public class WebApiXmlTests : XmlTestsBase
	{
		protected override string ApiUrl
		{
			get { return "http://localhost/api-examples/webapi/api"; }
		}
	}
}