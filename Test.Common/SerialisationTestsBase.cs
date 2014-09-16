using System;

namespace Test.Common
{
	public class SerialisationTestsBase
	{
		public ApiClient Client { get; set; }
		public Parameter Parameter { get; set; }
	
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