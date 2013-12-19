using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Threading;

namespace UserFinder
{
    public partial class frmUserFinder : Form
    {
        private Faulk_Me.ActiveDirectory _AD = new Faulk_Me.ActiveDirectory();

        public frmUserFinder()
        {
            InitializeComponent();
            txtDomainName.Text = Environment.UserDomainName;

            ImageList treeImg = new ImageList();
            treeImg.Images.Add("folder", Properties.Resources.folder);
            treeImg.Images.Add("computer", Properties.Resources.computer);
            treeImg.Images.Add("info", Properties.Resources.information);
            treeImg.Images.Add("link", Properties.Resources.link_go);
            treeImg.Images.Add("user", Properties.Resources.user_gray);
            lstResults.ImageList = treeImg;
            lstADTree.ImageList = treeImg;

            lstResults.Nodes.Add("selComputers", "Selected Computers", "folder", "folder");
            lstResults.Nodes.Add("searchResults", "Results", "folder", "folder");

            showAbout();
        }

        private void lstResults_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode pn = lstResults.SelectedNode ?? lstResults.Nodes[0];

            switch (pn.Name)
            {
                case "ThanksURL":
                case "AboutURL":
                    Process.Start(pn.Text, null);
                    break;
            }
        }

        private void showAbout()
        {
            Font tFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Underline);

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;

            var nodeAbout = lstResults.Nodes.Add("about", "About", "info", "info");
            nodeAbout.Nodes.Add("About", "Created by Winter Faulk 2013", "user", "user");
            nodeAbout.Nodes.Add("ver", "Version: " + version, "info", "info");
            var nodeAboutURL = nodeAbout.Nodes.Add("AboutURL", "http://faulk.me", "link", "link");
            var nodeThanks = nodeAbout.Nodes.Add("ThanksIcon", "Icons thanks to:", "info", "info");
            var nodeThanksURL = nodeThanks.Nodes.Add("ThanksURL", "http://famfamfam.com/", "link", "link");

