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

    public static EDGE[] AddEdges(EDGE[] listEdge, EDGE edgeAdd)
    {
        var newlistEdges = new EDGE[listEdge.Length + 1];
        for (int i = 0; i < listEdge.Length; i++)
        {
            newlistEdges[i] = listEdge[i];
        }
        newlistEdges[listEdge.Length] = edgeAdd;
        return newlistEdges;
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

    public static int[] road(int[] roadrecord, int[] parrentlist, int i)
    {
        while (true)
        {
            if (i == parrentlist[i])
            {
                roadrecord = Addelement(roadrecord, i);
                return roadrecord;
            }
            roadrecord = Addelement(roadrecord, i);
            i = parrentlist[i];
        }
    }

    public static int[] Addelement(int[] currentArray,int newelement)
    {
        var newlistEdges = new int[currentArray.Length + 1];
        for (int i = 0; i < currentArray.Length; i++)
        {
            newlistEdges[i] = currentArray[i];
        }
        newlistEdges[currentArray.Length] = newelement;
        return newlistEdges;
    }
}