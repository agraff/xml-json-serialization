using System;
using System.IO;
using System.Reflection;

namespace Test.Common
{
	public static class EmbeddedResource
	{
		public static string GetContent(string resourceName, Type relativeToType)
		{
			var assembly = Assembly.GetAssembly(relativeToType);
			var fullResourceName = String.Format("{0}.{1}", relativeToType.Namespace, resourceName);

			using (var stream = assembly.GetManifestResourceStream(fullResourceName))
			using (var reader = new StreamReader(stream))
			{
				return reader.ReadToEnd();
			}
		}
	}
}