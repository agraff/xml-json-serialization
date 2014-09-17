using System;
using NUnit.Framework;
using Test.Common;

namespace NancyExample.Tests
{
	[TestFixture]
	public class NancyXmlTests : XmlTestsBase
	{
		protected override string ApiUrl
		{
			get { return "http://localhost:8084/"; }
		}
	}
}
