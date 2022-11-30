using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.DataFormats;
using static TurbTotalCommander.FileManager;

namespace TurbTotalCommander
{
    public partial class MainForm : Form
    {
        private List<DriveInfo> drives;

        private FileManager.Filter currentLeftFilter;
        private FileManager.Filter currentRightFilter;
        readonly int INITIAL_SEARCH_DEPTH = 4;

        string saved_path = "";
        string saved_directory_path = "";
        private ListView currentListView;
        private TreeView currentTree;
        private readonly int INF_DEPTH = 255;
        public MainForm()
        {
            InitializeComponent();
            InitializeDriversList();
            InitializeFiltersComboBox();
            InitializeViews();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            currentListView = leftListView;
        }

        void InitializeViews()
        {
            TreeHandler.FillDirectoryTree(leftTreeView, leftDriversComboBox.Text);
            leftTreeView.SelectedNode = leftTreeView.TopNode;
            TreeHandler.FillDirectoryTree(rightTreeView, rightDriversComboBox.Text);
            rightTreeView.SelectedNode = rightTreeView.TopNode;

            leftTreeView.ImageList = rightTreeView.ImageList = this.imageList;
            leftDepthSearch.Text = rightDepthSearch.Text = INITIAL_SEARCH_DEPTH.ToString();

            leftPatternSearch.PlaceholderText = rightPatternSearch.PlaceholderText = "Search pattern";
            leftDepthSearch.PlaceholderText = rightDepthSearch.PlaceholderText = "Depth of search";

            leftListView.MultiSelect = rightListView.MultiSelect = false;

            currentRightFilter = FileManager.Filter.NONE;
            currentLeftFilter = FileManager.Filter.NONE;
        }
        private void InitializeDriversList()
        {
            var drives = FileManager.GetDrivers();
            leftDriversComboBox.Items.AddRange(drives);
            leftDriversComboBox.SelectedItem = leftDriversComboBox.Items[0];
            rightDriversComboBox.Items.AddRange(drives);
            rightDriversComboBox.SelectedItem = leftDriversComboBox.Items[drives.Length > 1 ? 1 : 0];
        }
        private void InitializeFiltersComboBox()
        {
            List<string> filters = new List<string>();
            var namesOfFilters = FileManager.nameToFilter.Select(par => par.Key).ToArray();
            leftTypesComboBox.Items.Clear();
            leftTypesComboBox.Items.AddRange(namesOfFilters);
            rightTypesComboBox.Items.Clear();
            rightTypesComboBox.Items.AddRange(namesOfFilters);
        }
        
        private void UpdateFiles()
        {
            if(leftTreeView.SelectedNode == null) leftTreeView.SelectedNode = leftTreeView.Nodes[0];
            FileManager.Filter filter = FileManager.Filter.NONE;
            if (leftTypesComboBox.SelectedItem != null && FileManager.nameToFilter.ContainsKey(leftTypesComboBox.SelectedItem.ToString())){
                filter = FileManager.nameToFilter[leftTypesComboBox.SelectedItem.ToString()];
            }
            FillListView(FileManager.GetAllAccessibleFiles(leftTreeView.SelectedNode.FullPath,
                filter), leftListView);

            if (rightTreeView.SelectedNode == null) rightTreeView.SelectedNode = rightTreeView.Nodes[0];
            filter = FileManager.Filter.NONE;
            if (rightTypesComboBox.SelectedItem != null && FileManager.nameToFilter.ContainsKey(rightTypesComboBox.SelectedItem.ToString())){
                filter = FileManager.nameToFilter[rightTypesComboBox.SelectedItem.ToString()];
            }
            FillListView(FileManager.GetAllAccessibleFiles(rightTreeView.SelectedNode.FullPath,filter), rightListView);
        }

