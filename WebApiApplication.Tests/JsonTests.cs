using System.Text.RegularExpressions;
using NUnit.Framework;
using Newtonsoft.Json;
using Test.Common;

namespace WebApiApplication.Tests
{
	[TestFixture]
	public class JsonTests : JsonTestsBase
	{
		protected override string ApiUrl
		{
			get { return "http://localhost:57007/api"; }
		}
	}
}