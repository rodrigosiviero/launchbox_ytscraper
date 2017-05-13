using System;
using System.Windows.Forms;

namespace YoutubeScraper
{
    public partial class Form1 : Form 
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            string id = url.Split('=')[1].Split('.')[0];
            Youtube.youtubeAsync(YoutubeLink.getgame,id,YoutubeLink.getplataforma);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
