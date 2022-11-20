using System.Data;
using System.Linq.Expressions;
using BTT4;

namespace Cau2;

public class Bellman_Ford
{
    private const int VoCuc = int.MaxValue;
    private bool bestvalue;
    private AdjacencyMatrix g { get; }
    private int NodeS { get; }
    private EDGE[] ListEdge { get; set; }
    private int[,] Cost { get; }
    private int[] Pr { get; } // Luu danh sach dia chi cha cua dinh
    public Bellman_Ford(AdjacencyMatrix graph)
    {
        g = graph;
        var k = 0;
        ListEdge = g.listEDGE;
        Cost = new int[g.n+1, g.n];
        for (var j = 0; j < Cost.GetLength(1); j++)
            Cost[0, j] = VoCuc;

        Pr = new int[g.n];
        for (var i = 0; i < Pr.Length; i++) Pr[i] = i;
        Console.Write($"Đỉnh bắt đầu duyệt (0~{g.n - 1}): ");
        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
            NodeS = 0;
        else
            NodeS = int.Parse(input);
        

        bestvalue = false;
        while (k < g.n)
        {
            if (k==0)
            {
                Cost[0, NodeS] = 0;
            }
            else
            {
                updateprocess(k);
                isBestvalue(k);

                void isBestvalue(int k)
                {
                    for (var node = 0; node < g.n - 1; node++)
                        if (Cost[k, node] != Cost[k - 1, node])
                        {
                            bestvalue = false;
                            return;
                        }

                    bestvalue = true;
                    return;
                }

                
            }
            if (bestvalue)
            {
                break;
            }
            k++;
        }

        PrintResult(k);
    }
    

    private void PrintResult(int k)
    {
        if (k==g.n) Console.WriteLine("Đồ thị có mạch âm");
        else
        {
            for (int i = 0; i < g.n; i++)
            {
                if (Cost[k,i] == VoCuc)
                {
                    Console.WriteLine($"Không có đường đi từ đỉnh {NodeS} đến đỉnh {i}");
                }
                else
                {
                    var road = Array.Empty<int>();
                    road = ArrayManipulation.road(road, Pr, i);
                    var textroad = "";
                    for (var j = 0; j < road.Length; j++)
                        if (j == 0)
                            textroad = $"{road[j]}";
                        else
                            textroad = $"{textroad} <- {road[j]}";
                    Console.WriteLine($"Đường đi ngắn nhất từ {NodeS} đến đỉnh {i}: {Cost[k,i]} {textroad}");
                }
            }
        }

        // printcost();
    }

    private void printcost()
    {
        string headtext = String.Empty;
        for (int i = 0; i < g.n; i++)
        {
            headtext = $"{headtext} {i}";
        }
        Console.WriteLine(headtext);

        for (int i = 0; i < Cost.GetLength(0); i++)
        {
            string rowtext = string.Empty;
            for (int j = 0; j < Cost.GetLength(1); j++)
            {
                rowtext = $"{rowtext} {Cost[i, j]}";
            }
            Console.WriteLine(rowtext);
        }
    }
    //in kết quả

    private void updateprocess(int k)
    {
        for (var node = 0; node < g.n; node++)
        {
            var relativeEdges = Array.Empty<EDGE>();

            foreach (var edge in this.ListEdge)
            {
                if (edge.Vertex()[1] == node)
                {
                    relativeEdges = ArrayManipulation.AddEdges(relativeEdges, edge);
                }
            }

            if (relativeEdges.Length ==0)
            {
                Cost[k, node] = Cost[k - 1, node];
                continue;
            }

            Costcaculation(k, node, relativeEdges);
        }
    }
    

    private void Costcaculation(int k, int node, EDGE[] relativeEdges)
    {
        List<int[]> DSCost = new List<int[]>();
        int[] CP = new int[2];
        CP[0] = Cost[k - 1, node];
        CP[1] = Pr[node];
        DSCost.Add(CP);//Dua Cost cua dinh dang xet o k-1
        foreach (EDGE relativeEdge in relativeEdges) // tính chi phí của đỉnh truyền đến
        {
            int[] CPforcing = new int[2];
            CPforcing[1] = relativeEdge.Vertex()[0]; // danh dau parent
            if (Cost[k - 1, relativeEdge.Vertex()[0]]==VoCuc)
            {
                CPforcing[0] = VoCuc;
            }
            else
            {
                CPforcing[0] = Cost[k - 1, relativeEdge.Vertex()[0]] + relativeEdge.EdgeWeight();
            }
            DSCost.Add(CPforcing);
        }
        //Tim mincost
        int[] cpChosen = findMinCost(DSCost);
        Pr[node] = cpChosen[1];
        Cost[k, node] = cpChosen[0];
    }

    private int[] findMinCost(List<int[]> dsCost)
    {
        int[] Chosenone = new int[2];
        for (int i = 0; i < dsCost.Count; i++)
        {
            if (i==0)
            {
                Chosenone = dsCost[0];
            }
            else
            {
                if (dsCost[i][0]<Chosenone[0])
                {
                    Chosenone = dsCost[i];
                }
            }
        }

        return Chosenone;
    }
}