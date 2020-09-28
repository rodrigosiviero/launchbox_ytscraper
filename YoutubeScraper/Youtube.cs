using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using YoutubeSearch;

namespace YoutubeScraper
{

    class Youtube
    {
        private static string firstVideo;
        static TimeSpan t1;
        static TimeSpan tsDuration;

        public static async void youtubeAsync(String game, String id, String plataforma)
        {
            String path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var client = new YoutubeClient();
            //var videoInfo = await client.GetVideoInfoAsync(id);
            var video = await client.Videos.Streams.GetManifestAsync(id);
            var streamInfoSet = video.GetMuxed().WithHighestVideoQuality();
            // Download it to file
            string fileExtension = streamInfoSet.Container.Name;
            foreach (var c in Path.GetInvalidFileNameChars()) { game = game.Replace(c, ' '); }
            string fileName = $"{game}.{fileExtension}";
            var output_file = Path.Combine(path, "videos", plataforma, fileName);
            if (streamInfoSet != null)
            {
                await client.Videos.Streams.DownloadAsync(streamInfoSet, output_file);
            }
            //using (var input = await client.GetMediaStreamAsync(streamInfo))
            //using (var output = File.Create(Path.Combine(path, "videos", plataforma, fileName)))
            //using (var output = File.Create(path + @"/videos/" + plataforma + "/" + fileName))
            // await input.CopyToAsync(output);
        }

        public static String YoutubeSearch(string query, string word)
        {
            // Keyword
            string querystring = query + ' ' + word;

            // Number of result pages
            int querypages = 1;

            var items = new VideoSearch();
            foreach (var item in items.SearchQuery(querystring, querypages))
            {
                var dur = item.Duration;
                t1 = TimeSpan.Parse("00:05:00");
                if (dur.Length <= 5)
                {
                    dur = "00:" + dur;
                    tsDuration = TimeSpan.ParseExact(dur, "c", CultureInfo.InvariantCulture);
                }
                else if (dur.Length == 7)
                {
                    tsDuration = TimeSpan.ParseExact(dur, "c", CultureInfo.InvariantCulture);
                }
                else {
                    continue;
                }
                if (tsDuration <= t1)
                {
                    firstVideo = item.Url;
                    break;
                }
            }
            return firstVideo;
        }
    }
}
