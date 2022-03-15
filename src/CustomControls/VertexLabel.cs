using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PathFindingAlgorithms.CustomControls
{
    internal sealed class VertexLabel : Label
    {
        public VertexLabel Predecessor { get; set;}
        public static readonly Size DefaultVertexSize = new Size(20, 20);
        public static readonly Color DefaultVertexColor = Color.Aqua;
        public VertexLabel(Point point, String name)
        {
            Name = name;
            Tag = new Dictionary<VertexLabel, int>(); //key as object
            Size = DefaultVertexSize;
            Location = new Point(point.X - DefaultVertexSize.Width / 2, point.Y - DefaultVertexSize.Height / 2);
            BorderStyle = BorderStyle.FixedSingle;
            BackColor = DefaultVertexColor;
            Predecessor = null;
        }
        
    }
}
