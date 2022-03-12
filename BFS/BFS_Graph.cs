using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;


namespace PathFindingAlgorithms.BFS
{
    
    public partial class BFS_Graph : Form
    {
        public const int MAX = 10;
        private Label _target1, _target2;
        private Label _start = null, _end = null;
        private List<Label> path;
        public BFS_Graph()
        {
            InitializeComponent();
        }

        #region ctrl
        private void ctrlReset_Click(object sender, EventArgs e)
        {
            BackGround.Controls.Clear();
            path = null;
            if (_start != null)
            {
                _start.BackColor = Color.AliceBlue;
                _start = null;
            }

            if (_end != null)
            {
                _end.BackColor = Color.AliceBlue;
                _end = null;
            }

            BackGround.Invalidate();

        }
        private void ctrlToStart_Click(object sender, EventArgs e)
        {
            var Node = NodeControlMenu.SourceControl as Label;
            if (_start != null)
            {
                _start.BackColor = Color.AliceBlue;
                _start = Node;
                _start.BackColor = Color.Crimson;
            }
            else
            {
                _start = Node;
                _start.BackColor = Color.Crimson;
            }
        }

        private void ctrlToEnd_Click(object sender, EventArgs e)
        {
            var Node = NodeControlMenu.SourceControl as Label;
            if (_end != null)
            {
                _end.BackColor = Color.AliceBlue;
                _end = Node;
                _end.BackColor = Color.Blue;

            }
            else
            {
                _end = Node;
                _end.BackColor = Color.Blue;
            }
        }

        private void ctrlConnect_Click(object sender, EventArgs e)
        {
            if (_target1 == null)
            {
                _target1 = (Label)NodeControlMenu.SourceControl;
                ctrlConnect.Text = @"To";
            }
            else if (_target2 == null)
            {
                _target2 = (Label)NodeControlMenu.SourceControl;
                if (_target1 == _target2)
                {
                    _target2 = null;
                    return;
                }
                ctrlConnect.Text = @"From";

                var toList = _target1.Tag as List<Label>;
                toList.Add(_target2);
                var fromList = _target2.Tag as List<Label>;
                fromList.Add(_target1);

                BackGround.Invalidate();

                _target1 = null;
                _target2 = null;
            }
        }

        private void ctrlRemove_Click(object sender, EventArgs e)
        {
            var remover = NodeControlMenu.SourceControl as Label;
            foreach (var n in BackGround.Controls)
            {
                var from = n as Label;
                var toList = from.Tag as List<Label>;
                toList.Remove(remover);
            }

            BackGround.Controls.Remove(remover);

            for (int i = 0; i < BackGround.Controls.Count; i++)
            {
                BackGround.Controls[i].Text = i + "";
                BackGround.Controls[i].Name = i + "";
            }
            BackGround.Invalidate();
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

            Queue<Node> q = new Queue<Node>();


            foreach (var to in graph[Int32.Parse(_start.Name)])
            { 
                q.Enqueue(new Node(null, to));
                visited.Add(to);
            }

            while (q.Count != 0)
            {
                var cur = q.Dequeue();
                var from = cur.Me;

                foreach (var to in graph[Int32.Parse(from.Name)])
                {
                    if (to == _end)
                    {
                        findPath(cur);
                        return;
                    }
                    if (!visited.Contains(to))
                    {
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

            path.Insert(0,_start);
            path.Add(_end);

            BackGround.Invalidate();
        }


        #endregion

        #region drawLines

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            using Graphics g = e.Graphics;

            var blackpen = new Pen(Color.Black);
            foreach (var n in BackGround.Controls)
            {
                var from = n as Label;
                int x1 = from.Location.X + (40 / 2), y1 = from.Location.Y + (40 / 2);
                foreach (var to in from.Tag as List<Label>)
                {
                    int x2 = to.Location.X + (40 / 2), y2 = to.Location.Y + (40 / 2);
                    g.DrawLine(blackpen, x1, y1, x2, y2);
                }
            }

            var Redpen = new Pen(Color.Red);
            if (path != null)
            {
                List<Point> points = new List<Point>();
                foreach (var from in path)
                {
                    points.Add(new Point(from.Location.X + (40 / 2), from.Location.Y + (40 / 2)));
                }
                g.DrawLines(Redpen, points.ToArray());
            }
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
            {
                if (BackGround.Controls.Count == MAX)
                    return;
                var Node = new Label();
                Node.Size = new Size(40, 40);
                Node.BorderStyle = BorderStyle.FixedSingle;
                Node.Location = new Point(evt.X - (40 / 2), evt.Y - (40 / 2));
                Node.ContextMenuStrip = NodeControlMenu;
                Node.Tag = new List<Label>();
                Point Edge1, Edge2, Edge3, Edge4;

                Edge1 = Node.Location;
                Edge2 = new Point(Node.Location.X + 40, Node.Location.Y);
                Edge3 = new Point(Node.Location.X, Node.Location.Y + 40);
                Edge4 = new Point(Node.Location.X + 40, Node.Location.Y + 40);

                if (Node.GetChildAtPoint(Edge1) != null && Node.GetChildAtPoint(Edge2) != null && Node.GetChildAtPoint(Edge3) != null && Node.GetChildAtPoint(Edge4) != null)
                    return;
                Node.TextAlign = ContentAlignment.MiddleCenter;
                Node.BackColor = Color.AliceBlue;

                Node.Name = BackGround.Controls.Count + "";
                Node.Text = BackGround.Controls.Count + "";
                BackGround.Controls.Add(Node);
            }
        }

        #endregion

    }
}
