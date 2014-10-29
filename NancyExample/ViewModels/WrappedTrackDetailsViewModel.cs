using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using ViewModels;

namespace NancyExample.ViewModels
{
	[XmlRoot("response")]
	public class WrappedTrackDetailsViewModel : ResponseViewModel
	{
		[XmlElement("track")]
		public TrackDetailsViewModel Track { get; set; }
	}
}