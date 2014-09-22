using System.Xml.Serialization;
using SevenDigital.Serialization.Wrapped.WebApi;

namespace ViewModels
{
	[XmlRoot("tracks")]
	public class TracksViewModel : PagedCollectionBase
	{
		[XmlElement("track")]
		public TrackViewModel[] Tracks { get; set; }
	}
}