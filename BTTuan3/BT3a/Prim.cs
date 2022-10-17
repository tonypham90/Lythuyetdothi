using BTTuan3;

namespace BT3a;

public class Prim
{
    private readonly bool[] marked;
    private int nT; //So Canh cay T
    private EDGE[] T; //Canh khung

    public Prim(AdjacencyMatrix g)
    {
        T = new EDGE[g.n - 1];
        nT = 0;
        marked = new bool[g.n];
        for (var i = 0; i < marked.Length; i++) marked[i] = false;
    }
}