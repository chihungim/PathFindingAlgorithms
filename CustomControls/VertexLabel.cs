using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using PathFindingAlgorithms.CustomControls;

namespace PathFindingAlgorithms.CustomControls
{
    internal sealed class VertexLabel : Label
    {
        public VertexLabel Predecessor { get; set;}
        public static readonly Size DefaultVertexSize = new Size(20, 20);
        public static readonly Color DefaultVertexColor = Color.Aqua;
        public VertexLabel(Point point, String name)
        {
            init(point, name);
        }

        void init(Point point, String name)
        {
            Name = name;
            Tag = new Dictionary<VertexLabel, int>(); //key as object
            Size = DefaultVertexSize;
            Location = new Point(point.X - DefaultVertexSize.Width / 2, point.Y - DefaultVertexSize.Height / 2);
            BorderStyle = BorderStyle.FixedSingle;
            BackColor = DefaultVertexColor;
            Predecessor = null;
        }

        public void CreateEdge(VertexLabel vertex)
        {
            var connectionList = Tag as Dictionary<VertexLabel, int>;

            if (connectionList.ContainsKey(vertex))
            {
                Debug.Print("These Nodes are already connected");
                return;
            }
            //undirected graph
            Vector2 fromVector = new Vector2(Location.X + VertexLabel.DefaultVertexSize.Width / 2,
                Location.Y + VertexLabel.DefaultVertexSize.Height / 2);
            Vector2 toVector = new Vector2(vertex.Location.X + VertexLabel.DefaultVertexSize.Width / 2,
                vertex.Location.Y + VertexLabel.DefaultVertexSize.Height / 2);
            connectionList.Add(vertex, (int)Vector2.Distance(fromVector, toVector));
        }

    }
}


