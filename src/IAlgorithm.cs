using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using PathFindingAlgorithms.CustomControls;

namespace PathFindingAlgorithms
{
    interface IAlgorithm
    {
        #region PathFind-BFS
        public void PathFinding_BFS(VertexLabel startVertexLabel, VertexLabel destVertexLabel)
        {
            var q = new Queue<VertexLabel>();
            var visitList = new List<VertexLabel>();

            q.Enqueue(startVertexLabel);
            visitList.Add(startVertexLabel);

            while (q.Count != 0)
            {
                var from = q.Dequeue();
 
                if (from == destVertexLabel)
                {
                    trackBFS(destVertexLabel);
                    return;
                }

                foreach (VertexLabel to in ((Dictionary<VertexLabel, int>)@from.Tag).Keys)
                {
                    if (!visitList.Contains(to))
                    {
                        to.Predecessor = from;
                        q.Enqueue(to);
                        visitList.Add(to);
                    }
                }
            }
        }

        public void trackBFS(VertexLabel destVertexLabel) 
        {
            List<VertexLabel> path = new List<VertexLabel>();
            while (destVertexLabel != null)
            {
                path.Add(destVertexLabel);
                destVertexLabel = destVertexLabel.Predecessor;
            }

            path.Reverse();
            foreach (var p in path)
                p.BackColor = Control.DefaultBackColor;
            
            foreach (var p in path)
                p.BackColor = Color.DarkMagenta;
        }


        #endregion

        #region PathFind-A*
    


        #endregion

        #region PathFind-Dijkstra

        

        #endregion

    }
}
