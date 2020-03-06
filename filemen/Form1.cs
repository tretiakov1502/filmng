using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace filemen
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            showdisks();
        }
        private void showdisks()
        {
            treeView1.Nodes.Clear();
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
                treeView1.Nodes.Add(drive.Name);
        }
        private void showdir()
        {
            treeView1.Nodes.Clear();
            string[] dirs = Directory.GetDirectories(@metroTextBox1.Text);
            foreach (string dir in dirs)
                treeView1.Nodes.Add(dir);

        }
        private void changeway(string way)
        {
            metroTextBox1.Text = "";
            metroTextBox1.Text = way;
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            changeway(treeView1.SelectedNode.Text.ToString());
            treeView1.Nodes.Clear();
            showdir();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text.Length == 3)
            {
                metroTextBox1.Text = "";
                showdisks();
            }
            if (metroTextBox1.Text.Length != 0)
            {
                int i = metroTextBox1.Text.LastIndexOf('\\');
                metroTextBox1.Text = metroTextBox1.Text.Substring(0, i);
                if (metroTextBox1.Text.Length == 2) metroTextBox1.Text += '\\';
                showdir();
            }
        }
    }
}
