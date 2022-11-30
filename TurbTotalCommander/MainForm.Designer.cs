namespace TurbTotalCommander
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateDirectoryLeft = new System.Windows.Forms.Button();
            this.textBoxDirectoryNameLeft = new System.Windows.Forms.TextBox();
            this.leftDriversComboBox = new System.Windows.Forms.ComboBox();
            this.leftTreeView = new System.Windows.Forms.TreeView();
            this.leftCreate = new System.Windows.Forms.Button();
            this.leftDepthSearch = new System.Windows.Forms.TextBox();
            this.leftPatternSearch = new System.Windows.Forms.TextBox();
            this.leftTypesComboBox = new System.Windows.Forms.ComboBox();
            this.leftListView = new System.Windows.Forms.ListView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.btnCreateDirectoryRight = new System.Windows.Forms.Button();
            this.textBoxCreateDirectoryRight = new System.Windows.Forms.TextBox();
            this.rightDriversComboBox = new System.Windows.Forms.ComboBox();
            this.rightTreeView = new System.Windows.Forms.TreeView();
            this.rightCreate = new System.Windows.Forms.Button();
            this.rightDepthSearch = new System.Windows.Forms.TextBox();
            this.rightPatternSearch = new System.Windows.Forms.TextBox();
            this.rightTypesComboBox = new System.Windows.Forms.ComboBox();
            this.rightListView = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1182, 592);
            this.splitContainer1.SplitterDistance = 583;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.btnCreateDirectoryLeft);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxDirectoryNameLeft);
            this.splitContainer2.Panel1.Controls.Add(this.leftDriversComboBox);
            this.splitContainer2.Panel1.Controls.Add(this.leftTreeView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.leftCreate);
            this.splitContainer2.Panel2.Controls.Add(this.leftDepthSearch);
            this.splitContainer2.Panel2.Controls.Add(this.leftPatternSearch);
            this.splitContainer2.Panel2.Controls.Add(this.leftTypesComboBox);
            this.splitContainer2.Panel2.Controls.Add(this.leftListView);
            this.splitContainer2.Size = new System.Drawing.Size(583, 592);
            this.splitContainer2.SplitterDistance = 274;
            this.splitContainer2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 560);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ctrl+C - copy, Ctrl+D - delete, Ctrl+V - past";
            // 
            // btnCreateDirectoryLeft
            // 
            this.btnCreateDirectoryLeft.Location = new System.Drawing.Point(248, 506);
            this.btnCreateDirectoryLeft.Name = "btnCreateDirectoryLeft";
            this.btnCreateDirectoryLeft.Size = new System.Drawing.Size(23, 23);
            this.btnCreateDirectoryLeft.TabIndex = 3;
            this.btnCreateDirectoryLeft.Text = "+";
            this.btnCreateDirectoryLeft.UseVisualStyleBackColor = true;
            this.btnCreateDirectoryLeft.Click += new System.EventHandler(this.btnCreateDirectoryLeft_Click);
            // 
            // textBoxDirectoryNameLeft
            // 
            this.textBoxDirectoryNameLeft.Location = new System.Drawing.Point(12, 506);
            this.textBoxDirectoryNameLeft.Name = "textBoxDirectoryNameLeft";
            this.textBoxDirectoryNameLeft.Size = new System.Drawing.Size(234, 23);
            this.textBoxDirectoryNameLeft.TabIndex = 2;
            // 
            // leftDriversComboBox
            // 
            this.leftDriversComboBox.FormattingEnabled = true;
            this.leftDriversComboBox.Location = new System.Drawing.Point(12, 534);
            this.leftDriversComboBox.Name = "leftDriversComboBox";
            this.leftDriversComboBox.Size = new System.Drawing.Size(169, 23);
            this.leftDriversComboBox.TabIndex = 1;
            this.leftDriversComboBox.SelectedIndexChanged += new System.EventHandler(this.leftDriversComboBox_SelectedIndexChanged);
            // 
            // leftTreeView
            // 
            this.leftTreeView.Location = new System.Drawing.Point(3, 5);
            this.leftTreeView.Name = "leftTreeView";
            this.leftTreeView.Size = new System.Drawing.Size(272, 497);
            this.leftTreeView.TabIndex = 0;
            this.leftTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.leftTreeView_BeforeExpand);
            this.leftTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.leftTreeView_AfterSelect);
            this.leftTreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.leftTreeView_KeyDown);
            // 
            // leftCreate
            // 
            this.leftCreate.Location = new System.Drawing.Point(205, 5);
            this.leftCreate.Name = "leftCreate";
            this.leftCreate.Size = new System.Drawing.Size(22, 23);
            this.leftCreate.TabIndex = 4;
            this.leftCreate.Text = "+";
            this.leftCreate.UseVisualStyleBackColor = true;
            this.leftCreate.Click += new System.EventHandler(this.leftCreate_Click);
            // 
            // leftDepthSearch
            // 
            this.leftDepthSearch.Location = new System.Drawing.Point(233, 5);
            this.leftDepthSearch.Name = "leftDepthSearch";
            this.leftDepthSearch.Size = new System.Drawing.Size(70, 23);
            this.leftDepthSearch.TabIndex = 3;
            // 
            // leftPatternSearch
            // 
            this.leftPatternSearch.Location = new System.Drawing.Point(3, 5);
            this.leftPatternSearch.Name = "leftPatternSearch";
            this.leftPatternSearch.Size = new System.Drawing.Size(196, 23);
            this.leftPatternSearch.TabIndex = 2;
            this.leftPatternSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.leftPatternSearch_KeyDown);
            // 
            // leftTypesComboBox
            // 
            this.leftTypesComboBox.FormattingEnabled = true;
            this.leftTypesComboBox.Location = new System.Drawing.Point(13, 534);
            this.leftTypesComboBox.Name = "leftTypesComboBox";
            this.leftTypesComboBox.Size = new System.Drawing.Size(188, 23);
            this.leftTypesComboBox.TabIndex = 1;
            this.leftTypesComboBox.SelectedIndexChanged += new System.EventHandler(this.leftTypesComboBox_SelectedIndexChanged);
            // 
            // leftListView
            // 
            this.leftListView.Location = new System.Drawing.Point(3, 31);
            this.leftListView.Name = "leftListView";
            this.leftListView.Size = new System.Drawing.Size(299, 497);
            this.leftListView.TabIndex = 0;
            this.leftListView.UseCompatibleStateImageBehavior = false;
            this.leftListView.DoubleClick += new System.EventHandler(this.leftListView_DoubleClick);
            this.leftListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.leftListView_KeyDown);
            this.leftListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.leftListView_MouseDown);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.btnCreateDirectoryRight);
            this.splitContainer3.Panel1.Controls.Add(this.textBoxCreateDirectoryRight);
            this.splitContainer3.Panel1.Controls.Add(this.rightDriversComboBox);
            this.splitContainer3.Panel1.Controls.Add(this.rightTreeView);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.rightCreate);
            this.splitContainer3.Panel2.Controls.Add(this.rightDepthSearch);
            this.splitContainer3.Panel2.Controls.Add(this.rightPatternSearch);
            this.splitContainer3.Panel2.Controls.Add(this.rightTypesComboBox);
            this.splitContainer3.Panel2.Controls.Add(this.rightListView);
            this.splitContainer3.Size = new System.Drawing.Size(595, 592);
            this.splitContainer3.SplitterDistance = 291;
            this.splitContainer3.TabIndex = 0;
            // 
            // btnCreateDirectoryRight
            // 
            this.btnCreateDirectoryRight.Location = new System.Drawing.Point(265, 504);
            this.btnCreateDirectoryRight.Name = "btnCreateDirectoryRight";
            this.btnCreateDirectoryRight.Size = new System.Drawing.Size(23, 23);
            this.btnCreateDirectoryRight.TabIndex = 4;
            this.btnCreateDirectoryRight.Text = "+";
            this.btnCreateDirectoryRight.UseVisualStyleBackColor = true;
            this.btnCreateDirectoryRight.Click += new System.EventHandler(this.btnCreateDirectoryRight_Click);
            // 
            // textBoxCreateDirectoryRight
            // 
            this.textBoxCreateDirectoryRight.Location = new System.Drawing.Point(3, 505);
            this.textBoxCreateDirectoryRight.Name = "textBoxCreateDirectoryRight";
            this.textBoxCreateDirectoryRight.Size = new System.Drawing.Size(256, 23);
            this.textBoxCreateDirectoryRight.TabIndex = 3;
            // 
            // rightDriversComboBox
            // 
            this.rightDriversComboBox.FormattingEnabled = true;
            this.rightDriversComboBox.Location = new System.Drawing.Point(3, 534);
            this.rightDriversComboBox.Name = "rightDriversComboBox";
            this.rightDriversComboBox.Size = new System.Drawing.Size(176, 23);
            this.rightDriversComboBox.TabIndex = 1;
            this.rightDriversComboBox.SelectedIndexChanged += new System.EventHandler(this.rightDriversComboBox_SelectedIndexChanged);
            // 
            // rightTreeView
            // 
            this.rightTreeView.Location = new System.Drawing.Point(3, 3);
            this.rightTreeView.Name = "rightTreeView";
            this.rightTreeView.Size = new System.Drawing.Size(285, 499);
            this.rightTreeView.TabIndex = 0;
            this.rightTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.rightTreeView_BeforeExpand);
            this.rightTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.rightTreeView_AfterSelect);
            this.rightTreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rightTreeView_KeyDown);
            // 
            // rightCreate
            // 
            this.rightCreate.Location = new System.Drawing.Point(209, 5);
            this.rightCreate.Name = "rightCreate";
            this.rightCreate.Size = new System.Drawing.Size(24, 23);
            this.rightCreate.TabIndex = 4;
            this.rightCreate.Text = "+";
            this.rightCreate.UseVisualStyleBackColor = true;
            this.rightCreate.Click += new System.EventHandler(this.rightCreate_Click);
            // 
            // rightDepthSearch
            // 
            this.rightDepthSearch.Location = new System.Drawing.Point(239, 5);
            this.rightDepthSearch.Name = "rightDepthSearch";
            this.rightDepthSearch.Size = new System.Drawing.Size(58, 23);
            this.rightDepthSearch.TabIndex = 3;
            // 
            // rightPatternSearch
            // 
            this.rightPatternSearch.Location = new System.Drawing.Point(3, 5);
            this.rightPatternSearch.Name = "rightPatternSearch";
            this.rightPatternSearch.Size = new System.Drawing.Size(200, 23);
            this.rightPatternSearch.TabIndex = 2;
            this.rightPatternSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rightPatternSearch_KeyDown);
            // 
            // rightTypesComboBox
            // 
            this.rightTypesComboBox.FormattingEnabled = true;
            this.rightTypesComboBox.Location = new System.Drawing.Point(3, 537);
            this.rightTypesComboBox.Name = "rightTypesComboBox";
            this.rightTypesComboBox.Size = new System.Drawing.Size(156, 23);
            this.rightTypesComboBox.TabIndex = 1;
            this.rightTypesComboBox.SelectedIndexChanged += new System.EventHandler(this.rightTypesComboBox_SelectedIndexChanged);
            // 
            // rightListView
            // 
            this.rightListView.Location = new System.Drawing.Point(3, 31);
            this.rightListView.Name = "rightListView";
            this.rightListView.Size = new System.Drawing.Size(294, 500);
            this.rightListView.TabIndex = 0;
            this.rightListView.UseCompatibleStateImageBehavior = false;
            this.rightListView.DoubleClick += new System.EventHandler(this.rightListView_DoubleClick);
            this.rightListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rightListView_KeyDown);
            this.rightListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightListView_MouseDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1182, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "OneDrive_Folder_Icon.svg.png");
            this.imageList.Images.SetKeyName(1, "file.png");
            this.imageList.Images.SetKeyName(2, "3022200.png");
            this.imageList.Images.SetKeyName(3, "html-outline.png");
            this.imageList.Images.SetKeyName(4, "2306085.png");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(103, 26);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 616);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private TreeView leftTreeView;
        private MenuStrip menuStrip1;
        private ListView leftListView;
        private ImageList imageList;
        private ComboBox leftDriversComboBox;
        private ComboBox leftTypesComboBox;
        private SplitContainer splitContainer3;
        private ComboBox rightDriversComboBox;
        private TreeView rightTreeView;
        private ComboBox rightTypesComboBox;
        private ListView rightListView;
        private TextBox leftPatternSearch;
        private TextBox rightPatternSearch;
        private TextBox leftDepthSearch;
        private TextBox rightDepthSearch;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private Button leftCreate;
        private Button rightCreate;
        private TextBox textBoxDirectoryNameLeft;
        private Button btnCreateDirectoryLeft;
        private Button btnCreateDirectoryRight;
        private TextBox textBoxCreateDirectoryRight;
        private Label label1;
        private ToolStripMenuItem helpToolStripMenuItem;
    }
}