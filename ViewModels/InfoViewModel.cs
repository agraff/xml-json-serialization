using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ViewModels
{
	[XmlRoot("info")]
	[DataContract(Namespace = "info")]
	public class InfoViewModel
	{
		[XmlElement("technology")]
		[DataMember]
		public string Technology { get; set; }
	}
}
