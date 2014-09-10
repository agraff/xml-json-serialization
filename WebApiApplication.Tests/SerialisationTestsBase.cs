using System;

namespace WebApiApplication.Tests
{
	public class SerialisationTestsBase
	{
		private string _content;
		protected string Content
		{
			get { return _content; }
			set
			{
				_content = value;
				PrintContent();
			}
		}

		public void PrintContent()
		{
			Console.WriteLine("--- Begin Content ---");
			Console.WriteLine(Content ?? "NULL");
			Console.WriteLine("---- End Content ----");
		}
	}
}