using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurbTotalCommander
{
    public partial class HtmlRedactorForm : Form
    {
        string path = "";
        public HtmlRedactorForm()
        {
            InitializeComponent();
            tegName.PlaceholderText = "enter redundant teg";
        }
        public void LoadFile(string path)
        {
            this.path = path;
            string[] lines = File.ReadAllLines(path);
            string text = "";
            foreach (string line in lines) text += line + "\n";
            richTextBox.Text = text;
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter(path);
            streamWriter.WriteLine(richTextBox.Text);
            streamWriter.Close();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Clear();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            string pattern = "<[ \\n\\s\\t]*" + tegName.Text.Trim() + "[ \\w\\n\\s\\t\"=]*>";
            richTextBox.Text = Regex.Replace(richTextBox.Text, pattern, "");
            string pattern2 = @"</[ \n\s\t]*" + tegName.Text.Trim() + @"[ \n\s\t]*>";
            richTextBox.Text = Regex.Replace(richTextBox.Text, pattern2, "");
        }
    }
}
