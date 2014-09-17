using System;
using System.Xml.Linq;
using NUnit.Framework;

namespace Test.Common
{
	public abstract class XmlTestsBase
	{
		protected abstract string ApiUrl { get; }

		public string GetXmlResponse(string endpoint)
		{
			var Client = new ApiClient(ApiUrl);
			var content = Client.GetXml(endpoint);
			Console.WriteLine("--- Begin Content ---");
			Console.WriteLine(content ?? "NULL");
			Console.WriteLine("---- End Content ----");
			return content;

		}

		[Test]
		public void ContentIsNotEmpty()
		{
			var content = GetXmlResponse("tracks");
			Assert.IsNotNullOrEmpty(content);
		}


		[Test]
		public void ContentIsValidXml()
		{
			var content = GetXmlResponse("tracks");

			var deserializedObject = XDocument.Parse(content);
			Assert.That(deserializedObject, Is.Not.Null, "The deserialized object was null.");
		}

		[Test]
		public void ContentMatchesExpectedXml()
		{
			var expectedContent = Test.Common.Properties.Resources.ExpectedXml;

			var content = GetXmlResponse("tracks");

			Assert.That(content, Is.EqualTo(expectedContent));
		}


	}
}