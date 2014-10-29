using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ViewModels
{
	public class Download
	{
		[XmlArray("packages")]
		[XmlArrayItem("package")]
		public List<PackageResponse> Packages { get; set; }
	}

	public class PackageResponse
	{
		[XmlAttribute("id")]
		public int Id { get; set; }

		[XmlElement("description")]
		public string Description { get; set; }

		[XmlElement("price")]
		public PackagePriceResponse Price { get; set; }

		[XmlArray("formats")]
		[XmlArrayItem("format")]
		public List<PackageFormat> Formats { get; set; }
	}

	public class PackageFormat
	{
		[XmlAttribute("id")]
		public int Id { get; set; }

		[XmlElement("description")]
		public string Description { get; set; }
	}

	public class PackagePriceResponse
	{
		[XmlElement("currencyCode")]
		public string CurrencyCode { get; set; }

		[XmlElement("sevendigitalPrice", IsNullable = true)]
		public decimal? SevendigitalPrice { get; set; }

		[XmlElement("recommendedRetailPrice", IsNullable = true)]
		public decimal? RecommendedRetailPrice { get; set; }
	}
}
