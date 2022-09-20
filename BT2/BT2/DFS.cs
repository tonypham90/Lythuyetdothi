using System.Runtime.CompilerServices;

namespace BT2;

public class DFS
{
    private int Start;
    private int Goal;
    private Dictionary<int, int[]> Adjacency_list;
    private Dictionary<int, int> Parent;
    private List<int> Visited;
    Stack<int> stack = null;
    private bool foundGoal;


    public DFS(AdjacencyMatrix g)
    {
        Start = g.Start;
        Goal = g.Goal;
        foundGoal = false;
        Adjacency_list = g.Adjacency_list;
        Visited = new List<int>(){Start};
        stack = new Stack<int>();
        stack.Push(Start);
    }
    public void Search()
    {
        int Headnode;
        Parent = new Dictionary<int, int>();
        while (stack.Count != 0 && !foundGoal)
        {
            Headnode = stack.Pop();
            List<int> termList = Visited;
            ReadConnect(Headnode);
            Console.WriteLine("Danh sách các đỉnh đã duyệt:");
            for (int i = 0; i < Visited.Count; i++)
            {
                Console.Write($" {Visited[i]}");
            }
            if (Visited.Contains(Goal))
            {
                foundGoal = true;
                termList = Visited;
                Visited.Add(Goal);
                break;
            }
        }

        printResult();
    }

    private void ReadConnect(int startNode) // nap cac dinh con vao hang doi va dua vao parent
    {
        int[] children = Adjacency_list[startNode];
        if (Adjacency_list.ContainsKey(startNode))
        {
            for (int i = 0; i < children.Length; i++)
            {
                Parent.Add(children[i],startNode);
                if (!Visited.Contains(children[i]))
                {
                    Visited.Add(children[i]);
                    stack.Push(children[i]);
                }
            }
        }
    }

    private void printResult() //in ket qua duyet tim kiem
    {
        switch (foundGoal)
        {
            case true:
                Console.WriteLine("Danh sách các đỉnh đã duyệt:");
                for (int i = 0; i < Visited.Count; i++)
                {
                    Console.Write($" {Visited[i]}");
                }
                Console.WriteLine("\nĐường đi in ngược");
                printGoaltoStart();
                break;
            case false:
                Console.WriteLine("Khong tim thay dinh");
                break;
        }
    }

    private void printGoaltoStart()
    {
        string TextRoad = String.Empty;
        Stack<int> way = stack;
        while (way.Count!=0)
        {
            int Node = way.Pop();
            string textnode = Node.ToString();
            if (Node == Goal)
            {
                TextRoad = textnode;
            }
            else
            {
                TextRoad = TextRoad + $"<-{textnode}";
            }
        }

        Console.WriteLine(TextRoad);
    } // in duong di nguoc tu dich ve dinh
}

    