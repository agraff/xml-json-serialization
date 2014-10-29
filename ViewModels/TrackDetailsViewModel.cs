using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ViewModels
{
	public class TrackDetailsViewModel
	{

		public TrackDetailsViewModel()
		{
			Type = TrackType.Audio.ToString().ToLower();
			Formats = new FormatList();
		}


		[XmlAttribute(AttributeName = "id")]
		[JsonProperty(Order = 0)]
		public int Id { get; set; }

		[XmlElement(ElementName = "title")]
		[JsonProperty(Order = 1)]
		public string Title { get; set; }

		[XmlElement(ElementName = "version")]
		[JsonProperty(Order = 2)]
		public string Version { get; set; }

		[XmlElement(ElementName = "artist")]
		[JsonProperty(Order = 3)]
		public Artist Artist { get; set; }

		/// <summary>
		/// ie 02
		/// </summary>
		[XmlElement(ElementName = "trackNumber")]
		[JsonIgnore]
		public int TrackNumber { get; set; }

		[XmlElement(ElementName = "duration")]
		[JsonProperty(Order = 4)]
		public int Duration { get; set; }

		[XmlElement(ElementName = "explicitContent")]
		[JsonProperty(PropertyName = "explicitContent", Order = 5)]
		public bool IsExplicit { get; set; }

		[XmlElement(ElementName = "isrc")]
		[JsonProperty(Order = 6)]
		public string Isrc { get; set; }

		[XmlIgnore]
		[JsonIgnore]
		public int TypeId { get; set; }

		[XmlElement(ElementName = "type")]
		[JsonProperty(Order = 7)]
		public string Type { get; set; }

		[XmlElement("release")]
		[JsonProperty(Order = 8)]
		public TrackReleaseViewModel Release { get; set; }

		[XmlElement("url")]
		[JsonProperty(PropertyName = "purchaseUrl", Order = 9)]
		public string Url { get; set; }

		[XmlElement("price")]
		[JsonIgnore]
		public Price Price { get; set; }

		[XmlElement("streamingReleaseDate", IsNullable = true)]
		[JsonProperty(PropertyName = "streamingAvailableAfter", Order = 10)]
		public DateTime? StreamingReleaseDate { get; set; }

		[XmlElement("discNumber")]
		[JsonProperty(PropertyName = "discNumber", Order = 12)]
		public int? DiscNumber { get; set; }

		[XmlIgnore]
		[JsonIgnore]
		public bool IsBundleOnly { get; set; }

		[XmlIgnore]
		[JsonIgnore]
		public int Status { get; set; }

		[JsonIgnore]
		public bool Active
		{
			get { return Status == 1; }
		}


		[XmlElement("formats")]
		[JsonProperty(Order = 13)]
		[JsonIgnore]
		public FormatList Formats { get; set; }

		/// <summary>
		/// ie 302 (3 is disc, 02 is track number
		/// </summary>
		[XmlElement(ElementName = "number")]
		[JsonProperty(PropertyName = "trackNumber", Order =13)]
		public int Number { get; set; }

		[XmlElement("previewDate")]
		[JsonProperty(PropertyName = "previewAvailableAfter", Order=11)]
		public DateTime PreviewDate { get; set; }

		[XmlElement("download")]
		[JsonProperty(Order = 14)]
		public Download Download { get; set; }

	}

	public class FormatList
	{
		public FormatList()
		{
			Formats = new List<Format>();
		}

		[XmlAttribute(AttributeName = "availableDrmFree")]
		[JsonProperty(Order = 15)]
		public bool AvailableDrmFree { get; set; }

		[XmlElement("format")]
		[JsonProperty(Order = 16)]
		public List<Format> Formats { get; set; }
	}


}
