using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ViewModels
{
	[XmlRoot("release")]
	public class TrackReleaseViewModel
	{
		[XmlAttribute("id")]
		public int Id { get; set; }

		[XmlElement("title")]
		public string Title { get; set; }

		[XmlElement("version")]
		public string Version { get; set; }

		[XmlElement("type")]
		[JsonIgnore]
		public string Type { get; set; }

		[JsonProperty(PropertyName = "type")]
		public string JsonType {
			get { return Type.ToLower(); }
		}

		[XmlElement("barcode")]
		public string Barcode { get; set; }

		[XmlElement("artist")]
		public Artist Artist { get; set; }

		[XmlElement("url")]
		[JsonIgnore]
		public string Url { get; set; }

		[XmlElement("image")]
		public string Image { get; set; }

		[XmlElement("releaseDate")]
		[JsonProperty(PropertyName = "downloadAvailableAfter")]
		public DateTime ReleaseDate { get; set; }
	}
}
