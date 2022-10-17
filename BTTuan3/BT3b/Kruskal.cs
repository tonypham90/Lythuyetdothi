using BTTuan3;

namespace BT3b;

public class Kruskal
{
    private EDGE[] T;
    private int[] Vmst; //danh dau nhom cua list dinh
    private int MST;
    private int Tn;

    public Kruskal(AdjacencyMatrix g)
    {
        var listEdges = g.listEDGE;
        listEdges = Sort.MergeSortEdges(listEdges);
        T = new EDGE[g.n - 1];
        Vmst = new int[g.n];
        Tn = 0;
        for (int i = 0; i < Vmst.Length; i++)
        {
            Vmst[i] = i;
        }
        // AdjacencyMatrix.showEDGElist(listEdges);
        while (listEdges.Length>0||T.Contains(null))
        {
            var serveyEdge = listEdges[0];
            listEdges = ArrayManipulation.RemoveEdges(listEdges, serveyEdge);
            var revertEdge = new EDGE(serveyEdge.Vertex()[1], serveyEdge.Vertex()[0], serveyEdge.EdgeWeight());
            listEdges = ArrayManipulation.RemoveEdges(listEdges,revertEdge);
            Union(serveyEdge);
        }
        Console.WriteLine("Krukal");
        AdjacencyMatrix.showEDGElist(T);
        var totalweight = ArrayManipulation.TotalWeightEdges(T);
        Console.WriteLine($"Tong so cay khung {totalweight}");
        

    }

    private int FindParent(int Child)
    {
        
        if (Child!=Vmst[Child])
        {
            return FindParent(Vmst[Child]);
        }
        return Child;
    }

    private void Union(EDGE edge)
    {
        int firstNode = edge.Vertex()[0];
        int secondNode = edge.Vertex()[1];
        int firstNodeparent = FindParent(firstNode);
        int secondNodeParent = FindParent(secondNode);
        if (firstNodeparent == secondNodeParent) return;
        if (Vmst.Count(element=>element==firstNodeparent) < Vmst.Count(element=>element==secondNodeParent))
        {
            updateVmst(firstNodeparent, secondNodeParent);
        }
        updateVmst(secondNodeParent,firstNodeparent);
        T[Tn] = edge;
        Tn++;

    }

    private void updateVmst(int firstNodeparent, int secondNodeParent)
    {
        for (int i = 0; i < Vmst.Length; i++)
        {
            if (Vmst[i]==firstNodeparent)
            {
                Vmst[i] = secondNodeParent;
            }
        }
    }
}