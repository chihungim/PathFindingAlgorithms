using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PathFindingAlgorithms.Form
{
    public partial class PathFindingGrid : System.Windows.Forms.Form
    {
        private Thread _animationThread = null;
        Label[,] _map = null;
        private Label _start = null;
        private Label _end = null;

        #region init
        public PathFindingGrid()
        {
            InitializeComponent();
            IntializeMap();
        }

        void IntializeMap()
        {
            Grid1.BorderStyle = BorderStyle.FixedSingle;
            _map = new Label[Grid1.RowCount, Grid1.ColumnCount];
            for (var i = 0; i < Grid1.RowCount; i++)
            {
                for (var j = 0; j < Grid1.ColumnCount; j++)
                {
                    _map[i, j] = new Label();
                    Grid1.Controls.Add(_map[i, j], i, j);
                    _map[i, j].BackColor = Color.MediumTurquoise;
                    _map[i, j].Dock = DockStyle.Fill;
                    _map[i, j].BorderStyle = BorderStyle.FixedSingle;
                    _map[i, j].Margin = new Padding(0);
                    _map[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    _map[i, j].Name = i + "," + j;
                    _map[i, j].Click += (sender, e) =>
                    {
                        var me = (Label)sender;
                        var evt = (MouseEventArgs)e;
                        switch (evt.Button)
                        {
                            case MouseButtons.Left: //start
                                if (_start != null)
                                {
                                    _start.BackColor = Color.MediumTurquoise;
                                    _start.Text = "";
                                }
                                me.BackColor = Color.Red;
                                me.Text = @"Start";
                                _start = me;
                                break;
                            case MouseButtons.Right: //end
                                if (_end != null)
                                {
                                    _end.BackColor = Color.MediumTurquoise;
                                    _end.Text = "";
                                }
                                me.BackColor = Color.Red;
                                me.Text = @"End";
                                _end = me;
                                break;
                            default: //
                                if (me.BackColor == Color.DarkSlateGray)
                                {
                                    me.BackColor = Color.MediumTurquoise;
                                    me.Text = "";
                                }
                                else
                                {
                                    me.BackColor = Color.DarkSlateGray;
                                    me.Text = "";
                                }
                                break;
                        }
                    };
                }
            }
        }

        #endregion


        #region ctrl

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

        private void button1_Click(object sender, EventArgs e)
        {
            _start = null;
            _end = null;
            if (_animationThread != null)
                _animationThread.Interrupt();
            foreach (var m in _map)
            {
                m.Tag = null;
                m.BackColor = Color.MediumTurquoise;
                m.Text = "";
            }
        }

        #endregion


        #region findPath

        private void button2_Click(object sender, EventArgs e)
        {
            if (_animationThread != null)
                _animationThread.Interrupt();
            if (_start == null || _end == null)
            {
                MessageBox.Show(@"Select the start point or the end point ");
                return;
            }

            foreach (var m in _map)
            {
                if (m.BackColor == Color.Violet) m.BackColor = Color.MediumTurquoise;
            }


            int[] dirR = { 0, 1, 0, -1, 1, -1, 1, -1 };
            int[] dirC = { 1, 0, -1, 0, 1, -1, -1, 1 };

            if (radioButton1.Checked)
            {
                dirR = new int[] { 0, 1, 0, -1 };
                dirC = new int[] { 1, 0, -1, 0 };
            }


            List<Label> visited = new List<Label>();
            Queue<Node> q = new Queue<Node>();

            visited.Add(_start);

            q.Enqueue(new Node(_start, null));
            while (q.Count > 0)
            {
                var cur = q.Dequeue();
                var pos = toPoint(cur.Me.Name);

                cur.Me.BackColor = Color.Chartreuse;

                if (cur.Me == _end)
                {
                    FindPath(cur);
                    return;
                }

                for (int i = 0; i < dirR.Length; i++)
                {
                    int dr = pos.Y + dirR[i], dc = pos.X + dirC[i];
                    if (!IsIn(dr, dc) || visited.Contains(_map[dr, dc]) ||
                        _map[dr, dc].BackColor == Color.DarkSlateGray) continue;
                    Thread.Sleep(100);
                    Application.DoEvents();
                    q.Enqueue(new Node(_map[dr, dc], cur));
                    visited.Add(_map[dr, dc]);
                }
            }

            MessageBox.Show(@"Failed to Find path");
        }

        void FindPath(Node dest)
        {
            Node temp = dest;
            List<Label> path = new List<Label>();
            while (temp != null)
            {
                path.Add(temp.Me);
                temp = temp.From;
            }

            path.Reverse();

            _animationThread = new Thread(() =>
            {
                try
                {
                    foreach (var p in path)
                    {
                        p.BackColor = Color.Violet;
                        Thread.Sleep(100);
                    }

                }
                catch (ThreadInterruptedException e)
                {

                }
            });

            _animationThread.Start();
        }

        class Node
        {
            private Node from;
            private Label me;
            public Node From => from;
            public Label Me => me;
            public Node(Label _me, Node _from)
            {
                me = _me;
                from = _from;
            }

        };

        bool IsIn(int row, int col)
        {
            return (row > -1 && row < Grid1.RowCount) && (col > -1 && col < Grid1.ColumnCount);
        }

        Point toPoint(String coordinate)
        {
            int r = Int32.Parse(coordinate.Split(',')[0]);
            int c = Int32.Parse(coordinate.Split(',')[1]);
            return new Point(c, r);
        }

        #endregion



    }
}
