using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using NUnit.Framework;
using Test.Common;

namespace WebApiApplication.Tests
{
	public class SingleEntityXmlTests : SerialisationTestsBase
	{
		[TestFixtureSetUp]
		public void GetXmlResponse()
		{
			var client = new ApiClient("http://localhost:57007/api");

			Content = client.GetXml("SingleTrack");
		}

		[Test]
		public void SingleContentIsNotEmpty()
		{
			Assert.IsNotNullOrEmpty(Content);
		}

		[Test]
		public void SingleContentIsValidXml()
		{
			var deserializedObject = XDocument.Parse(Content);
			Assert.That(deserializedObject, Is.Not.Null, "The deserialized object was null.");
		}

		[Test]
		public void SingleContentMatchesExpectedXml()
		{
			var expectedContent = Test.Common.Properties.Resources.ExpectedSingleEntityXml;

			Assert.That(Content, Is.EqualTo(expectedContent));
		}

		[Test]
		public void SingleContentMatchesExpectedXmlIgnoringWhitespace()
		{
			var expectedContent = Test.Common.Properties.Resources.ExpectedSingleEntityXml;

			var contentWithoutWhitespace = Regex.Replace(Content, @"\s", "");
			var expectedContentWithoutWhitespace = Regex.Replace(expectedContent, @"\s", "");

			Assert.That(contentWithoutWhitespace, Is.EqualTo(expectedContentWithoutWhitespace));
		}
	}
}
