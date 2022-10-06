namespace DOAN1;

public class DFS
{
    private Dictionary<int, int[]> Adjacency_list;
    private bool foundGoal; //tim thay dich
    private int Goal;
    private Dictionary<int, int>? Parentlist;
    private Stack<int[]>? stack;
    private int Start;
    private List<int>? Visited;


    public void Import(AdjacencyMatrix g)
    {
        Start = g.Start;
        Goal = g.Goal;
        Adjacency_list = g.Adjacency_list;
    }

    public void Run()
    {
        FindGoal(Start, Goal);
        printResult();
    }


    public void FindGoal(int HeadNode, int Goal)
    {
        Visited = new List<int>();
        stack = new Stack<int[]>();
        Parentlist = new Dictionary<int, int>();
        foundGoal = false;
        var elementofStack = new int[2];
        elementofStack[0] = HeadNode;
        elementofStack[1] = HeadNode; //Start is current and parent is same.
        stack.Push(elementofStack);
        // stack.Push(Start);
        while (!foundGoal && stack.Count != 0)
        {
            elementofStack = stack.Pop();
            //Check goal
            var currentNode = elementofStack[0];

            if (currentNode != Goal)
            {
                if (Adjacency_list.ContainsKey(currentNode))
                {
                    if (Visited.Contains(currentNode))
                        continue;

                    Visited.Add(currentNode);
                    if (Parentlist.ContainsKey(currentNode)) Parentlist.Remove(currentNode);

                    Parentlist.Add(currentNode, elementofStack[1]);

                    var listchild = Adjacency_list[currentNode];
                    var revertlist = Adjacency_list[currentNode];
                    // Console.WriteLine("Original list");
                    // for (int i = 0; i < listchild.Length; i++)
                    // {
                    //     
                    //     Console.Write(listchild[i]+" ");
                    // }
                    Array.Sort(listchild);
                    Array.Reverse(listchild);
                    // Console.WriteLine("Reverse list");
                    // for (int i = 0; i < listchild.Length; i++)
                    // {
                    //     
                    //     Console.Write(listchild[i]+" ");
                    // }
                    for (var i = 0; i < listchild.Length; i++)
                    {
                        int[] newElement = {
                            listchild[i], currentNode
                        };
                        stack.Push(newElement);
                    }
                }
                else
                {
                    if (Visited.Contains(currentNode))
                        // if (Parentlist.ContainsKey(currentNode))
                        // {
                        //     Parentlist.Remove(currentNode);
                        // }
                        //
                        // Parentlist.Add(currentNode, elementofStack[1]);
                        continue;

                    Visited.Add(currentNode);
                }
            }
            else
            {
                foundGoal = true;
                Visited.Add(currentNode);
                Parentlist.Add(currentNode, elementofStack[1]);
                break;
            }
        }


        // printResult(int? parrent)
        // {
        //     Parrent = parrent;
        // }
    }


    private void printResult() //in ket qua duyet tim kiem
    {
        switch (foundGoal)
        {
            case true:
                Console.WriteLine("Danh sách các đỉnh đã duyệt:");
                for (var i = 0; i < Visited.Count; i++) Console.Write($" {Visited[i]}");
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
        int Child, Parent;
        Child = Goal;

        var TextRoad = string.Empty;
        while (Child != Start)
        {
            Parent = Parentlist[Child];
            var textnode = $"{Parent}";
            if (Child == Goal)
                TextRoad = $"{Child}<-{Parent}";
            else
                TextRoad = TextRoad + $"<-{textnode}";

            Child = Parent;
            // Parent = this.Parent[Child];
        }

        Console.WriteLine(TextRoad);
    } // in duong di nguoc tu dich ve dinh
    
    public void
}