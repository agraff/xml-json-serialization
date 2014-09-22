using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SevenDigital.Serialization.Wrapped.WebApi
{
	public class PagedCollectionBase
	{
		[XmlElement("page")]
		[JsonProperty(Order = -4)]
		public int Page { get; set; }

		[XmlElement("pageSize")]
		[JsonProperty(Order = -3)]
		public int PageSize { get; set; }

		[XmlElement("totalItems")]
		[JsonProperty(Order = -2)]
		public int TotalItems { get; set; }
	}
}
