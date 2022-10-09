namespace DOAN1;

public class ConnectedComponentDirected
{
    private List<int[]> Component_list;
    private readonly AdjacencyMatrix Graph;
    private int Graphtype; //do thi lien thong manh = 1; Do thi lien thong yeu = 2; Do thi thanh phan = 3; Do thi khong lien thong = 4

    public ConnectedComponentDirected(AdjacencyMatrix g)
    {
        Graph = g;
        Component_list = new List<int[]>();
        isStrongConnectionGraph();
        findGraphtype();
        FindComponent();
        printresult();

    }

    private void FindComponent()
    {
        if (Graphtype == 1)
        {
            var Nodelist = new List<int>();
            for (var i = 0; i < Graph.n; i++) Nodelist.Add(i);

            Component_list.Add(Nodelist.ToArray());
            return;
        }

        var dfs = new DFS(Graph);
        var componentList = new List<int[]>();
        var checkNodelist = new int[Graph.n];
        while (checkNodelist.Contains(0))
        {
            var surveyNode = 0;
            for (var i = 0; i < checkNodelist.Length; i++)
                if (checkNodelist[i] == 0)
                {
                    surveyNode = i;
                    checkNodelist[i] = 1;
                    break;
                }

            var visitednode = dfs.findConnectComponent(surveyNode);
            for (var i = 0; i < visitednode.Length; i++) checkNodelist[visitednode[i]] = 1;
            componentList.Add(visitednode);
        }

        Component_list = componentList;
    }

    private bool isStrongConnectionGraph()
    {
        var dfs = new DFS(Graph);
        var i = 0;
        var j = 0;
        while (i < Graph.n)
        {
            for (j = 0; j < Graph.n; j++)
            {
                if (i == j) continue;
                if (!dfs.IsFoundGoal(j, i))
                {
                    return false;
                }
            }

            i++;
        }

        return true;
    }

    private void printresult()
    {
        switch (Graphtype)
        {
            case 1:
                Console.WriteLine("Đồ thị liên thông mạnh");
                break;
            case 2:
                Console.WriteLine("Đồ thị liên thông yếu");
                break;
            case 3:
                Console.WriteLine("Đồ thị liên thông từng phần");
                break;
            case 4:
                Console.WriteLine("Đồ thị không liên thông");
                break;
        }
        PrintComponent();
    }

    private void PrintComponent()
    {
        for (var i = 0; i < Component_list.Count; i++)
        {
            var text = string.Empty;
            for (var j = 0; j < Component_list[i].Length; j++) text += Component_list[i][j] + " ";
            Console.WriteLine($"Thành phần liên thông mạnh thứ {i+1}: {text}");
        }

        ;
    }

    public void findGraphtype()
    {
        Graphtype = new int();
        if (isStrongConnectionGraph())
        {
            Graphtype = 1;
        }
        else
        {
            var GraphConvert = Graph.convertdirecttoUndirect();
            ConnectedComponentUndirected check = new ConnectedComponentUndirected(GraphConvert);
            if (check.CountComponent()>1)
            {
                Graphtype = 4;
                return;
            }

            bool isMultiConnectionGraph = true;
            var dfs = new DFS(Graph);
            for (int i = 0; i < Graph.n; i++)
            {
                for (int j = i+1; j < Graph.n; j++)
                {
                    if (!dfs.IsFoundGoal(j,i)&&!dfs.IsFoundGoal(i,j))
                    {
                        Graphtype = 2;
                        return;
                    }
                }
            }

            Graphtype = 3;
            check.CountComponent();
        }
    }
}