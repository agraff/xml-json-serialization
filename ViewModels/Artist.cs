﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Nancy.Json;
using Newtonsoft.Json;

namespace ViewModels
{
	public class Artist
	{
		[XmlAttribute(AttributeName = "id")]
		public int Id { get; set; }

		[XmlElement("name")]
		public string Name { get; set; }

		[XmlElement("appearsAs")]
		public string AppearsAs { get; set; }

		[XmlElement("url")]
		[JsonIgnore]
		public string Url { get; set; }
	}
}
