namespace BT2_B;

// struct Node
// {
//     public int Current;
//     public int Parent;
//
//     public int[] stackelement()
//     {
//         int[] element = new int[] {
//             Current, Parent
//         };
//         return element;
//     }
//
//     public void GetNode(int currentNode,int parentNode)
//     {
//         Current = currentNode;
//         Parent = parentNode;
//     }
// }
public class BFS
{
    private readonly Dictionary<int, int[]> Adjacency_list;
    private readonly int Goal;

    private readonly int Start;
    private bool foundGoal; //tim thay dich
    private Dictionary<int, int> Parentlist;
    private Queue<int[]> queue;
    private List<int> Visited;


    public BFS(AdjacencyMatrix g)
    {
        Start = g.Start;
        Goal = g.Goal;
        bool foundGoal;
        Adjacency_list = g.Adjacency_list;
        Queue<int[]>? stack = null;
        FindGoal(Start, Goal);
        printResult();
    }

    public void FindGoal(int HeadNode, int Goal)
    {
        int currentNode;
        Visited = new List<int>();
        queue = new Queue<int[]>();
        Parentlist = new Dictionary<int, int>();
        foundGoal = false;
        var elementofStack = new int[2];
        elementofStack[0] = HeadNode;
        elementofStack[1] = HeadNode; //Start is current and parent is same.
        queue.Enqueue(elementofStack);
        // stack.Push(Start);
        while (!foundGoal && queue.Count != 0)
        {
            elementofStack = queue.Dequeue();
            //Check goal
            currentNode = elementofStack[0];

            if (currentNode != Goal)
            {
                if (Adjacency_list.ContainsKey(currentNode))
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
                    // Array.Reverse(listchild);
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
                        queue.Enqueue(newElement);
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
}