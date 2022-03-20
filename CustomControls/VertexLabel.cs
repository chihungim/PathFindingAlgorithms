using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Windows.Forms;
using PathFindingAlgorithms.CustomControls;

namespace PathFindingAlgorithms.CustomControls
{
    public class VertexLabel : Label
    {
        public VertexLabel Predecessor { get; set;}
        public static readonly Size DefaultVertexSize = new Size(30, 30);
        public static readonly Color DefaultVertexColor = Color.Chartreuse;
        public int Radius = 30;

        public VertexLabel(Point point, String name)
        {
            init(point, name);
        }

        #region RoundLabel

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private GraphicsPath GetRoundRectagle(Rectangle bounds, int radius)
        {
            float r = radius;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(bounds.Left, bounds.Top, r, r, 180, 90);
            path.AddArc(bounds.Right - r, bounds.Top, r, r, 270, 90);
            path.AddArc(bounds.Right - r, bounds.Bottom - r, r, r, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - r, r, r, 90, 90);
            path.CloseFigure();
            return path;
        }
        private void RecreateRegion()
        {
            var bounds = ClientRectangle;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(bounds.Left, bounds.Top,
                bounds.Right, bounds.Bottom, Radius, 30));
            this.Invalidate();
        }


        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.RecreateRegion();
        }

        #endregion


        void init(Point point, String name)
        {
            DoubleBuffered = true;
            Name = name;
            Tag = new Dictionary<VertexLabel, int>(); //key as object
            Size = DefaultVertexSize;
            Location = new Point(point.X - DefaultVertexSize.Width / 2, point.Y - DefaultVertexSize.Height / 2);
            //BorderStyle = BorderStyle.FixedSingle;
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


