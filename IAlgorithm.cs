using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
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
            const int inf = 1000000000;
            var graph = start.Parent as GraphPanel;
            //from start to n distance
            Func<VertexLabel, int> g = n =>  
            {
                var startVector2 = new Vector2(start.Location.X + VertexLabel.DefaultVertexSize.Width / 2,
                    start.Location.Y + VertexLabel.DefaultVertexSize.Height / 2);
                var toVector2 = new Vector2(n.Location.X + VertexLabel.DefaultVertexSize.Width / 2,
                    n.Location.Y + VertexLabel.DefaultVertexSize.Height / 2);

                return (int) Vector2.Distance(startVector2, toVector2);
            };
            //from end to n distance
            Func<VertexLabel, int> h = n =>
            {
                var endVector2 = new Vector2(end.Location.X + VertexLabel.DefaultVertexSize.Width / 2,
                    end.Location.Y + VertexLabel.DefaultVertexSize.Height / 2);
                var toVector2 = new Vector2(n.Location.X + VertexLabel.DefaultVertexSize.Width / 2,
                    n.Location.Y + VertexLabel.DefaultVertexSize.Height / 2);
                return (int) Vector2.Distance(endVector2, toVector2);
            };

            var pq = new PriorityQueue<VertexLabel, int>();
            pq.Enqueue(start,  h(start));

            var gCost = new Dictionary<VertexLabel, int>();
            foreach (VertexLabel vertex in graph.Controls)
                gCost.Add(vertex, inf);
            gCost[start] = 0;

            var fCost = new Dictionary<VertexLabel, int>();
            foreach (VertexLabel vertex in graph.Controls)
                fCost.Add(vertex, inf);

            fCost[start] = h(start);
            

            while (pq.Count != 0)
            {
                var current = pq.Dequeue();

                if (current == end)
                {
                    Trace_AStar(current);
                    return;
                }

                var d = current.Tag as Dictionary<VertexLabel, int>;
                foreach (var neighbor in d.Keys)
                {
                    var nextCost = gCost[current] + d[neighbor]; 
                    Debug.Print(nextCost.ToString());
                    if (nextCost < gCost[neighbor])
                    {
                        neighbor.Predecessor = current;
                        gCost[neighbor] = nextCost;
                        fCost[neighbor] = nextCost + h(neighbor);
                        pq.Enqueue(neighbor, fCost[neighbor]);
                    }
                }
            }
        }


        void Trace_AStar(VertexLabel end)
        {
            List<VertexLabel> path = new List<VertexLabel>();
            while (end != null)
            {
                path.Add(end);
                end = end.Predecessor;
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

    }
}
