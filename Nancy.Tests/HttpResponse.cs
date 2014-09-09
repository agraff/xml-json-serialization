using System.Collections.Specialized;
using System.IO;
using System.Net;

namespace XmlJsonSerialization
{
	public class HttpResponse
	{
		public HttpResponse(HttpWebResponse response)
		{
			Base = response;
			Headers = Base.Headers;

			using (var stream = Base.GetResponseStream())
			{
				if (stream != null)
					Body = new StreamReader(stream).ReadToEnd();
			}
		}

		public int StatusCode
		{
			get { return (int)Base.StatusCode; }
		}

		public HttpWebResponse Base { get; private set; }
		public string Body { get; private set; }
		public NameValueCollection Headers { get; private set; }
	}
}