namespace DOAN1;

public class DFS
{
    private Dictionary<int, int[]> Adjacency_list;
    private bool foundGoal; //tim thay dich
    private int Goal;
    private Dictionary<int, int>? Parentlist;
    private Stack<int[]>? stack;
    private int Start;

    public DFS(AdjacencyMatrix g)
    {
        Import(g);
    }

    // public void
    public List<int>? VisitedList { get; set; }

    public void Import(AdjacencyMatrix g)
    {
        Start = g.Start;
        Goal = g.Goal;
        Adjacency_list = g.Adjacency_list;
    }

    // public void Run()
    // {
    //     FindGoal(Start, Goal);
    //     // printResult();
    // }


    public bool IsFoundGoal(int HeadNode, int Goal)
    {
        VisitedList = new List<int>();
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
                    if (VisitedList.Contains(currentNode))
                        continue;

                    VisitedList.Add(currentNode);
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
                    if (VisitedList.Contains(currentNode))
                        // if (Parentlist.ContainsKey(currentNode))
                        // {
                        //     Parentlist.Remove(currentNode);
                        // }
                        //
                        // Parentlist.Add(currentNode, elementofStack[1]);
                        continue;

                    VisitedList.Add(currentNode);
                }
            }
            else
            {
                foundGoal = true;
                VisitedList.Add(currentNode);
                Parentlist.Add(currentNode, elementofStack[1]);
                break;
            }
        }

        // printResult(int? parrent)
        // {
        //     Parrent = parrent;
        // }
        return foundGoal;
    }

    public int[] findConnectComponent(int SurveyNode)
    {
        var Component = new List<int>();
        var Waitinglist = new Stack<int>();
        var Visitedlist = new List<int>();

        if (!Adjacency_list.ContainsKey(SurveyNode))
            return new[] {
                SurveyNode
            };
        //Check list child available
        Waitinglist.Push(SurveyNode);
        while (Waitinglist.Count != 0)
        {
            var headnode = Waitinglist.Pop();
            Visitedlist.Add(headnode);
            var childrentlist = Adjacency_list[headnode];
            foreach (var child in childrentlist)
                if (IsFoundGoal(child, SurveyNode) && !Visitedlist.Contains(child))
                    Waitinglist.Push(child);
            Component.Add(headnode);
        }

        return Component.ToArray();
    }

    private void printResult() //in ket qua duyet tim kiem
    {
        switch (foundGoal)
        {
            case true:
                Console.WriteLine("Danh sách các đỉnh đã duyệt:");
                for (var i = 0; i < VisitedList.Count; i++) Console.Write($" {VisitedList[i]}");
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

    public void NewHead(int HeadNode)
    {
        Start = HeadNode;
        Run();
    }

    public void Run()
    {
        FindGoal(Start);
        // printResult();
    }


    public void FindGoal(int HeadNode)
    {
        VisitedList = new List<int>();
        stack = new Stack<int[]>();
        Parentlist = new Dictionary<int, int>();
        foundGoal = false;
        var elementofStack = new int[2];
        elementofStack[0] = HeadNode;
        elementofStack[1] = HeadNode; //Start is current and parent is same.
        stack.Push(elementofStack);
        // stack.Push(Start);
        while (stack.Count != 0)
        {
            elementofStack = stack.Pop();
            //Check goal
            var currentNode = elementofStack[0];
            if (Adjacency_list.ContainsKey(currentNode))
            {
                if (VisitedList.Contains(currentNode))
                    continue;

                VisitedList.Add(currentNode);
                if (Parentlist.ContainsKey(currentNode)) Parentlist.Remove(currentNode);

                Parentlist.Add(currentNode, elementofStack[1]);
                var listchild = Adjacency_list[currentNode];
                // var revertlist = Adjacency_list[currentNode];
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
                if (VisitedList.Contains(currentNode))
                    // if (Parentlist.ContainsKey(currentNode))
                    // {
                    //     Parentlist.Remove(currentNode);
                    // }
                    //
                    // Parentlist.Add(currentNode, elementofStack[1]);
                    continue;
                VisitedList.Add(currentNode);
            }
        }
        // printResult(int? parrent)
        // {
        //     Parrent = parrent;
        // }
    }
}