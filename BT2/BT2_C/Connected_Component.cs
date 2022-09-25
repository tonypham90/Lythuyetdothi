namespace BT2_C;

public class ConnectedComponent
{
    private static List<int[]> Component_list;
    public ConnectedComponent(AdjacencyMatrix g)
    {
        var ComponentinternalList = new List<int[]>();
        int[] checkVisited = new int[g.n];
        var researchGraph = new DFS();
        researchGraph.Import(g);
        while (!researchGraph.IsUndirect)
        {
            Console.WriteLine("Đồ Thị có hướng. vui lòng cập nhật đồ thị có hướng.");
            var Graph = new AdjacencyMatrix();
            Console.WriteLine("Địa chỉ tuyệt đối của file input mới: ");
            string path = Console.ReadLine();
            Graph.readAdjacencyMatrix(path);
            researchGraph.Import(Graph);

        }
        while (checkVisited.Contains(0))
        {
            int researchNode = 0;
            for (int i = 0; i < checkVisited.Length; i++)
            {
                if (checkVisited[i]==0)
                {
                    researchNode = i;
                    break;
                }
            }
            researchGraph.NewHead(researchNode);
            int[] visited = researchGraph.Visited.ToArray();
            foreach (int node in visited)
            {
                checkVisited[node] = 1;
            }
            ComponentinternalList.Add(visited);
        }

        Component_list = ComponentinternalList;
        printConnectComponent();
    }

    public static void printConnectComponent()
    {
        List<int[]> printlist = Component_list;
        Console.WriteLine($"Số thành phần liên thông {Component_list.Count}");
        for (int i = 0; i < Component_list.Count; i++)
        {
            Console.Write($"Thành phần liên thông thứ {i + 1}: ");
            int[] visitedNode = Component_list[i];
            string visitedNodeString = String.Empty;
            for (int j = 0; j < visitedNode.Length; j++)
            {
                visitedNodeString = string.Format("{0} {1} {2}", visitedNodeString," ", (visitedNode[j].ToString()));
            }
            Console.WriteLine(visitedNodeString);
        }
    }
}