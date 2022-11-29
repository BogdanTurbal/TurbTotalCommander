using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using static TurbTotalCommander.FileManager;

namespace TurbTotalCommander
{
    public partial class MainForm : Form
    {
        private List<DriveInfo> drives;
        private DriveInfo currentLeftDriver;
        private DriveInfo currentRightDriver;

        private FileManager.Filter currentLeftFilter;
        private FileManager.Filter currentRightFilter;

        readonly int INITIAL_SEARCH_DEPTH = 4;

        string saved_path = "";
        private ListView currentListView;
        private TreeView currentTree;
        //private TreeNode currentLeftNode;
        //private TreeNode currentRightNode;
        public MainForm()
        {
            InitializeComponent();
            InitializeDriversList();
            InitializeFiltersComboBox();
            InitializeViews();
            currentListView = leftListView;
        }

        void InitializeViews()
        {
            FillDirectoryTree(leftTreeView, currentLeftDriver.Name);
            FillDirectoryTree(rightTreeView, currentRightDriver.Name);

            leftTreeView.ImageList = this.imageList;
            rightTreeView.ImageList = this.imageList;

            leftDepthSearch.Text = INITIAL_SEARCH_DEPTH.ToString();
            rightDepthSearch.Text = INITIAL_SEARCH_DEPTH.ToString();

            leftPatternSearch.PlaceholderText = "Search pattern";
            rightPatternSearch.PlaceholderText = "Search pattern";

            leftDepthSearch.PlaceholderText = "Depth of search";
            rightDepthSearch.PlaceholderText = "Depth of search";

            leftListView.MultiSelect = false;
            rightListView.MultiSelect = false;
        }
        //methods
        private void InitializeDriversList()
        {
            drives = DriveInfo.GetDrives().ToList();
            currentLeftDriver = drives[0];

            int rightIndex = (drives.Count > 1) ? 1 : 0;
            currentRightDriver = drives[rightIndex];

            leftDriversComboBox.Items.Clear();
            var arrDrivers = drives.Select(x => x.Name).ToArray();

            leftDriversComboBox.Items.AddRange(arrDrivers);
            leftDriversComboBox.SelectedItem = leftDriversComboBox.Items[0];

            rightDriversComboBox.Items.AddRange(arrDrivers);
            rightDriversComboBox.SelectedItem = leftDriversComboBox.Items[rightIndex];
        }
        private void InitializeFiltersComboBox()
        {
            List<string> filters = new List<string>();
            var namesOfFilters = FileManager.nameToFilter.Select(par => par.Key).ToArray();

            leftTypesComboBox.Items.Clear();
            leftTypesComboBox.Items.AddRange(namesOfFilters);

            rightTypesComboBox.Items.Clear();
            rightTypesComboBox.Items.AddRange(namesOfFilters);


            //currentLeftNode = this.leftTreeView.TopNode;
            //currentRightNode = this.rightTreeView.TopNode;
        }
        private void FillDirectoryTree(TreeView treeView, string dir)
        {
            treeView.Nodes.Clear();
            TreeNode treeNode = new TreeNode(dir);
            DirectoryInfo dirInf = new DirectoryInfo(dir);
            treeNode.Tag = dirInf;
            treeView.Nodes.Add(treeNode);

            FillTreeNodes(treeNode);
            treeView.SelectedNode = treeNode;
        }
        private void FillTreeNodes(TreeNode treeNode)
        {
            string dir = treeNode.FullPath;
            foreach (DirectoryInfo di in FileManager.GetAllAccessibleDirectories(dir))
            {
                TreeNode child = new TreeNode(di.Name);
                child.Tag = di;
                child.ImageIndex = 0;
                //FillTreeNodes(child, di, level + 1);
                treeNode.Nodes.Add(child);

            }
        }
        private void FillBeforeExpand(TreeNode treeNode)
        {
            string path = treeNode.FullPath;
            foreach (TreeNode nd in treeNode.Nodes)
            {
                FillTreeNodes(nd);
            }
        }
        private void FillAllFiles(ListView listView, TreeNode treeNode, FileManager.Filter filter)
        {
            string path = treeNode.FullPath;
            FillListView(FileManager.GetAllAccessibleFiles(path, filter), listView);
        }
        private void FillListView(List<FileInfo> fileInfos, ListView listView)
        {
            listView.Items.Clear();
            listView.LargeImageList = this.imageList;
            foreach (var file in fileInfos)
            {
                var listEl = new ListViewItem(file.Name)
                {
                    ImageIndex = 1,
                    Tag = file,
                };
                listView.Items.Add(listEl);
            }
        }
        void SearchKeyDown(KeyEventArgs e, TextBox depthSearch, TreeView treeView, Filter filter, TextBox pattern)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int number = INITIAL_SEARCH_DEPTH;
                if (!Int32.TryParse(depthSearch.Text, out number))
                {
                    depthSearch.Text = number.ToString();
                }
                var files = FileManager.SearchFiles(treeView.SelectedNode.FullPath, filter, pattern.Text, number);
                FillListView(files, leftListView);
            }
        }
        void LoadFile(string path)
        {
            string fileExt = System.IO.Path.GetExtension(path);

            if (fileExt == ".txt")
            {
                LoadTextRedactor(path);
            }
            else if (fileExt == ".html")
            {
                LoadHtmlRedactor(path);
            }
            else
            {
                MessageBox.Show("Unsupported format!");
            }
        }
        void LoadTextRedactor(string path)
        {
            TxtlRedactorForm htmlRedactorForm = new TxtlRedactorForm();
            htmlRedactorForm.Show();
            htmlRedactorForm.LoadFile(path);
        }
        void LoadHtmlRedactor(string path)
        {
            HtmlRedactorForm htmlRedactorForm = new HtmlRedactorForm();
            htmlRedactorForm.Show();
            htmlRedactorForm.LoadFile(path);
        }
        //Tree events handlers
        private void leftTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node != null) FillBeforeExpand(e.Node);
        }
        private void leftTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e != null && e.Node != null)
            {
                FillAllFiles(leftListView, e.Node, currentLeftFilter);
            }
        }
        private void rightTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node != null) FillBeforeExpand(e.Node);
        }
        private void rightTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e != null && e.Node != null) FillAllFiles(rightListView, e.Node, currentRightFilter);
        }
        //Drivers events
        private void leftDriversComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDirectoryTree(leftTreeView, drives[leftDriversComboBox.SelectedIndex].Name);
        }
        private void rightDriversComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDirectoryTree(rightTreeView, drives[rightDriversComboBox.SelectedIndex].Name);
        }
        //Choosing types events
        private void rightTypesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentRightFilter = FileManager.nameToFilter[rightTypesComboBox.SelectedItem.ToString()];
            FillAllFiles(rightListView, rightTreeView.SelectedNode, currentRightFilter);
        }
        private void leftTypesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentLeftFilter = FileManager.nameToFilter[leftTypesComboBox.SelectedItem.ToString()];
            FillAllFiles(leftListView, leftTreeView.SelectedNode, currentLeftFilter);
        }
        //Pattern events
        private void leftPatternSearch_KeyDown(object sender, KeyEventArgs e)
        {
            SearchKeyDown(e, leftDepthSearch, leftTreeView, currentLeftFilter, leftPatternSearch);
        }
        private void rightPatternSearch_KeyDown(object sender, KeyEventArgs e)
        {
            SearchKeyDown(e, rightDepthSearch, rightTreeView, currentRightFilter, rightPatternSearch);
        }
        private void KeyDownU(TreeView treeView, ListView listView, FileManager.Filter filter, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                saved_path = Path.Combine(treeView.SelectedNode.FullPath, listView.SelectedItems[0].Text);
            }
            if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control && saved_path != "")
            {
                string new_path = Path.Combine(treeView.SelectedNode.FullPath, Path.GetFileName(saved_path));
                if (File.Exists(new_path))
                {
                    var result = MessageBox.Show("Rename copy? (yes - new_name = old_name + _1, no - replase)", "File already exist", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        while (File.Exists(new_path))
                        {
                            string directory = new FileInfo(new_path).Directory.FullName;
                            string new_name = Path.GetFileNameWithoutExtension(new_path) + "_1" + Path.GetExtension(new_path);
                            new_path = Path.Combine(directory, new_name);
                        }
                        FileManager.CopyFile(saved_path, new_path);
                    }
                    else if (result == DialogResult.No)
                    {
                        FileManager.CopyFile(saved_path, new_path);
                    }
                }
                else
                {
                    FileManager.CopyFile(saved_path, new_path);
                }
                FillAllFiles(listView, treeView.SelectedNode, filter);
            }
            if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control && leftListView.SelectedItems.Count > 0)
            {
                FileManager.DeleteFile(Path.Combine(leftTreeView.SelectedNode.FullPath, leftListView.SelectedItems[0].Text));
                FillAllFiles(listView, treeView.SelectedNode, filter);
            }
        }
        private void leftListView_DoubleClick(object sender, EventArgs e)
        {
            if (leftListView.SelectedItems.Count == 1)

            {
                string leftPath = Path.Combine(leftTreeView.SelectedNode.FullPath, leftListView.SelectedItems[0].Text);
                LoadFile(leftPath);
            }
        }
        private void rightListView_DoubleClick(object sender, EventArgs e)
        {
            if (rightListView.SelectedItems.Count == 1)

            {
                string rightPath = Path.Combine(rightTreeView.SelectedNode.FullPath, rightListView.SelectedItems[0].Text);
                LoadFile(rightPath);
            }
        }
        private void leftTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void leftListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void leftListView_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownU(currentTree, currentListView, currentLeftFilter, e);
        }

        private void rightListView_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownU(currentTree, currentListView, currentRightFilter, e);
        }

        private void rightListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rightListView_Click(object sender, EventArgs e)
        {
            currentListView = rightListView;
            currentTree = rightTreeView;
        }

        private void leftListView_Click(object sender, EventArgs e)
        {
            
        }


        private void leftListView_MouseDown(object sender, MouseEventArgs e)
        {
            currentListView = leftListView;
            currentTree = leftTreeView;
        }

        private void rightListView_MouseDown(object sender, MouseEventArgs e)
        {
            currentListView = rightListView;
            currentTree = rightTreeView;
        }

        private void CreateClick(TreeView treeView, TextBox pattern, ListView listView, FileManager.Filter filter)
        {
            string new_path = Path.Combine(treeView.SelectedNode.FullPath, pattern.Text);
            if (File.Exists(new_path))
            {
                var result = MessageBox.Show("File will be overrided, continue?", "File already exist", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    FileManager.DeleteFile(new_path);
                    FileManager.CreateFile(new_path);
                }
            }
            else
            {
                FileManager.CreateFile(new_path);
            }
            pattern.Text = "";
            FillAllFiles(listView, treeView.SelectedNode, filter);
        }
        private void leftCreate_Click(object sender, EventArgs e)
        {
            CreateClick(leftTreeView, leftPatternSearch, leftListView, currentLeftFilter);
        }

        private void rightCreate_Click(object sender, EventArgs e)
        {
            CreateClick(rightTreeView, rightPatternSearch, rightListView, currentRightFilter);
        }
    }
}