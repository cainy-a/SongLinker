using System.Text.Json.Serialization;

namespace SongLinker
{
	public class JsonType
	{
		[JsonPropertyName("pageUrl")]
		public string PageUrl { get; set; }
	}
}