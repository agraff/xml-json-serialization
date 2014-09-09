using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Web;

namespace XmlJsonSerialization
{
	public class HttpRequest : IDisposable
	{
		private HttpWebResponse _response;

		public HttpRequest(string url, params object[] args)
			: this(string.Format(url, args))
		{
		}

		public HttpRequest(string url)
		{
			// Allow invalid, ie self-generated certs
			ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

			try
			{
				Base = (HttpWebRequest)WebRequest.Create(url);
			}
			catch (UriFormatException)
			{
				Console.WriteLine("Invalid url - {0}", url);
				throw;
			}

			Headers = new NameValueCollection();
			Method = "GET";
			Encoding = Encoding.UTF8;
		}

		public string Method
		{
			get { return Base.Method; }
			set { Base.Method = value; }
		}

		public Encoding Encoding { get; set; }
		public HttpWebRequest Base { get; private set; }
		public string Body { get; set; }
		public NameValueCollection Headers { get; set; }

		public HttpResponse Send()
		{
			// Set the headers first before the body otherwise they get wiped
			foreach (string key in Headers)
			{
				switch (key.ToLower())
				{
					// Bloody .Net and its restricted headers
					case "accept":
						Base.Accept = Headers[key];
						break;
					case "content-type":
						Base.ContentType = Headers[key];
						break;
					case "if-modified-since":
						Base.IfModifiedSince = DateTime.Parse(Headers[key]);
						break;
					case "host":
						Base.Host = Headers[key];
						break;
					default:
						Base.Headers.Add(key, Headers[key]);
						break;
				}
			}

			if (Method == "POST" || Method == "PUT")
				Base.ContentLength = 0;

			if (!string.IsNullOrEmpty(Body))
			{
				var bytes = Encoding.GetBytes(Body);

				Base.ContentLength = bytes.Length;

				using (var stream = Base.GetRequestStream())
				{
					stream.Write(bytes, 0, bytes.Length);
				}
			}

			Console.WriteLine("{0} - {1}", Base.Method, Base.RequestUri);

			foreach (string key in Headers)
				Console.WriteLine("{0}: {1}", key, Headers[key]);

			try
			{
				_response = (HttpWebResponse)Base.GetResponse();
			}
			catch (WebException e)
			{
				_response = (HttpWebResponse)e.Response;
			}

			return new HttpResponse(_response);
		}

		public void Dispose()
		{
			if (_response != null)
				_response.Close();
		}
	}
}
