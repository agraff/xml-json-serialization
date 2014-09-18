using System.Runtime.Serialization;
using System.Xml.Serialization;
using ViewModels;

namespace NancyExample.DomainObjects
{
	[XmlRoot("response")]
	public class WrappedTracksViewModel : ResponseViewModel
	{
		[DataMember]
		[XmlElement("tracks")]
		public TracksViewModel Tracks { get; set; }
	}
}