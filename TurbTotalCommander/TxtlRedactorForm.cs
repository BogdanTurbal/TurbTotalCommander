using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.LinkLabel;

namespace TurbTotalCommander
{
    public partial class TxtlRedactorForm : Form
    {
        private string path;
        public TxtlRedactorForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        public void LoadFile(TextBasedFile file)
        {
            richTextBox.Text = file.Content;
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Clear();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter(path);
            streamWriter.WriteLine(richTextBox.Text);
            streamWriter.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (clearLines.Checked)
            {
                ClearEmptyLines();
            }
            if (clearTabs.Checked)
            {
                ClearTabs();
            }
        }
        private void ClearEmptyLines()
        {
            Debug.WriteLine("sorry");
            var lines = richTextBox.Text.Split(
                    new string[] { Environment.NewLine , "\n"},
                    StringSplitOptions.None).ToArray();
            Debug.WriteLine(lines.Length);
            richTextBox.Text = StrArrToStr(lines.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray());
        }
        private string StrArrToStr(string[] arr)
        {
            string text = "";
            foreach (string line in arr) text += line + "\n";
            return text;
        }
        private void ClearTabs()
        {
            Debug.WriteLine("Hello!");
            var lines = richTextBox.Text.Split(
                    new string[] { Environment.NewLine, "\n" },
                    StringSplitOptions.None).ToArray();

            richTextBox.Text = StrArrToStr(lines.Select(line => line.Trim(' ', '\t')).ToArray());
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TxtlRedactorForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }
    }
}
