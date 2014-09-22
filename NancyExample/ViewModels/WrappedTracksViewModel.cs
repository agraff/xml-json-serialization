using System.Xml.Serialization;
using NancyExample.Serializers;
using ViewModels;

namespace NancyExample.ViewModels
{
	[XmlRoot("response")]
	public class WrappedTracksViewModel : ResponseViewModel
	{
		[XmlElement("tracks")]
		[JsonRootObject]
		public TracksViewModel Tracks { get; set; }
	}
}