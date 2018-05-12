using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoutubeScraper
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in YouTubeOneClick.getgames)
            {
                if (item.GetVideoPath() == null)
                {
                    string url = Youtube.YoutubeSearch(item.Title, textBox1.Text);
                    string ID = url.Split('=')[1].Split('.')[0];
                    string plataforma = item.Platform;
                    Youtube.youtubeAsync(item.Title, ID, plataforma);
                }
                this.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
