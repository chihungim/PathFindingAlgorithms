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
    
    public partial class BFS_Graph : Form , IAlgorithm
    {

        #region Fields
        private VertexLabel _target1, _target2;
        private VertexLabel _start = null, _end = null;
        #endregion

        public BFS_Graph()
        {
            InitializeComponent();
        }

        private void GraphPanelOnClick(object? sender, EventArgs e)
        {
            var evt = e as MouseEventArgs;
            if (evt.Button == MouseButtons.Left)
                graphPanel1.AddVertexLabel(evt.Location).ContextMenuStrip = VertexControlMenu;
        }

        #region ctrl
        private void ctrlReset_Click(object sender, EventArgs e)
        {
            graphPanel1.RemoveAllVertex();
        }
        private void ctrlToStart_Click(object sender, EventArgs e)
        {
            _start = VertexControlMenu.SourceControl as VertexLabel;
        }

        private void ctrlToEnd_Click(object sender, EventArgs e)
        { 
            _end =  VertexControlMenu.SourceControl as VertexLabel;
        }

        private void ctrlConnect_Click(object sender, EventArgs e)
        {

            if (_target1 == null)
            {
                _target1 = (VertexLabel)VertexControlMenu.SourceControl;
                ctrlConnect.Text = @"To";
            }
            else if (_target2 == null)
            {
                _target2 = (VertexLabel)VertexControlMenu.SourceControl;
                if (_target1 == _target2)
                {
                    _target2 = null;
                    return;
                }
                ctrlConnect.Text = @"From";
                graphPanel1.CreateEdge(_target1, _target2);
                _target1 = null;
                _target2 = null;
            }
        }

        private void ctrlRemove_Click(object sender, EventArgs e)
        {

            var vertexLabel = VertexControlMenu.SourceControl as VertexLabel;
            if (_end == vertexLabel || _start == vertexLabel)
            {
                _end = _start = null;
            }

            if (_target1 == vertexLabel)
            {
                _target1 = null;
                ctrlConnect.Text = @"From";
            }

            graphPanel1.RemoveVertexLabel(vertexLabel);
        }
        #endregion
        #region Path Finding
        private void ctrlPathFinding_Click(object sender, EventArgs e)
        {
            if (_start == null && _end == null)
            {
                return;
            }
            ((IAlgorithm)this).PathFinding_BFS(_start, _end);
        }

        #endregion
        #region etc
        private void linklabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
