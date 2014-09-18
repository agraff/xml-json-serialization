using System.Runtime.Serialization;
using System.Xml.Serialization;
using ViewModels;

namespace NancyExample.DomainObjects
{
	[XmlRoot("response")]
	public class TracksResponse : Response
	{
		[DataMember]
		[XmlElement("tracks")]
		public TracksViewModel Tracks { get; set; }
	}
}