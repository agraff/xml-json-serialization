using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ViewModels
{
	public class Format
	{
		[XmlAttribute(AttributeName = "id")]
		public int Id { get; set; }

		[XmlElement("fileFormat")]
		public string FileFormat { get; set; }

		[XmlElement("bitRate")]
		public int BitRate { get; set; }

		[XmlElement("drmFree")]
		public bool DrmFree { get; set; }

	}
}
