using System.Runtime.Serialization;

namespace WebApiApplication.DomainObjects
{
	[DataContract(Name = "response")]
	public class TracksResponse : Response
	{
		[DataMember(Name = "tracks")]
		public TracksPage TracksPage { get; set; }
	}
}