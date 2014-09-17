using System.Text.RegularExpressions;
using System.Xml.Linq;
using NUnit.Framework;
using Test.Common;

namespace WebApiApplication.Tests
{
	public class XmlTests : XmlTestsBase
	{
		protected override string ApiUrl
		{
			get { return "http://localhost:57007/api"; }
		}
	}
}