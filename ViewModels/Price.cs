using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ViewModels
{
	public class Price
	{
		[XmlElement("currency")]
		public CurrencyResource Currency { get; set; }

		[XmlElement("value", IsNullable = true)]
		public string Value { get; set; }

		[XmlElement("formattedPrice")]
		public string FormattedPrice { get; set; }

		[XmlElement("rrp", IsNullable = true)]
		public string Rrp { get; set; }

		[XmlElement("formattedRrp")]
		public string FormattedRrp { get; set; }

		[XmlElement("onSale")]
		public bool OnSale { get; set; }
	}

	public class CurrencyResource
	{
		[XmlAttribute("code")]
		public string Code { get; set; }

		[XmlText]
		public string Symbol { get; set; }
	}
}
