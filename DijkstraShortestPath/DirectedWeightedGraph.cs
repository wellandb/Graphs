using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraShortestPath
{
    internal class DirectedWeightedGraph
    {
        public readonly int MAX_VERTICES = 30;
        int n;
        int e;
        int [,] adj;
        Vertex [] vertexList;
        private readonly int TEMPORARY = 1;
        private  readonly  int PERMANENT = 2;
        private  readonly int NIL = -1;
        //used to initiaalise predecessors
        private readonly int INFINITY = 99999;
        //used to initialise path lengths of all vertices.
        public DirectedWeightedGraph()
        {
            adj = new int [MAX_VERTICES, MAX_VERTICES];
            vertexList = new Vertex[MAX_VERTICES];
        }
        private void Dijkstra(int s)
        {
            int v, c;
            //initialise all vertices
            // set all vertices as temporary with path length as infinity and predecessor as NIL
            for (v = 0; v < n; v++)
            {
                vertexList[v].status = TEMPORARY;
                vertexList[v].pathLength = INFINITY;
                vertexList[v].predecessor = NIL;
            }
            
            //set source vertex as 0 with minimum path length.
            vertexList[s].pathLength = 0;
            while(true)
            {
                // set c as current vertex.
                c = TempVertexMinPL();
                //already visited return
                if(c == NIL)
                {
                    // there are no temporary vertices left or all temporary vertices left have path length of infinity
                    // algorithm ends here. End of while loop.
                    return;
                }
                //set status of current vertex as permanent
                vertexList[c].status = PERMANENT;
                for(v = 0; v < n; v++)
                {
                    // check all vertices that are adjacent to current vertex.
                    if(IsAdjacent(c, v) && vertexList[v].status == TEMPORARY)
                        if(vertexList[c].pathLength + adj[c,v] <vertexList[v].pathLength)
                        {
                        //set predecessor and new path length
                            vertexList[v].predecessor = c;
                            vertexList[v].pathLength = vertexList[c].pathLength + adj[c,v];
                        }
                }
            }
        }
        private int TempVertexMinPL()
        {
            int min = INFINITY;
            int x = NIL;
            for (int v = 0; v < n; v++)
            {
                // set as new shortest path length if not visited and path length is smaller than infinity
                if(vertexList[v].status == TEMPORARY && vertexList[v].pathLength < min)
                {
                    min = vertexList[v].pathLength;
                    x = v;
                }
            }
            return x;
        }
        public void FindPaths(String source)
        {
            //set source vertex, starting vertex.
            int s = GetIndex(source);
            // call Dijikstra's algorithm from here.
            Dijkstra(s);
            Console.WriteLine("----------------------------\n");
            Console.WriteLine("Source Vertex : "+source +"\n");
            for(int v = 0; v < n; v++)
            {
                Console.WriteLine("Destination Vertex : "+vertexList[v].name);
                //if path length of any vertex is infinity then vertex is not reachable from source vertex.
                if(vertexList[v].pathLength == INFINITY)
                    Console.WriteLine("There is no path from "+ source +" to vertex "+ vertexList[v].name +"\n");
                else
                {
                    // print shortest path.
                    FindPath(s, v);
                }
            }
        }
        private void FindPath( int s, int v)
        {
            int i, u;
            // array path stores paths from source vertices s to destination vertex v.
            int[] path = new int[n];
            // sd stores shortest distance from source s to destination v
            int sd = 0;
            // count stores number of vertices within the shortest path.
            int count = 0;
            // follow predecessors until we reach source vertex.
            while (v != s)
            {
                count++;
                path[count] = v;
                u = vertexList[v].predecessor;
                sd += adj[u,v];
                v=u;
            }
            count++;
            path[count] = s;
            // print out shortest path and shortest distance.
            Console.Write("Shortest Path is : ");
            for(i = count; i >= 1; i--)
            {
                Console.Write(path[i] +" ");
            }
            Console.WriteLine("\n----------------------------");
            Console.WriteLine("Shortest distance is : "+ sd +"");
            Console.WriteLine("----------------------------\n");
        }
        private int GetIndex(String s)
        {
            for (int i = 0; i < n; i++)
                if (s.Equals(vertexList[i].name))
                {
                    return i;
                }
            throw new System.InvalidOperationException("Invalid Vertex");
        }

        public void InsertVertex(String name)
        {
            // insert a new vertex
            vertexList[n++] = new Vertex(name);
        }
        private bool IsAdjacent(int u, int v)
        {
            return(adj[u, v] != 0);
        }
        /*Insert an edge (s1,s2) */
        public void InsertEdge(String s1,String s2,int wt)
        {
            // insert an edge between vertices.
            int u = GetIndex(s1);
            int v = GetIndex(s2);
            if(u == v)
            {
                throw new System.InvalidOperationException("Not a valid edge"); 
            }
            if(adj[u, v] != 0)
            {
                Console.Write("Edge already present"); 
            }
            else
            {
                adj[u, v] = wt;
                e++;
            }
        }

    }
}
