using System.Xml.Serialization;
using ViewModels;

namespace NancyExample.DomainObjects
{
	[XmlRoot("response")]
	public class SingleTrackResponse : Response
	{
		[XmlElement("track")]
		public Track Track { get; set; }
	}
}