        private void FillListView(List<FileInfo> fileInfos, ListView listView)
        {
            listView.Items.Clear();
            listView.LargeImageList = this.imageList;
            foreach (var file in fileInfos)
            {
                var listEl = new ListViewItem(file.Name)
                {Tag = file};
                listEl.ImageIndex = Path.GetExtension(file.Name) switch
                {
                    ".txt" => 2,
                    ".html" => 3,
                    ".exe" => 4,
                    _ => 1
                };
                listView.Items.Add(listEl);
            }
        }
        void SearchKeyDown(KeyEventArgs e, TextBox depthSearch, TreeView treeView, Filter filter, TextBox pattern, ListView listView)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int number = INITIAL_SEARCH_DEPTH;
                if (Int32.TryParse(depthSearch.Text, out number))
                {
                    if (number < 0) number = INF_DEPTH;
                    depthSearch.Text = number.ToString();
                    var files = FileManager.SearchFiles(treeView.SelectedNode.FullPath, filter, pattern.Text, number);
                    FillListView(files, listView);
                }
            }
        }
        void LoadFile(string path)
        {
            string fileExt = System.IO.Path.GetExtension(path);
            if (fileExt == ".txt") (new TxtFileRedactor()).LoadFile(path);
            else if(fileExt == ".html") (new HtmlFileRedactor()).LoadFile(path);
            else MessageBox.Show("Unsupported format!");
        }
        private void leftTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node != null) TreeHandler.FillBeforeExpand(e.Node);
        }
        private void rightTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node != null) TreeHandler.FillBeforeExpand(e.Node);
        }
        //Drivers events
        private void leftDriversComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TreeHandler.FillDirectoryTree(leftTreeView, leftDriversComboBox.Text);
        }
        private void rightDriversComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TreeHandler.FillDirectoryTree(rightTreeView, rightDriversComboBox.Text);
        }
        //Choosing types events
        private void rightTypesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("Hello world");
            //currentRightFilter = FileManager.nameToFilter[rightTypesComboBox.SelectedItem.ToString()];
            UpdateFiles();
        }
        private void leftTypesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //currentLeftFilter = FileManager.nameToFilter[leftTypesComboBox.SelectedItem.ToString()];
            UpdateFiles();
        }
        //Pattern events
        private void leftPatternSearch_KeyDown(object sender, KeyEventArgs e)
        {
            SearchKeyDown(e, leftDepthSearch, leftTreeView, currentLeftFilter, leftPatternSearch, leftListView);
        }
        private void rightPatternSearch_KeyDown(object sender, KeyEventArgs e)
        {
            SearchKeyDown(e, rightDepthSearch, rightTreeView, currentRightFilter, rightPatternSearch, rightListView);
        }
        private void KeyDownF(TreeView treeView, ListView listView, FileManager.Filter filter, KeyEventArgs e)
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
                    if (result == DialogResult.Yes) FileManager.CopyReneme(saved_path, new_path);
                    else if (result == DialogResult.No) FileManager.CopyFile(saved_path, new_path);
                }
                else FileManager.CopyFile(saved_path, new_path);
                UpdateFiles();
            }
            if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control && listView.SelectedItems.Count > 0)
            {
                FileManager.DeleteFile(Path.Combine(treeView.SelectedNode.FullPath, listView.SelectedItems[0].Text));
                UpdateFiles();
            }
            
        }
        private void KeyDownD(TreeView treeView, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control)
            {
                var parrent = treeView.SelectedNode.Parent;
                FileManager.DeleteDirectory(treeView.SelectedNode.FullPath);
                var result1 = TreeHandler.GetAllNodes(leftTreeView)
                           .FirstOrDefault(node => new DirectoryInfo(node.FullPath).FullName == new DirectoryInfo(parrent.FullPath).FullName);
                var result2 = TreeHandler.GetAllNodes(rightTreeView)
                           .FirstOrDefault(node => new DirectoryInfo(node.FullPath).FullName == new DirectoryInfo(parrent.FullPath).FullName);
                if(result1 != null)
                {
                    TreeHandler.FillTreeNodes(result1);
                    TreeHandler.FillBeforeExpand(result1);
                }
                
                if(result2 != null)
                {
                    TreeHandler.FillTreeNodes(result2);
                    TreeHandler.FillBeforeExpand(result2);
                }
                
                UpdateFiles();
            }

        }
        private void leftListView_DoubleClick(object sender, EventArgs e)
        {
                LoadFile(Path.Combine(leftTreeView.SelectedNode.FullPath, leftListView.SelectedItems[0].Text));
        }
        private void rightListView_DoubleClick(object sender, EventArgs e)
        {
                LoadFile(Path.Combine(rightTreeView.SelectedNode.FullPath, rightListView.SelectedItems[0].Text));
        }

        private void leftListView_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownF(currentTree, currentListView, currentLeftFilter, e);
        }

        private void rightListView_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownF(currentTree, currentListView, currentRightFilter, e);
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
            if (string.IsNullOrWhiteSpace(pattern.Text)) return;
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
            UpdateFiles();
        }

        private void leftCreate_Click(object sender, EventArgs e)
        {
            CreateClick(leftTreeView, leftPatternSearch, leftListView, currentLeftFilter);
        }

        private void rightCreate_Click(object sender, EventArgs e)
        {
            CreateClick(rightTreeView, rightPatternSearch, rightListView, currentRightFilter);
        }

        private void leftTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e != null && e.Node != null) UpdateFiles();
        }

        private void rightTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e != null && e.Node != null) UpdateFiles();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCreateDirectoryLeft_Click(object sender, EventArgs e)
        {
            CreateDirectoryUn(textBoxDirectoryNameLeft, leftTreeView, rightTreeView);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void CreateDirectoryUn(TextBox textBox, TreeView treeView, TreeView diffTreeView)
        {
            if (textBox.Text != "")
            {
                string path = Path.Combine(treeView.SelectedNode.FullPath, textBox.Text);
                FileManager.CreateDirectory(path);
                TreeHandler.FillTreeNodes(treeView.SelectedNode);
                var result = TreeHandler.GetAllNodes(diffTreeView)
                           .FirstOrDefault(node => new DirectoryInfo(node.FullPath).FullName == new DirectoryInfo(path).Parent.FullName);
                if (result != null)
                    TreeHandler.FillTreeNodes(result);
            }
        }
        private void btnCreateDirectoryRight_Click(object sender, EventArgs e)
        {
            CreateDirectoryUn(textBoxCreateDirectoryRight, rightTreeView, leftTreeView);
        }

        private void leftTreeView_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownD(leftTreeView, e);
        }

        private void rightTreeView_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownD(rightTreeView, e);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ctrl+C - copy, Ctrl+D - delete, Ctrl+V - past", "Help", MessageBoxButtons.OK);
        }
    }
}