using System;
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

        enum Algorithms
        {
            Bfs = 0,
            Dijkstra = 1,
            AStar = 2
        }

        Action<VertexLabel, VertexLabel> PathFinding_Algorithm(Algorithms index)
        {
            if (index == Algorithms.Bfs)
                return PathFinding_BFS;
            else if(index == Algorithms.Dijkstra)
                return PathFinding_Dijkstra;
            else if (index == Algorithms.AStar)
                return PathFinding_AStar;
            else
                return null;

        }

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
                    Trace_BFS(destVertexLabel);
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
        public void Trace_BFS(VertexLabel destVertexLabel) 
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
        
        #region PathFind-Dijkstra
        void PathFinding_Dijkstra(VertexLabel start, VertexLabel end)
        {
            const int inf = 1000000000;
            var g = start.Parent as GraphPanel;
            var visited = new List<VertexLabel>();
            var dist = new Dictionary<VertexLabel, int>();

            foreach (VertexLabel vertex in g.Controls)
                dist.Add(vertex, inf); 

            dist[start] = 0;
            start.Predecessor = null;

            while (true)
            {
                VertexLabel from = null;
                int min = Int32.MaxValue;
                foreach (VertexLabel vertex in g.Controls)
                {
                    if (visited.Contains(vertex)) continue;

                    if (dist[vertex] == Int32.MaxValue) continue;

                    if (dist[vertex] < min)
                    {
                        min = dist[vertex];
                        from = vertex;
                    }
                }

                if (from == null)
                    break;

                visited.Add(from);

                foreach (VertexLabel next in g.Controls)
                {
                    if(next == from) continue;
                    if (visited.Contains(next)) continue;
                    var adj = (Dictionary<VertexLabel, int>)from.Tag;
                    var nextDist = dist[from] + (adj.ContainsKey(next) ? adj[next] :inf );
                    if (nextDist >= dist[next]) continue;
                    dist[next] = nextDist;
                    next.Predecessor = @from;
                }
            }
            Trace_Dijkstra(end);
        }

        void Trace_Dijkstra(VertexLabel dest)
        {
            List<VertexLabel> path = new List<VertexLabel>();
            while (dest != null)
            {
                path.Add(dest);
                dest = dest.Predecessor;
            }

            if (path.Count < 2)
            {
                return;
            }


            path.Reverse();

            foreach (VertexLabel v in path)
                v.BackColor = Color.DarkMagenta;
        }
        #endregion 

        #region PathFind-A*
        
        public void PathFinding_AStar(VertexLabel start, VertexLabel end)
        {
            
            var visited = new List<VertexLabel>();
            var dist = new Dictionary<VertexLabel, int>();
            
            var pq = new PriorityQueue<KeyValuePair<int,VertexLabel>, int>();
            pq.Enqueue(new KeyValuePair<int, VertexLabel>(0,start), 0);
            bool success = false;
            while (pq.Count != 0)
            {
                var v = pq.Dequeue();
                var cost = v.Key;
                var vertex = v.Value;
                if (vertex == end)
                {
                    success = true;
                    break;
                }
            }
        }
        
        #endregion

    }
}
