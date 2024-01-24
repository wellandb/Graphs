namespace DijkstraShortestPath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DirectedWeightedGraph g = new DirectedWeightedGraph();
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
            g.InsertVertex("Ten");
            g.InsertVertex("Eleven");

            g.InsertEdge("Zero","Three", 2);
            g.InsertEdge("Zero","One", 5);
            g.InsertEdge("Zero","Four", 8);
            g.InsertEdge("One","Four", 2);
            g.InsertEdge("Two","One", 3);
            g.InsertEdge("Two","Five", 4);
            g.InsertEdge("Three","Four", 7);
            g.InsertEdge("Three","Six", 8);
            g.InsertEdge("Four","Five", 9);
            g.InsertEdge("Four","Seven", 4);
            g.InsertEdge("Five","One", 6);
            g.InsertEdge("Six","Seven", 9);
            g.InsertEdge("Six", "Nine",2);
            g.InsertEdge("Seven","Three", 5);
            g.InsertEdge("Seven","Five", 3);
            g.InsertEdge("Seven","Eight", 5);
            g.InsertEdge("Seven", "Ten",2);
            g.InsertEdge("Eight","Five", 3);
            g.InsertEdge("Eight", "Eleven",11);
            g.InsertEdge("Nine", "Ten",3);
            g.InsertEdge("Ten", "Eleven",2);
            g.FindPaths("Zero");
            Console.ReadLine();
            /* Source Vertex: Zero
             * Destination Vertex : Eleven
                Shortest Path is : 0 1 4 7 10 11
                ----------------------------
                Shortest distance is : 15
                ---------------------------- 
            */
        }
    }
}
