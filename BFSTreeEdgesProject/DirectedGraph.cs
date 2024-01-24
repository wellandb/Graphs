using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFSTreeEdgesProject
{
    internal class DirectedGraph
    {
        public readonly int MAX_VERTICES = 30;
        int n;
        int e;
        bool[,] adj;
        Vertex[] vertexList;
        /* constants for different states of a vertex */
        private readonly int INITIAL = 0;
        private readonly int WAITING = 1;
        private readonly int VISITED = 2;

        public DirectedGraph()
        {
            adj = new bool[MAX_VERTICES, MAX_VERTICES];
            vertexList = new Vertex[MAX_VERTICES];
        }

        public void BfsTreeEdges()
        {
            // Set all vertices to initial
            int v;
            for(v = 0; v < n; v++)
                vertexList[v].state = INITIAL;

            Console.Write("Enter starting vertex for Breadth FirstSearch : ");
            String s = Console.ReadLine();
            // Perform BFS on starting vertex
            BfsTree( GetIndex(s) );
            //Perform BFS on all unvisited vertices
            for(v = 0; v < n; v++)
                if(vertexList[v].state == INITIAL)
                    BfsTree(v);
        }
        // Perform BFS on the graph from a vertex printing the edges of visited vertices
        private void BfsTree( int v)
        {
            // Create queue to store vertices
            Queue<int> qu = new Queue<int>();
            // Add starting Vertex to queue
            qu.Enqueue(v);
            vertexList[v].state = WAITING;
            // While queue isn't empty
            while( qu.Count!=0 )
            {
                // Get first vertex from queue
                v = qu.Dequeue();
                // Set to visited
                vertexList[v].state = VISITED;
                // Loop through vertices
                for(int i = 0; i < n; i++)
                {
                    // If vertex is adjacent to current vertex and unvisited
                    if(IsAdjacent(v,i) && vertexList[i].state == INITIAL)
                    {
                        // Add vertex to queue, set state to waiting and print the edge
                        qu.Enqueue(i);
                        vertexList[i].state=WAITING;
                        Console.WriteLine("Tree Edge : ("+vertexList[v].name +","+vertexList[i].name +")");
                    }
                }
            }
            Console.WriteLine();
        }

        // Set all vertices to initial and perform BFS on given vertex 
        public void BfsTraversal()
        {
            for (int v = 0; v < n; v++)
                vertexList[v].state = INITIAL;
            Console.Write("Enter starting vertex for Breadth FirstSearch : ");
            String s = Console.ReadLine();
            Bfs(GetIndex(s));
        }
        // Perform BFS on the graph from a vertex printing the names of visited vertices
        private void Bfs(int v)
        {
            Queue<int> qu = new Queue<int>();
            qu.Enqueue(v);
            vertexList[v].state = WAITING;
            while (qu.Count != 0)
            {
                v = qu.Dequeue();
                Console.Write(vertexList[v].name + " ");
                vertexList[v].state = VISITED;
                for (int i = 0; i < n; i++)
                {
                    if (IsAdjacent(v, i) && vertexList[i].state == INITIAL)
                    {
                        qu.Enqueue(i);
                        vertexList[i].state = WAITING;
                    }
                }
            }
            Console.WriteLine();
        }
        // Perform BFS on the graph from a given stating vertex then print the rest of the graph of unvisited vertices
        public void BfsTraversal_All()
        {
            int v;
            for (v = 0; v < n; v++)
                vertexList[v].state = INITIAL;
            Console.Write("Enter starting vertex for BreadthFirstSearch : ");
            String s = Console.ReadLine();
            Bfs(GetIndex(s));
            for (v = 0; v < n; v++)
                if (vertexList[v].state == INITIAL)
                    Bfs(v);
        }

        public void InsertVertex(String name)
        {
            vertexList[n++] = new Vertex(name);
        }
        private int GetIndex(String s)
        {
            for (int i = 0; i < n; i++)
                if (s.Equals(vertexList[i].name))
                    return i;
            throw new System.InvalidOperationException("Invalid Vertex");
        }
        private bool IsAdjacent(int u, int v)
        {
            return adj[u, v];
        }
        /*Insert an edge (s1,s2) */
        public void InsertEdge(String s1, String s2)
        {
            int u = GetIndex(s1);
            int v = GetIndex(s2);
            if (u == v)
                throw new System.InvalidOperationException("Not a valid edge");
            if (adj[u, v] == true)
                Console.Write("Edge already present");
            else
            {
                adj[u, v] = true;
                e++;
            }
        }
    }
}
