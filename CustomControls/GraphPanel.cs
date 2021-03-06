using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using PathFindingAlgorithms;
using PathFindingAlgorithms.CustomControls;

namespace PathFindingAlgorithms.CustomControls
{
    class GraphPanel : Panel, IAlgorithm
    {
        public VertexControlMenu VertexControlMenu;
        private const Int64 Max = 255;
        public GraphPanel()
        {
            Init();
        }

        void Init()
        {
            this.Paint += Graph_Paint; //draw event
            this.Click += (sender, args) =>
            {
                var evt = args as MouseEventArgs;
                if (evt.Button == MouseButtons.Left) AddVertexLabel(evt.Location);
            };
            BackgroundImageLayout = ImageLayout.Stretch;
            BorderStyle = BorderStyle.FixedSingle;
            VertexControlMenu = new VertexControlMenu(this);
        }

        
        #region Draw Edge
        public void Graph_Paint(Object sender, PaintEventArgs e)
        {
            using var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var greenPen = new Pen(Color.ForestGreen);
                               
            foreach (Label from in Controls)
            {
                var dist = from.Tag as Dictionary<VertexLabel, int>;
                int x1 = from.Location.X + VertexLabel.DefaultVertexSize.Width/2, y1 = from.Location.Y + VertexLabel.DefaultVertexSize.Height / 2;
                foreach (var to in ((Dictionary<VertexLabel,int>)@from.Tag).Keys)
                {
                    int x2 = to.Location.X + VertexLabel.DefaultVertexSize.Width / 2, y2 = to.Location.Y + VertexLabel.DefaultVertexSize.Height / 2;
                    g.DrawLine(greenPen, x1, y1, x2, y2);
                    var s = g.MeasureString(dist[to] + "", Font);
                    g.DrawString(dist[to]+"", Font,Brushes.DeepPink ,((x1+x2)/2) - s.Width/2, ((y1+y2)/2) - s.Height/2);
                }
            }
        }
        #endregion

        #region VertexControl
        public void RemoveAllVertex()
        {
            Controls.Clear();
            Invalidate();
        }

        public Label AddVertexLabel(Point position)
        {
            if (Controls.Count == Max)
            {
                Debug.Print("Cannot Add More then 255 Nodes");
                return null;
            }
            var vertex = new VertexLabel(position, Controls.Count + "");
            vertex.ContextMenuStrip = VertexControlMenu;


            Controls.Add(vertex);
            return vertex;
        }

        public void RemoveVertexLabel(VertexLabel vertexLabel)
        {
            //Find the connection and remove
            foreach(VertexLabel from in Controls)
            {
                var toList = from.Tag as Dictionary<VertexLabel, int>;
                if (toList.ContainsKey(vertexLabel))
                    toList.Remove(vertexLabel);
            }

            Controls.Remove(vertexLabel);
            Invalidate();
        }
        #endregion
    }
}


class VertexControlMenu : ContextMenuStrip
{
    private ToolStripMenuItem _ctrlRemove ,_ctrlConnect,_ctrlToStart,_ctrlToEnd;

    public VertexLabel Start, End;
    private VertexLabel _target1, _target2;
    private readonly GraphPanel _graphPanel;

    public VertexControlMenu(GraphPanel graphPanel)
    {
        this._graphPanel = graphPanel;
        InitItems();
    }

    private void InitItems()
    {
        Items.Add(_ctrlConnect = new ToolStripMenuItem("From", null, (sender, args) =>
        {
            if (_target1 == null)
            {
                _target1 = (VertexLabel)SourceControl;
                _ctrlConnect.Text = @"To";
            }
            else if (_target2 == null)
            {
                _target2 = (VertexLabel)SourceControl;
                var graph = _target2.Parent as GraphPanel;
                if (_target1 == _target2)
                {
                    _target2 = null;
                    return;
                }

                _ctrlConnect.Text = @"From";
                _target1.CreateEdge(_target2);
                _target2.CreateEdge(_target1);
                _target1 = null;
                _target2 = null;
                graph.Invalidate();
            }
        }));
        Items.Add(_ctrlToStart =
            new ToolStripMenuItem("start", null, (sender, args) => Start = SourceControl as VertexLabel));
        Items.Add(_ctrlToEnd =
            new ToolStripMenuItem("dest", null, (sender, args) =>  End = SourceControl as VertexLabel));

        Items.Add(_ctrlRemove = new ToolStripMenuItem("Remove", null, (sender, args) =>
        {
            var vertex = SourceControl as VertexLabel;


            if (vertex == _target1)
            {
                _target1 = null;
                _ctrlConnect.Text = @"From";
            }

            if (vertex == Start)
            {
                Start = null;
                _ctrlConnect.Text = @"From";
            }

            if (vertex == End)
            {
                End = null;
                _ctrlConnect.Text = @"From";
            }
            _graphPanel.RemoveVertexLabel(vertex);
        }));
    }
}


