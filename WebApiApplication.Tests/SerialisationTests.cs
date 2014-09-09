using System;
using NUnit.Framework;
using Test.Common;

namespace WebApiApplication.Tests
{
	[TestFixture]
	public class SerialisationTests
	{
		private string _content;

		[TearDown]
		public void PrintResponse()
		{
			Console.WriteLine("--- Begin Response ---");
			Console.WriteLine(_content ?? "NULL");
			Console.WriteLine("---- End Response ----");
		}

		[Test]
		public void GetXml()
		{
			var client = CreateWebApiClient();

			_content = client.GetXml("tracks");

			Assert.That(_content, Is.StringStarting("<"), "Response doesn't look like XML.");
		}

		[Test]
		public void GetJson()
		{
			var client = CreateWebApiClient();

			_content = client.GetJson("tracks");

			Assert.That(_content, Is.StringStarting("{").Or.StringStarting("["), "Response doesn't look like JSON.");

			var expectedContent = EmbeddedResource.GetContent("Expected.json", GetType());
			Assert.That(_content, Is.EqualTo(expectedContent));
		}

		private static ApiClient CreateWebApiClient()
		{
			return new ApiClient("http://localhost:57007/api");
		}
	}
}