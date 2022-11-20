namespace BTT4;

public class EDGE
{
    private readonly int v;
    private readonly int w;
    private readonly int weight;

    public EDGE(int v, int w, int weight)
    {
        this.v = v;
        this.w = w;
        this.weight = weight;
    }

    public int[] Vertex()
    {
        int[] vertex = {
            v, w
        };
        return vertex;
    }

    public int EdgeWeight()
    {
        return weight;
    }

    public static int MSTCaculation(EDGE[] edges)
    {
        return edges.Sum(edge => edge.EdgeWeight());
    }
}