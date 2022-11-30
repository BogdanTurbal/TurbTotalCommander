using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurbTotalCommander
{
    public static class TreeHandler
    {
        public static void FillTreeNodes(TreeNode treeNode)
        {
            string dir = treeNode.FullPath;
            treeNode.Nodes.Clear();
            foreach (DirectoryInfo di in FileManager.GetAllAccessibleDirectories(dir))
            {
                TreeNode child = new TreeNode(di.Name);
                child.Tag = di;
                child.ImageIndex = 0;
                //FillTreeNodes(child, di, level + 1);
                treeNode.Nodes.Add(child);

            }
        }
        public static void FillBeforeExpand(TreeNode treeNode)
        {
            string path = treeNode.FullPath;
            foreach (TreeNode nd in treeNode.Nodes)
            {
                FillTreeNodes(nd);
            }
        }

        public static void FillDirectoryTree(TreeView treeView, string dir)
        {
            treeView.Nodes.Clear();
            TreeNode treeNode = new TreeNode(dir);
            DirectoryInfo dirInf = new DirectoryInfo(dir);
            treeNode.Tag = dirInf;
            treeView.Nodes.Add(treeNode);
            treeView.SelectedNode = treeNode;
            FillTreeNodes(treeNode);
            treeView.SelectedNode = treeNode;
        }
        public static List<TreeNode> GetAllNodes(this TreeView _self)
        {
            List<TreeNode> result = new List<TreeNode>();
            foreach (TreeNode child in _self.Nodes)
            {
                result.AddRange(GetAllNodes(child));
            }
            return result;
        }
        public static List<TreeNode> GetAllNodes(this TreeNode _self)
        {
            List<TreeNode> result = new List<TreeNode>();
            result.Add(_self);
            foreach (TreeNode child in _self.Nodes)
            {
                result.AddRange(GetAllNodes(child));
            }
            return result;
        }
    }
}