            nodeThanksURL.ForeColor = Color.Blue;
            nodeThanksURL.NodeFont = tFont;
            nodeAboutURL.ForeColor = Color.Blue;
            nodeAboutURL.NodeFont = tFont;
        }

        private void cmdLoadADTree_Click(object sender, EventArgs e)
        {
            Dictionary<string, string[]> OUs = _AD.GetOUList(txtDomainName.Text);
            foreach (KeyValuePair<string, string[]> ou in OUs)
            {
                string objT = imgType(ou.Value[1]);
                TreeNode tn = lstADTree.Nodes.Add(ou.Key, ou.Value[0].Replace(@"\", string.Empty), objT, objT);
                tn.Tag = _AD.GetObjectType(ou.Key);
            }
        }

        private void lstADTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode pn = lstADTree.SelectedNode ?? lstADTree.Nodes[0];
            if (pn != null)
            {
                if (pn.Nodes.Count <= 0)
                {
                    if (string.Compare(_AD.GetObjectType(pn.Name), "organizationalUnit", true) == 0)
                    {
                        addNode(pn);
                    }
                }
                pn.Expand();
            }
        }

        private void lstADTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                if (e.Node.Nodes.Count <= 0)
                {
                    if (e.Node.Tag != null && string.Compare(e.Node.Tag.ToString(), "organizationalUnit", true) == 0)
                    {
                        addNode(e.Node);
                    }
                }

                foreach (TreeNode childnode in e.Node.Nodes)
                {
                    if (string.Compare(_AD.GetObjectType(childnode.Name), "organizationalUnit", true) == 0 && childnode.Nodes.Count <= 0)
                    {
                        addNode(childnode);
                    }
                    childnode.Checked = true;
                }

                if (e.Node.Tag != null && string.Compare(e.Node.Tag.ToString(), "computer") == 0)
                {
                    lstResults.Nodes["selComputers"].Nodes.Add(e.Node.Name, e.Node.Text, "computer", "computer");
                }
            }
            else
            {
                foreach (TreeNode childnode in e.Node.Nodes)
                {
                    childnode.Checked = false;
                    TreeNode[] chNode = lstResults.Nodes.Find(childnode.Name, true);
                    if (chNode.Length > 0)
                    {
                        chNode[0].Remove();
                    }
                }

                TreeNode[] node = lstResults.Nodes.Find(e.Node.Name, true);
                if (node.Length > 0)
                {
                    node[0].Remove();
                }
            }
        }

        private string imgType(string obj)
        {
            string o = "folder";

            switch (obj)
            {
                case "organizationalUnit":
                    o = "folder";
                    break;
                case "computer":
                    o = "computer";
                    break;
                default:
                    o = "folder";
                    break;
            }

            return o;
        }

        private void addNode(TreeNode node)
        {
            string[] filter = { "ou", "computer" };
            Dictionary<string, string[]> OUs = _AD.GetOUList(node.Name, filter);
            foreach (KeyValuePair<string, string[]> ou in OUs)
            {
                string objT = imgType(ou.Value[1]);
                TreeNode child = node.Nodes.Add(ou.Key, ou.Value[0].Replace(@"\", string.Empty), objT, objT);
                child.Tag = _AD.GetObjectType(ou.Key);
            }
        }

        private void cmdFindUser_Click(object sender, EventArgs e)
        {
            if (cmdFindUser.Text.Contains("Find User"))
            {
                amountDone.Value = 0;
                amountDone.Visible = true;
                status.Text = "Running...";
                cmdFindUser.Text = "Stop Search";
                bgwUserSearch.RunWorkerAsync();
            }
            else
            {
                cmdFindUser.Text = "3. Find User";
                bgwUserSearch.CancelAsync();
            }
        }

        private void removeSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ==========================================================================================================

            MessageBox.Show("Currently not working");
            
            /*
            TreeNode selNode = lstResults.SelectedNode;
            DialogResult resultRemove = MessageBox.Show("Remove " + selNode.Text + "?", "Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultRemove == DialogResult.Yes)
            {
                var node_name = lstResults.SelectedNode.Name.Split('_');
                TreeNode[] fNode = lstADTree.Nodes.Find(node_name[1].ToUpper(), true);
                MessageBox.Show(fNode.Length.ToString());
                fNode[0].Checked = false;
                selNode.Remove();
            }
             */
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in lstADTree.Nodes)
            {
                if (node.Checked)
                {
                    node.Checked = false;
                }
            }
            lstResults.Nodes.Clear();
            lstResults.Nodes.Add("selComputers", "Selected Computers", "folder", "folder");
            lstResults.Nodes.Add("searchResults", "Results", "folder", "folder");
        }

        delegate void SetTreeNode(string comp, string user);

        private void bgwUserSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> computers = new List<string>();
            double _done = 0;
            double _compcount = 0;
            
            foreach (TreeNode c in lstResults.Nodes["selComputers"].Nodes)
            {
                if (bgwUserSearch.CancellationPending || e.Cancel)
                {
                    break;
                }
                else
                {
                    computers.Add(c.Text);
                }
            }

            if (!bgwUserSearch.CancellationPending)
            {
                foreach (string comp in computers)
                {
                    if (bgwUserSearch.CancellationPending || e.Cancel)
                    {
                        break;
                    }
                    else
                    {
                        foreach (string user in Faulk_Me.WMIClass.getUsersFromComputer(comp))
                        {
                            if (user.ToLower().Contains(txtUserName.Text.ToLower()) || user.ToLower().Contains("access issue"))
                            {
                                addNewResult(comp, user);
                            }
                        }
                        _compcount++;
                        _done = (_compcount / computers.Count) * 100;
                        bgwUserSearch.ReportProgress((int)_done);
                    }
                }
            }
        }

        private void bgwUserSearch_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            amountDone.Value = e.ProgressPercentage;
        }

        private void bgwUserSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            status.Text = "Done.";
            amountDone.Visible = false;
            cmdFindUser.Text = "3. Find User";   
        }

        private void addNewResult(string comp, string user)
        {
            if (lstResults.InvokeRequired)
            {
                SetTreeNode result = new SetTreeNode(addNewResult);
                this.Invoke(result, new object[] { comp, user });
            }
            else
            {
                lstResults.Nodes["searchResults"].Nodes.Add("Result_" + comp, comp + " - " + user, "computer", "computer");
                lstResults.Nodes["searchResults"].Expand();
            }
        }
    }
}
