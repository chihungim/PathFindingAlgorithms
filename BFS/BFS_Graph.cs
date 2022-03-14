using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;


namespace PathFindingAlgorithms.BFS
{
    
    public partial class BFS_Graph : Form
    {

        #region Fields
        public const int MAX = 10;
        private Label _target1, _target2;
        private Label _start = null, _end = null;
        private List<Label> path;
        private 
        #endregion

        public BFS_Graph()
        {
            InitializeComponent();
            g = new ControlGraph(BackGround);
        }

        #region ctrl
        private void ctrlReset_Click(object sender, EventArgs e)
        {
            g.Graph.Controls.Clear();
        }
        private void ctrlToStart_Click(object sender, EventArgs e)
        {
            _start = VertexControlMenu.SourceControl as Label;
        }

        private void ctrlToEnd_Click(object sender, EventArgs e)
        {
            _end =  VertexControlMenu.SourceControl as Label;
        }

        private void ctrlConnect_Click(object sender, EventArgs e)
        {
            if (_target1 == null)
            {
                _target1 = (Label)VertexControlMenu.SourceControl;
                ctrlConnect.Text = @"To";
            }
            else if (_target2 == null)
            {
                _target2 = (Label)VertexControlMenu.SourceControl;
                if (_target1 == _target2)
                {
                    _target2 = null;
                    return;
                }
                ctrlConnect.Text = @"From";
                g.CreateEdge(_target1, _target2);
                g.Graph.Invalidate();
                _target1 = null;
                _target2 = null;
            }
        }

        private void ctrlRemove_Click(object sender, EventArgs e)
        {

            var vertexLabel = VertexControlMenu.SourceControl as Label;
            if (_target1 == vertexLabel)
            {
                _target1 = null;
                ctrlConnect.Text = @"From";
            }
            
            g.RemoveVertexLabel(vertexLabel);
            g.Graph.Invalidate();
        }


        #endregion

        #region Find Path
        class Node
        {
            private Node from;
            private Label me;

            public Node From => from;
            public Label Me => me;
            public Node(Node _from, Label _me)
            {
                from = _from;
                me = _me;
            }
        }

        private void ctrlPathFinding_Click(object sender, EventArgs e)
        {
            if (_start == null && _end == null)
            {
                return;
            }

            var graph = new List<Label>[BackGround.Controls.Count];
            var visited = new List<Label>();
            
            path = null;

            for (int i = 0; i < BackGround.Controls.Count; i++)
            {
                graph[i] = BackGround.Controls[i].Tag as List<Label>;
                if (BackGround.Controls[i].BackColor == Color.DarkMagenta)
                    BackGround.Controls[i].BackColor = Color.AliceBlue;
                BackGround.Name = i + "";
            }

            var q = new Queue<Node>();
            q.Enqueue(new Node(null, _start));


            while (q.Count != 0)
            {
                var cur = q.Dequeue();
                var from = cur.Me;
                from.BackColor = Color.Aquamarine;
                if (from == _end)
                {
                    findPath(cur);
                    return;
                }

                foreach (var to in graph[Int32.Parse(from.Name)])
                {
                    if (!visited.Contains(to))
                    {
                        Thread.Sleep(100);
                        Application.DoEvents();
                        visited.Add(to);
                        q.Enqueue(new Node(cur, to));
                    }
                }
            }

            MessageBox.Show("Failed to Find path");
        }

        void findPath(Node dest)
        {
            Node temp = dest;
            var path = new List<Label>();
            while (temp != null)
            {
                path.Add(temp.Me);
                temp = temp.From;
            }

            path.Reverse();
            this.path = path;
            foreach (var p in path)
            {
                p.BackColor = Color.DarkMagenta;
            }

            BackGround.Invalidate();
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

        private void BackGround_Click(object sender, EventArgs e)
        {
            var evt = (MouseEventArgs)e;
            if (evt.Button == MouseButtons.Left)
                g.AddVertexLabel(evt.Location).ContextMenuStrip = VertexControlMenu;
        }

        #endregion

    }
}
