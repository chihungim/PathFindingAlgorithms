using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CustomControls
{
    class GraphPanel : Panel
    {
        private const Int64 Max = 255;
        private readonly Size _defaultVertexSize = new Size(40, 40);
        private readonly  Color _defaultVertexColor = Color.Aqua;

        public GraphPanel(Panel graph)
        {
            this.Paint += Graph_Paint; //draw event
        }

        #region Draw Edge
        public void Graph_Paint(Object sender, PaintEventArgs e)
        {
            using var g = e.Graphics;

            var blackPen = new Pen(Color.Black);
                               
            foreach (Label from in Controls)
            {
                int x1 = from.Location.X + _defaultVertexSize.Width/2, y1 = from.Location.Y + _defaultVertexSize.Height / 2;
                foreach (var to in (List<Label>)@from.Tag)
                {
                    int x2 = to.Location.X + _defaultVertexSize.Width / 2, y2 = to.Location.Y + _defaultVertexSize.Height / 2;
                    g.DrawLine(blackPen, x1, y1, x2, y2);
                }
            }
        }
        #endregion
        #region Vertex Control
        public Label AddVertexLabel(Point position)
        {
            if (Controls.Count == Max)
            {
                Debug.Print("Cannot Add More then 255 Nodes");
                return null;
            }

            var vertex = new Label();
            vertex.Size = _defaultVertexSize;
            vertex.Tag = new List<Label>();
            vertex.Location = new Point(position.X - _defaultVertexSize.Width / 2, position.Y - _defaultVertexSize.Height / 2);
            vertex.BorderStyle = BorderStyle.FixedSingle;
            vertex.BackColor = _defaultVertexColor;
            vertex.Name = Controls.Count + "";
            Controls.Add(vertex);
            return vertex;
        }

        public void CreateEdge(Label from, Label to)
        {
            var fromList = from.Tag as List<Label>;
            var toList = to.Tag as List<Label>;

            if (fromList.Contains(to))
            {
                Debug.Print("These Nodes are already connected");
                return;
            }
            //undirected graph
            fromList.Add(to);
            toList.Add(from);
            Invalidate();

        }

        public void RemoveVertexLabel(Label vertexLabel)
        {
            //Find the connection and remove
            foreach(Label from in Controls)
            {
                var toList = from.Tag as List<Label>;
                if (toList.Contains(vertexLabel))
                    toList.Remove(vertexLabel);
            }

            Controls.Remove(vertexLabel);
            Invalidate();
        }
        #endregion
    }
}
