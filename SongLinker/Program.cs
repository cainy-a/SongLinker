using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace SongLinker
{
	class Program
	{
		static void Main(string[] args)
		{
			string url = null;
			try
			{
				url = args[0];
			}
			catch (Exception)
			{
				// ignored
			}

			if (url == null)
			{
				Console.Write("Enter a URL:");
				url = Console.ReadLine();
			}

			Console.WriteLine(GetShortUrl(url));
		}

		private static string GetShortUrl(string streamingUrl)
		{
			var apiUrl = $"http://api.song.link/v1-alpha.1/links?url={streamingUrl}";
			
			var client = new WebClient();
			var json = client.DownloadString(apiUrl);
			var parsed = (JsonType) JsonSerializer.Deserialize(json, typeof(JsonType), new JsonSerializerOptions());
			return parsed.PageUrl;
		}
	}
}