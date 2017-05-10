using System;
using System.IO;
using System.Linq;
using System.Reflection;
using YoutubeExplode;
using YoutubeExplode.Models;
using YoutubeSearch;

namespace YoutubeScraper
{

    class Youtube
    {
        private static string firstVideo;

        public static async void youtubeAsync(String game, String id, String plataforma)
        {
            String path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var client = new YoutubeClient();
            var videoInfo = await client.GetVideoInfoAsync(id);
            // Select the highest quality mixed stream
            var streamInfo = videoInfo.MixedStreams.OrderBy(s => s.VideoQuality).Last();
            // Download it to file
            string fileExtension = streamInfo.Container.GetFileExtension();
            foreach (var c in Path.GetInvalidFileNameChars()) { game = game.Replace(c, ' '); }
            string fileName = $"{game}.{fileExtension}";
            using (var input = await client.GetMediaStreamAsync(streamInfo))
            using (var output = File.Create(Path.Combine(path, "videos", plataforma, fileName)))
            //using (var output = File.Create(path + @"/videos/" + plataforma + "/" + fileName))
                await input.CopyToAsync(output);
        }

        public static String YoutubeSearch(string query)
        {
            // Keyword
            string querystring = query + "trailer";

            // Number of result pages
            int querypages = 1;

            var items = new VideoSearch();
            foreach (var item in items.SearchQuery(querystring, querypages))
            {
                firstVideo = item.Url;
                break;
            }
            return firstVideo;
        }
    }
}
