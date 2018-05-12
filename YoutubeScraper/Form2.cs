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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = Youtube.YoutubeSearch(YouTubeOneClick.getgame, textBox1.Text);
            if (url == null) {
                MessageBox.Show("Video not found");
                return;
            }
            string ID = url.Split('=')[1].Split('.')[0];
            string plataforma = YouTubeOneClick.getplataforma;
            Youtube.youtubeAsync(YouTubeOneClick.getgame, ID, plataforma);
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
