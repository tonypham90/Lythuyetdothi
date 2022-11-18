namespace BTT4;

public class ArrayManipulation
{
    public static EDGE[] RemoveEdges(EDGE[] listEdges, EDGE edgeRemoved)
    {
        int count = 0;
        var result = new List<EDGE>();
        foreach (EDGE edge in listEdges)
        {
            if (edge.Vertex()[0]==edgeRemoved.Vertex()[0]&& edge.Vertex()[1]==edgeRemoved.Vertex()[1]&& edge.EdgeWeight()==edgeRemoved.EdgeWeight())
            {
                continue;
            }
            result.Add(edge);
        }

        return result.ToArray();
    }

    public static int TotalWeightEdges(EDGE[] listEdges)
    {
        int total = 0;
        foreach (EDGE edge in listEdges)
        {
            total += edge.EdgeWeight();
        }

        return total;
    }

    public static int[] RemoveArrayElement(int[] Array, int elementRemoved)
    {
        int count = 0;
        var result = new List<int>();
        foreach (int element in Array)
        {
            if (element!=elementRemoved)
            {
                result.Add(element);
            }
        }

        return result.ToArray();
    }

    public static int CountValueArray(int[] Array, int value)
    {
        return Array.Count(element => element == value);
    }
}