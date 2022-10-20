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

namespace Lab3GradedTask3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();

            String text = richTextBox1.Text;
            String[] lines = text.Split('\n');
            Regex matchStarting = new Regex(@"^[t|m][A-Za-z]+$");

            foreach (string line in lines)
            {
                string[] words = line.Split(' ');

                foreach (string word in words)
                {
                    if (matchStarting.Match(word).Success)
                    {
                        dataGridView1.Rows.Add(word);
                    }
                
                }
            }
        }
    }
}
