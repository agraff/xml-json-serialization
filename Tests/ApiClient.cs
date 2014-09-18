using System.Collections.Generic;
using RestSharp;

namespace Tests
{
	public class ApiClient
	{
		private readonly string _apiBaseUrl;

		public ApiClient(string apiBaseUrl)
		{
			_apiBaseUrl = apiBaseUrl;
		}

		public string GetJson(string resourceUri, params Parameter[] parameters)
		{
			return GetResponseContent(resourceUri, parameters, "application/json");
		}

		public string GetXml(string resourceUri, params Parameter[] parameters)
		{
			return GetResponseContent(resourceUri, parameters, "application/xml");
		}

		private string GetResponseContent(string resourceUri, IEnumerable<Parameter> parameters, string acceptType)
		{
			var client = new RestClient(_apiBaseUrl);
			var request = new RestRequest(resourceUri, Method.GET);

			foreach (var parameter in parameters)
			{
				request.AddParameter(parameter.Name, parameter.Value);
			}
			request.AddHeader("Accept", acceptType);

			var response = client.Execute(request);
			return response.Content;
		}
	}
}