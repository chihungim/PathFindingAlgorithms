using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;


namespace PathFindingAlgorithms.BFS
{
    

    public partial class BFS_Graph : Form
    {
        private Label _target1, _target2;
        private int _start, _end = 0;
        private const int MaxCount = 100001;
        private List<int> []graph = new List<int>[MaxCount];
        private List<Label> _nodeList = new List<Label>();
        private Graphics g;
        public BFS_Graph()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var remover = NodeControlMenu.SourceControl as Label;

            foreach (var n in panel1.Controls)
            {
                var from = n as Label;
                var toList = from.Tag as List<Label>;
                toList.Remove(remover);
            }
            _nodeList.Remove(remover);
            panel1.Controls.Remove(remover);
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
                
                using Graphics g = e.Graphics;
                
                var blackpen = new Pen(Color.Black);
                foreach (var n in panel1.Controls)
                {
                    var from = n as Label;
                    int x1 = from.Location.X + (40 / 2), y1 = from.Location.Y + (40 / 2);
                    foreach (var to in from.Tag as List<Label>)
                    {
                        int x2 = to.Location.X + (40 / 2), y2 = to.Location.Y + (40 / 2);
                        g.DrawLine(blackpen, x1, y1, x2, y2);
                    }
                }
        }


        private void ctrlConnect_Click(object sender, EventArgs e)
        {
            if (_target1 == null)
            {
                _target1 = (Label)NodeControlMenu.SourceControl;
                _target1.BackColor = Color.Aqua;
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
                _target1.BackColor = Color.Transparent;

                var toList = _target1.Tag as List<Label>;
                toList.Add(_target2);
                var fromList = _target1.Tag as List<Label>;
                fromList.Add(_target1);

                panel1.Invalidate();

                _target1 = null;
                _target2 = null;
            }
        }


        private void panel1_Click(object sender, EventArgs e)
        {
            var evt = (MouseEventArgs)e;

            if (evt.Button == MouseButtons.Left)
            {
                var Node = new Label();
                Node.Size = new Size(40, 40);
                Node.BorderStyle = BorderStyle.FixedSingle;
                Node.Location = new Point(evt.X - (40/2),evt.Y - (40/2));
                Node.ContextMenuStrip = NodeControlMenu;
                Node.Tag = new List<Label>();
                Node.Name = _nodeList.Count + "";
                if (Node.GetChildAtPoint(Node.Location) != null)
                    return;
                Node.TextAlign = ContentAlignment.MiddleCenter;
                Node.Text = _nodeList.Count + "";
                panel1.Controls.Add(Node);
                _nodeList.Add(Node);
            }
        }
    }
}
