using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApiApplication.DomainObjects
{
	[XmlRoot("response")]
	public class SingleTrackResponse
	{
		[XmlElement("track")]
		public Track Track { get; set; }
	}
}