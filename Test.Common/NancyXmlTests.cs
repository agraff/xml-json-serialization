﻿using NUnit.Framework;

namespace Test.Common
{
	[TestFixture]
	public class NancyXmlTests : XmlTestsBase
	{
		protected override string ApiUrl
		{
			get { return "http://localhost/api-examples/nancy"; }
		}
	}
}
