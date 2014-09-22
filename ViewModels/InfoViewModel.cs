using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ViewModels
{
	[XmlRoot("info")]
	public class InfoViewModel
	{
		[XmlElement("technology")]
		[DataMember]
		public string Technology { get; set; }
	}
}
