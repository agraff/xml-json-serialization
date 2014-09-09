using System;
using NUnit.Framework;
using Test.Common;

namespace WebApiApplication.Tests
{
	[TestFixture]
	public class SerialisationTests
	{
		[Test]
		public void GetXml()
		{
			var client = CreateWebApiClient();

			var content = client.GetXml("values");

			Console.WriteLine(content);
			Assert.That(content, Is.StringStarting("<"));
		}

		[Test]
		public void GetJson()
		{
			var client = CreateWebApiClient();

			var content = client.GetJson("values");

			Console.WriteLine(content);
			Assert.That(content, Is.StringStarting("{").Or.StringStarting("["));
		}

		private static ApiClient CreateWebApiClient()
		{
			return new ApiClient("http://localhost:57007/api");
		}
	}
}