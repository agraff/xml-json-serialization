using System.Xml.Serialization;
using ViewModels;

namespace NancyExample.DomainObjects
{
	[XmlRoot("response")]
	public class WrappedTrackViewModel : ResponseViewModel
	{
		[XmlElement("track")]
		public TrackViewModel Track { get; set; }
	}
}