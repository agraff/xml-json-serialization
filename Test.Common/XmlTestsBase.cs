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
		public void Content_Is_Not_Empty()
		{
			var content = GetXmlResponse("tracks");
			Assert.IsNotNullOrEmpty(content);
		}


		[Test]
		public void Content_Is_Valid_Xml()
		{
			var content = GetXmlResponse("tracks");

			var deserializedObject = XDocument.Parse(content);
			Assert.That(deserializedObject, Is.Not.Null, "The deserialized object was null.");
		}

		[Test]
		public void Content_Matches_Expected_Xml()
		{
			var expectedContent = Properties.Resources.ExpectedXml;

			var content = GetXmlResponse("tracks");

			Assert.That(content, Is.EqualTo(expectedContent));
		}

		[Test]
		public void Single_Content_Is_Not_Empty()
		{
			var content = GetXmlResponse("track");
			Assert.IsNotNullOrEmpty(content);
		}


		[Test]
		public void Single_Content_Is_Valid_Xml()
		{
			var content = GetXmlResponse("track");

			var deserializedObject = XDocument.Parse(content);
			Assert.That(deserializedObject, Is.Not.Null, "The deserialized object was null.");
		}

		

		[Test]
		public void Single_Content_returned_matches_expected_xml()
		{
			var content = GetXmlResponse("track");

			var expectedSingleXml = Properties.Resources.ExpectedSingleEntityXml;

			Assert.That(content, Is.EqualTo(expectedSingleXml));
		}


	}
}