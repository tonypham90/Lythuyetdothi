using BTTuan3;

namespace BT3a;

public class Prim
{
    // private bool[] marked;
    private int nT; //So Canh cay T
    private EDGE[] T; //Canh khung
    private int MST;

    public Prim(AdjacencyMatrix g)
    {
        T = new EDGE[g.n - 1];
        nT = 0;
        List<int> Vertex = new List<int>();
        for (int i = 0; i < g.n; i++)
        {
            Vertex.Add(i);
        }

        var Vmst = new List<int>();
        int FirstVertex = Vertex[0];
        Vmst.Add(FirstVertex);
        Vertex.RemoveAt(0);
        
        // marked = new bool[g.n];
        // for (var i = 0; i < marked.Length; i++) marked[i] = false;
        EDGE[] graphEdge = g.listEDGE;
        // marked[0] = true;
        while (Vertex.Count>0)
        {
            List<EDGE> serveyList = new List<EDGE>();
            foreach (var v in Vmst)
            {
                foreach (var edge in graphEdge)
                {
                    if (edge.Vertex()[0]==v && Vertex.Contains(edge.Vertex()[1]))
                    {
                        serveyList.Add(edge);
                    }
                }
            }

            if (serveyList.Count==0)
            {
                break;
            }

            EDGE[] serveyEdges = serveyList.ToArray();
            if (serveyEdges.Length > 1)
            {
                serveyEdges = Sort.MergeSortEdges(serveyEdges);
            }
            //Dich Dinh da xet qua vung dinh da xet
            int movingnode = serveyEdges[0].Vertex()[1];
            Vertex.Remove(movingnode);
            Vmst.Add(movingnode);
            EDGE edgeremove = new EDGE(serveyEdges[0].Vertex()[1], serveyEdges[0].Vertex()[0], serveyEdges[0].EdgeWeight());
            graphEdge = ArrayManipulation.RemoveEdges(graphEdge, serveyEdges[0]);
            graphEdge = ArrayManipulation.RemoveEdges(graphEdge, edgeremove);
            T[nT] = serveyEdges[0];
            nT++;
            
            graphEdge = ArrayManipulation.RemoveEdges(graphEdge, serveyEdges[0]);

        }
        Console.WriteLine("Prim");
        Console.WriteLine("Danh Sách canh cây khung nhỏ nhất");
        AdjacencyMatrix.showEDGElist(T);
        MST = EDGE.MSTCaculation(T);
        Console.WriteLine($"Trong so cua cay khung: {MST}");

    }
    
}