using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LabTask3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String text = richTextBox1.Text.Trim();
            String[] lines = text.Split('\n');
            runLexer(lines);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String path = textBox1.Text;
            Debug.WriteLine(path);
            if(path == "")
            {
                MessageBox.Show("Please provide a filepath");
                return;
            }

            String[] lines = File.ReadAllLines(path, Encoding.UTF8);
            runLexer(lines);
        }

        private void runLexer(String[] lines)
        {

            this.dataGridView1.Rows.Clear();

            int keywordCount = 0;
            int variableCount = 0;
            int relationalCount = 0;
            int operatorCount = 0;
            int logicalCount = 0;
            int stringCount = 0;
            int floatsCount = 0;
            int powerCount = 0;
            int integersCount = 0;

            Regex keywords = new Regex(@"^(int|string|var|const|let|float|double|char|short|byte|long|bool|if|elif|else|break|return|continue)$");
            Regex variables = new Regex(@"^[A-Za-z][A-Za-z0-9]*$");
            Regex relational = new Regex(@"^(==|!=|(>|<)=?)$");
            Regex operators = new Regex(@"^(\+|-|\*|\/|=)=?$");
            Regex logical = new Regex(@"^(&{1,2}|\|{1,2}|!)$");
            Regex strings = new Regex("^['|\"].*['|\"]$");
            Regex floats = new Regex(@"^(?=.{1,7}$)([0-9]+)[.]([0-9]+)$");
            Regex powers = new Regex(@"^[0-9]+[e][-]?[0-9]+$");
            Regex integers = new Regex(@"^[0-9]+$");

            
            foreach (string line in lines)
            {
                string[] words = line.Split(' ');

                foreach (string word in words)
                {
                    if (keywords.Match(word).Success)
                    {
                        dataGridView1.Rows.Add(new String[] { "Keyword", word });
                        keywordCount++;
                    }
                    else if (variables.Match(word).Success)
                    {
                        dataGridView1.Rows.Add(new String[] { "Variable", word });
                        variableCount++;
                    }
                    else if (logical.Match(word).Success)
                    {
                        dataGridView1.Rows.Add(new String[] { "Logical Operator", word });
                        logicalCount++;
                    }
                    else if (operators.Match(word).Success)
                    {
                        dataGridView1.Rows.Add(new String[] { "Arithemtic Operator", word });
                        operatorCount++;
                    }
                    else if (relational.Match(word).Success)
                    {
                        dataGridView1.Rows.Add(new String[] { "Relational Operator", word });
                        relationalCount++;
                    }
                    else if (strings.Match(word).Success)
                    {
                        dataGridView1.Rows.Add(new String[] { "String Value", word });
                        stringCount++;
                    }
                    else if (floats.Match(word).Success)
                    {
                        dataGridView1.Rows.Add(new String[] { "Float Value", word });
                        floatsCount++;
                    }
                    else if (integers.Match(word).Success)
                    {
                        dataGridView1.Rows.Add(new String[] { "Integer Value", word });
                        integersCount++;
                    }
                    else if (powers.Match(word).Success)
                    {
                        dataGridView1.Rows.Add(new String[] { "Exponent Value", word });
                        powerCount++;
                    }
                    /* else
                     {
                         MessageBox.Show("invalid " + word);
                     }*/
                }
            }
            this.label3.Text = "Keyword Count: " + keywordCount;
            this.label4.Text = "Variable Count: " + variableCount;
            this.label5.Text = "Relational Operator Count: " + relationalCount;
            this.label6.Text = "Arithematic Operator Count: " + operatorCount;
            this.label7.Text = "Logical Operator Count: " + logicalCount;
            this.label8.Text = "String Count: " + stringCount;
            this.label9.Text = "Integer Count: " + integersCount;
            this.label10.Text = "Exponential Count: " + powerCount;
            this.label11.Text = "Float Count: " + floatsCount;

        }
    }
}
