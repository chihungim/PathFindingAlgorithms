using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PathFindingAlgorithms.CustomControls
{
    class GraphPanel : Panel
    {
        private const Int64 Max = 255;
        public GraphPanel()
        {
            Init();
        }

        void Init()
        {
            this.Paint += Graph_Paint; //draw event
            BorderStyle = BorderStyle.FixedSingle;
        }

        

        #region Draw Edge
        public void Graph_Paint(Object sender, PaintEventArgs e)
        {
            using var g = e.Graphics;

            var blackPen = new Pen(Color.Black);
                               
            foreach (Label from in Controls)
            {
                int x1 = from.Location.X + VertexLabel.DefaultVertexSize.Width/2, y1 = from.Location.Y + VertexLabel.DefaultVertexSize.Height / 2;
                foreach (var to in ((Dictionary<VertexLabel,int>)@from.Tag).Keys)
                {
                    int x2 = to.Location.X + VertexLabel.DefaultVertexSize.Width / 2, y2 = to.Location.Y + VertexLabel.DefaultVertexSize.Height / 2;
                    g.DrawLine(blackPen, x1, y1, x2, y2);
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
            Controls.Add(vertex);
            return vertex;
        }

        public void CreateEdge(VertexLabel from, VertexLabel to)
        {
            var fromList = from.Tag as Dictionary<VertexLabel, int>;
            var toList = to.Tag as Dictionary<VertexLabel, int>;

            if (fromList.ContainsKey(to))
            {
                Debug.Print("These Nodes are already connected");
                return;
            }
            //undirected graph
            Vector2 fromVector = new Vector2(from.Location.X + VertexLabel.DefaultVertexSize.Width / 2,
                from.Location.Y + VertexLabel.DefaultVertexSize.Height / 2);
            Vector2 toVector = new Vector2(to.Location.X + VertexLabel.DefaultVertexSize.Width / 2,
                to.Location.Y + VertexLabel.DefaultVertexSize.Height / 2);
            fromList.Add(to, (int)Vector2.Distance(fromVector,toVector));
            toList.Add(from, (int)Vector2.Distance(fromVector, toVector));
            Invalidate();

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
