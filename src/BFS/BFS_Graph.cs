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
    
    public partial class BFS_Graph : Form, IAlgorithm
    {
        public BFS_Graph()
        {
            InitializeComponent();
        }

        #region ctrl
        private void ctrlReset_Click(object sender, EventArgs e)
        {
            graphPanel1.RemoveAllVertex();
        }
        private void ctrlPathFinding_Click(object sender, EventArgs e)
        {
            if (graphPanel1.VertexControlMenu.Start == null || graphPanel1.VertexControlMenu.End == null)
            {
                return;
            }

            ((IAlgorithm)this).PathFinding_BFS(graphPanel1.VertexControlMenu.Start, graphPanel1.VertexControlMenu.End);
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

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphPanel1.RemoveAllVertex();
        }
    }
}
