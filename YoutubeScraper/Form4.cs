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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            int pFrom = url.IndexOf("/app/") + "/app/".Length;
            int pTo = url.LastIndexOf("/");
            String result = url.Substring(pFrom, pTo - pFrom);
            Console.WriteLine(result);
        }
    }
}
