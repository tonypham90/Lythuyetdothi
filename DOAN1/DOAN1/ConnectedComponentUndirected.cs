namespace DOAN1;

public class ConnectedComponentUndirected
{
    protected static List<int[]> Component_list;
    
    public ConnectedComponentUndirected(AdjacencyMatrix g)
    {
        var ComponentinternalList = new List<int[]>();
        var checkVisited = new int[g.n];
        var researchGraph = new DFS(g);
        researchGraph.Import(g);
        while (checkVisited.Contains(0))
        {
            var researchNode = 0;
            for (var i = 0; i < checkVisited.Length; i++)
                if (checkVisited[i] == 0)
                {
                    researchNode = i;
                    break;
                }

            researchGraph.NewHead(researchNode);
            var visited = researchGraph.VisitedList?.ToArray();
            foreach (var node in visited) checkVisited[node] = 1;
            ComponentinternalList.Add(visited);
        }

        Component_list = ComponentinternalList;
        // printConnectComponent();
    }

    public int CountComponent()
    {
        return Component_list.Count;
    }

    public static void printConnectComponent()
    {
        var printlist = Component_list;
        Console.WriteLine($"Số thành phần liên thông {Component_list.Count}");
        for (var i = 0; i < Component_list.Count; i++)
        {
            Console.Write($"Thành phần liên thông thứ {i + 1}: ");
            var visitedNode = Component_list[i];
            var visitedNodeString = string.Empty;
            for (var j = 0; j < visitedNode.Length; j++) visitedNodeString = string.Format("{0} {1} {2}", visitedNodeString, " ", visitedNode[j].ToString());
            Console.WriteLine(visitedNodeString);
        }
    }
}