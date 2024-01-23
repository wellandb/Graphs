namespace BFSTreeEdgesProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DirectedGraph g = new DirectedGraph();
            g.InsertVertex("Zero");
            g.InsertVertex("One");
            g.InsertVertex("Two");
            g.InsertVertex("Three");
            g.InsertVertex("Four");
            g.InsertVertex("Five");
            g.InsertVertex("Six");
            g.InsertVertex("Seven");
            g.InsertVertex("Eight");
            g.InsertVertex("Nine");
            g.InsertEdge("Zero","One");
            g.InsertEdge("Zero","Three");
            g.InsertEdge("One","Two");
            g.InsertEdge("One","Four");
            g.InsertEdge("One","Five");
            g.InsertEdge("Two","Three");
            g.InsertEdge("Two","Five");
            g.InsertEdge("Three","Six");
            g.InsertEdge("Four","Five");
            g.InsertEdge("Four","Seven");
            g.InsertEdge("Five","Six");
            g.InsertEdge("Five","Eight");
            g.InsertEdge("Six","Eight");
            g.InsertEdge("Six","Nine");
            g.InsertEdge("Seven","Eight");
            g.InsertEdge("Eight","Nine");
            g.BfsTreeEdges();
            Console.ReadLine();
            // Performs BFS on the node given to the program and gives the edges that it travels along
            // Then loops through the node array and performs BFS on the nodes that are still unvisited giving the other forests
        }
    }
}
