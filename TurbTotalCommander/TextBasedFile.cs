using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurbTotalCommander
{
    public class TextBasedFile : AbsFile
    {
        public TextBasedFile(string path)
        {
            this.Path = path;
            LoadContent();
        }

        private void LoadContent()
        {
            string[] lines = File.ReadAllLines(this.Path);
            string text = "";
            foreach (string line in lines) text += line + "\n";
            this.Content = text;
        }
    }
}
