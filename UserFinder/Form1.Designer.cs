namespace UserFinder
{
    partial class frmUserFinder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserFinder));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.amountDone = new System.Windows.Forms.ToolStripProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstADTree = new System.Windows.Forms.TreeView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.txtDomainName = new System.Windows.Forms.ToolStripTextBox();
            this.cmdLoadADTree = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstResults = new System.Windows.Forms.TreeView();
            this.ResultsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txtUserName = new System.Windows.Forms.ToolStripTextBox();
            this.cmdFindUser = new System.Windows.Forms.ToolStripButton();
            this.bgwUserSearch = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ResultsMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status,
            this.amountDone});
            this.statusStrip1.Location = new System.Drawing.Point(0, 483);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(569, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusBar";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 17);
            // 
            // amountDone
            // 
            this.amountDone.Name = "amountDone";
            this.amountDone.Size = new System.Drawing.Size(200, 16);
            this.amountDone.Step = 1;
            this.amountDone.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip2);
            this.splitContainer1.Panel1MinSize = 260;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel2MinSize = 260;
            this.splitContainer1.Size = new System.Drawing.Size(569, 483);
            this.splitContainer1.SplitterDistance = 260;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstADTree);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 458);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2. Domain Tree";
            // 
            // lstADTree
            // 
            this.lstADTree.CheckBoxes = true;
            this.lstADTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstADTree.Location = new System.Drawing.Point(3, 16);
            this.lstADTree.Name = "lstADTree";
            this.lstADTree.Size = new System.Drawing.Size(254, 439);
            this.lstADTree.TabIndex = 2;
            this.lstADTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.lstADTree_AfterCheck);
            this.lstADTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.lstADTree_AfterSelect);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtDomainName,
            this.cmdLoadADTree});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(260, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // txtDomainName
            // 
            this.txtDomainName.Name = "txtDomainName";
            this.txtDomainName.Size = new System.Drawing.Size(100, 25);
            // 
            // cmdLoadADTree
            // 
            this.cmdLoadADTree.Image = global::UserFinder.Properties.Resources.computer;
            this.cmdLoadADTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdLoadADTree.Name = "cmdLoadADTree";
            this.cmdLoadADTree.Size = new System.Drawing.Size(136, 22);
            this.cmdLoadADTree.Text = "1. Load Domain Tree";
            this.cmdLoadADTree.Click += new System.EventHandler(this.cmdLoadADTree_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstResults);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 458);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results";
            // 
            // lstResults
            // 
            this.lstResults.ContextMenuStrip = this.ResultsMenu;
            this.lstResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstResults.Location = new System.Drawing.Point(3, 16);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(299, 439);
            this.lstResults.TabIndex = 0;
            this.lstResults.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.lstResults_AfterSelect);
            // 
            // ResultsMenu
            // 
            this.ResultsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeSelectedToolStripMenuItem,
            this.clearAllToolStripMenuItem});
            this.ResultsMenu.Name = "ResultsMenu";
            this.ResultsMenu.Size = new System.Drawing.Size(165, 48);
            // 
            // removeSelectedToolStripMenuItem
            // 
            this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
            this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.removeSelectedToolStripMenuItem.Text = "Remove Selected";
            this.removeSelectedToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedToolStripMenuItem_Click);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.clearAllToolStripMenuItem.Text = "Clear All";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtUserName,
            this.cmdFindUser});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(305, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // txtUserName
            // 
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 25);
            // 
            // cmdFindUser
            // 
            this.cmdFindUser.Image = global::UserFinder.Properties.Resources.magnifier;
            this.cmdFindUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdFindUser.Name = "cmdFindUser";
            this.cmdFindUser.Size = new System.Drawing.Size(88, 22);
            this.cmdFindUser.Text = "3. Find User";
            this.cmdFindUser.Click += new System.EventHandler(this.cmdFindUser_Click);
            // 
            // bgwUserSearch
            // 
            this.bgwUserSearch.WorkerReportsProgress = true;
            this.bgwUserSearch.WorkerSupportsCancellation = true;
            this.bgwUserSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwUserSearch_DoWork);
            this.bgwUserSearch.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwUserSearch_ProgressChanged);
            this.bgwUserSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwUserSearch_RunWorkerCompleted);
            // 
            // frmUserFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 505);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(580, 300);
            this.Name = "frmUserFinder";
            this.Text = "UserFinder";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResultsMenu.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox txtDomainName;
        private System.Windows.Forms.ToolStripButton cmdLoadADTree;
        private System.Windows.Forms.ToolStripTextBox txtUserName;
        private System.Windows.Forms.ToolStripButton cmdFindUser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView lstADTree;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView lstResults;
        private System.Windows.Forms.ContextMenuStrip ResultsMenu;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bgwUserSearch;
        private System.Windows.Forms.ToolStripProgressBar amountDone;
        private System.Windows.Forms.ToolStripStatusLabel status;
    }
}

