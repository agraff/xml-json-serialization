using System;
using System.IO;
using System.Reflection;

namespace Test.Common
{
	public static class EmbeddedResource
	{
		public static string GetContent(string resourceName)
		{
		//var assembly = Assembly.GetAssembly()
		//var fullResourceName = String.Format("{0}.{1}", "Test.Common", resourceName);

		//	using (var stream = assembly.GetManifestResourceStream(fullResourceName))
			using (var reader = new StreamReader(string.Concat(@"C:\Work\POC\xml-json-serialization\Test.Common\", resourceName)))
			{
				return reader.ReadToEnd();
			}
			

		}
	}
}