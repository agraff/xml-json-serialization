using System.Xml.Linq;
using NUnit.Framework;
using Test.Common;

namespace WebApiApplication.Tests
{
	public class XmlTests : SerialisationTestsBase
	{
		[TestFixtureSetUp]
		public void GetXmlResponse()
		{
			var client = FixtureSetup.CreateWebApiClient();

			Content = client.GetXml("tracks");
		}

		[Test]
		public void ContentIsNotEmpty()
		{
			Assert.IsNotNullOrEmpty(Content);
		}

		[Test]
		public void ContentIsValidXml()
		{
			var deserializedObject = XDocument.Parse(Content);
			Assert.That(deserializedObject, Is.Not.Null, "The deserialized object was null.");
		}

		[Test]
		public void ContentMatchesExpectedXml()
		{
			var expectedContent = EmbeddedResource.GetContent("Expected.xml", GetType());

			Assert.That(Content, Is.EqualTo(expectedContent));
		}
	}
}