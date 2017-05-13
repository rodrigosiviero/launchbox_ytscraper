using System;
using System.Linq;
using System.Windows.Forms;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;

namespace YoutubeScraper
{
    class YouTubeOneClick : IGameMenuItemPlugin
    {
        public static string VideoAlreadyDownload { get; set; }
        public bool SupportsMultipleGames
        {
            get { return true; }
        }

        public string Caption
        {
            get { return "Youtube OneClick Download"; }
        }

        public System.Drawing.Image IconImage
        {
            get { return null; }
        }

        public bool ShowInLaunchBox
        {
            get { return true; }
        }

        public bool ShowInBigBox
        {
            get { return false; }
        }

        public static object Configs { get; private set; }

        public bool GetIsValidForGame(IGame selectedGame)
        {
            return !string.IsNullOrEmpty(selectedGame.Platform);
        }

        public bool GetIsValidForGames(IGame[] selectedGames)
        {
            return selectedGames.Any(g => !string.IsNullOrEmpty(g.Platform));
        }

        public void OnSelected(IGame selectedGame)
        {
            if (selectedGame.GetVideoPath() != null)
            {
                MessageBox.Show("Video for selected game already exists.");
            }
            else
            {
                string url = Youtube.YoutubeSearch(selectedGame.Title);
                string ID = url.Split('=')[1].Split('.')[0];
                string plataforma = selectedGame.Platform;
                Youtube.youtubeAsync(selectedGame.Title, ID, plataforma);
            }

        }

        public void OnSelected(IGame[] selectedGames)
        {
            
            foreach (var item in selectedGames)
            {
                if (item.GetVideoPath() == null)
                {
                    string url = Youtube.YoutubeSearch(item.Title);
                    string ID = url.Split('=')[1].Split('.')[0];
                    string plataforma = item.Platform;
                    Youtube.youtubeAsync(item.Title, ID, plataforma);
                }
            }
        }
    }
}
