using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabTask1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String text = textBox1.Text;
            String[] words = text.Split(' ');
            Regex regex1 = new Regex(@"^([\&]{1,2}|[\|]{1,2}|[\!])$");

            for (int i = 0; i < words.Length; i++)
            {
                Match match1 = regex1.Match(words[i]);

                if (match1.Success)
                {
                    textBox2.Text += words[i] + " ";x

                }

                else
                {
                    MessageBox.Show("invalid " + words[i]);
                }
            }

        }
    }
}
