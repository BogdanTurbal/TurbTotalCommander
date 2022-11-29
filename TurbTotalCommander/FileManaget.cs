using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TurbTotalCommander.FileManager;

namespace TurbTotalCommander
{
    internal class FileManager
    {
        public enum Filter
        {
            NONE,
            HTML,
            TXT
        }
        readonly static Dictionary<Filter, string> filterToType =
            new Dictionary<Filter, string>()
            {
                {Filter.NONE, "*.*"},
                {Filter.HTML, "*.html"},
                {Filter.TXT, "*.txt" }
            };
        public static Dictionary<string, Filter> nameToFilter =
            new Dictionary<string, Filter>()
            {
                {"All files (*.*)", Filter.NONE},
                {"HTML files (*.html)", Filter.HTML},
                {"TXT files (*.txt)", Filter.TXT}
            };
        public static List<DirectoryInfo> GetAllAccessibleDirectories(string path)
        {
            List<DirectoryInfo> list = new List<DirectoryInfo>();
            try
            {
                var directories = System.IO.Directory.GetDirectories(path);
                foreach (string s in directories)
                {
                    try
                    {
                        list.Add(new DirectoryInfo(s));
                    }
                    catch { }
                }
            }
            catch{ }
            return list;
            
        }

        public static List<FileInfo> GetAllAccessibleFiles(string path, Filter filter)
        {
            List<FileInfo> list = new List<FileInfo>();
            try
            {
                var dirInf = new DirectoryInfo(path);
                list = dirInf.GetFiles(filterToType[filter]).ToList();
            }
            catch { }
            return list;

        }

        public static List<FileInfo> SearchFiles(string path, Filter filter, string namePatt, int maxDepth)
        {
            List<FileInfo> list = new List<FileInfo>();
            try
            {
                SearchReacur(list, filter, 0, maxDepth, namePatt, path);
            }
            catch { }
            return list;

        }

        public static void SearchReacur(List<FileInfo> list, Filter filter, int depth, int maxDepth, string namePatt, string path)
        {
            if (depth > maxDepth) return;
            var dirInf = new DirectoryInfo(path);
            list.AddRange(dirInf.GetFiles(filterToType[filter]).Where(f => f.Name.Contains(namePatt, StringComparison.OrdinalIgnoreCase)).ToList());

            var directories = System.IO.Directory.GetDirectories(path);
            foreach (string s in directories)
            {
                try
                {
                    SearchReacur(list, filter, depth + 1, maxDepth, s, namePatt);
                }
                catch { }
            }
        }

        public static void CopyFile(string from, string to)
        {
            if (new FileInfo(from).FullName == new FileInfo(to).FullName) return;
            if (File.Exists(to))
            {
                File.Replace(from, to, to + ".bak");
            }
            else
            {
                File.Copy(from, to, true);
            }
            
        }

        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }

        public static void CreateFile(string path)
        {
            File.Create(path);
        }

    }
}
