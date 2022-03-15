using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using PathFindingAlgorithms;
using PathFindingAlgorithms.CustomControls;

namespace PathFindingAlgorithms.BFS
{
    
    public partial class PathFinding_Graph : Form, IAlgorithm
    {
        public PathFinding_Graph()
        {
            InitializeComponent();
            FindOption.SelectedIndex = 0;
        }

        #region ctrl
        private void ctrlReset_Click(object sender, EventArgs e)
        {
            graphPanel1.BackgroundImage = null;
            graphPanel1.RemoveAllVertex();
        }


        private void ctrlPathFinding_Click(object sender, EventArgs e)
        {
            if (graphPanel1.VertexControlMenu.Start == null || graphPanel1.VertexControlMenu.End == null)
                return;

            var logic = ((IAlgorithm)this).Options(FindOption.SelectedIndex);
            logic(graphPanel1.VertexControlMenu.Start, graphPanel1.VertexControlMenu.End);
        } 

        private void ctrlLoadBg_Click(object sender, EventArgs e)
        {
            FileDialog fd = new OpenFileDialog();
            fd.Filter = "ImageFiles|*.png;*.jpeg;*.jpg;*.gif";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                var path = fd.FileName;
                graphPanel1.BackgroundImage = Image.FromFile(path);
            }
        }

        #endregion
        #region etc
        private void ToMyGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/chihungim",
                    UseShellExecute = true
                });
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
        #endregion

    }
}
