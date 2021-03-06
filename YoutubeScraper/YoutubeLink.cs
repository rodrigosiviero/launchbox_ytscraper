﻿using System;
using System.Linq;
using System.Windows.Forms;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;
using YoutubeScraper.Properties;

namespace YoutubeScraper
{
    class YoutubeLink : IGameMenuItemPlugin
    {
        public static string getplataforma { get; set; }
        public static string getgame { get; set; }
        public bool SupportsMultipleGames
        {
            get { return false; }
        }

        public string Caption
        {
            get { return "Youtube URL Scraper"; }
        }

        public System.Drawing.Image IconImage
        {
            get { return Resources.youtube; }
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
            getplataforma = selectedGame.Platform;   
            getgame = selectedGame.Title;
            if (selectedGame.GetVideoPath() != null)
            {
                MessageBox.Show("Video for selected game already exists.");
            }
            else
            {
                Form1 frm = new Form1();
                frm.Show();
            }
        }

        public void OnSelected(IGame[] selectedGames)
        {
            throw new NotImplementedException();
        }
    }

}