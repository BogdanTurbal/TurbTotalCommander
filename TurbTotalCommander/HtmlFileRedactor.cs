using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurbTotalCommander
{
    internal class HtmlFileRedactor : FileRedactor
    {
        private string path;
        public override void LoadFile(string filePath)
        {
            HtmlRedactorForm form = new HtmlRedactorForm();
            path = filePath;
            form.LoadFile(GetFile(filePath));
            form.Show();
        }

        public TextBasedFile GetFile(string path)
        {
            return new TextBasedFile(path);
        }
    }
}
