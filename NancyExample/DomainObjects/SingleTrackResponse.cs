using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace NancyExample.DomainObjects
{
	public class SingleTrackResponse : Response
	{
		public Track Track { get; set; }
	}
}