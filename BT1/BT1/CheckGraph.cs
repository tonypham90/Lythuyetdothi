namespace BT1;

public class CheckGraph
{
    public bool IsUndirectedGraph(AdjacencyMatrix g)
    {
        int i, j;
        bool isSymmetric = true;
        for (i = 0; i < g.n && isSymmetric; ++i)
        {
            for (j = i + 1; (j < g.n) && (g.a[i, j] == g.a[j, i]); ++j)
            {
                if (j < g.n)
                    isSymmetric = false;
            }
        }
        return isSymmetric;
    }
}