using System;
using NUnit.Framework;
using Test.Common;

namespace WebApiApplication.Tests
{
	[TestFixture]
	public class ExampleTests
	{
		[Test]
		public void GetResponseAsXml()
		{
			var client = new ApiClient("http://localhost/api");

			var content = client.GetXml("status", new Parameter("oauth_consumer_key", "7dxyg97d"), new Parameter("country", "gb"));

			Console.WriteLine(content);
		}

		[Test]
		public void GetResponseAsJson()
		{
			var client = new ApiClient("http://localhost/api");

			var content = client.GetJson("status", new Parameter("oauth_consumer_key", "7dxyg97d"), new Parameter("country", "gb"));

			Console.WriteLine(content);
		}
	}
}