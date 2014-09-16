using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace NancyExample.DomainObjects
{
	[XmlRoot("response")]
	public class SingleTrackResponse : Response
	{
		[XmlElement("track")]
		[DataMember]
		public Track Track { get; set; }
	}
}