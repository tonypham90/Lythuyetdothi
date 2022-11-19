using BTT4;

namespace Cau1;

public class Dijkstra
{
    private AdjacencyMatrix g { get; set; }
    private int NodeS { get; }
    private EDGE[] listEDGE { get; set; }
    private bool[] T { get; set; }
    private int[] L { get; set; }
    private int [] Pr { get; set; }

    public Dijkstra(AdjacencyMatrix Graph)
    {
        g = Graph;
        listEDGE = g.listEDGE;
        Pr = new int[g.n];
        Console.Write($"Nhập đỉnh bắt đầu(0- {g.n-1}):");
        NodeS = int.Parse(Console.ReadLine() ?? string.Empty);
        T = new bool[g.n]; //track cac dinh duoc rut ra servey;
        L = new int[g.n];
        //Ngoai tru dinh bat dau duoc xem la bang 0, cac gia tri dinh khac =0 co nghia chua duoc survey
        for (int i = 0; i < L.Length; i++)
        {
            L[i] = 0;
        }
        for (int i = 0; i < T.Length; i++)
        {
            T[i] = true;
        }

        for (int i = 0; i < Pr.Length; i++)
        {
            Pr[i] = i;
        }
        SurveyProcess();
        printResult();

    }

    private void printResult()
    {
        if (L.Max()==0)
        {
            Console.WriteLine("không có đường đi đến bất kỳ đỉnh nào");
            return;
            
        }

        for (int i = 0; i < g.n; i++)
        {
            if (Pr[i]==i)
            {
                continue;
            }

            int[] road = Array.Empty<int>();
            road = ArrayManipulation.road(road, Pr, i);
            var textroad = "";
            for (int j = 0; j < road.Length; j++)
            {
                if (j==0)
                {
                    textroad = $"{road[j]}";
                }
                else
                {
                    textroad = $"{textroad} <- {road[j]}";
                }
            }
            Console.WriteLine($"Đường đi ngắn nhất từ {i} đến {NodeS}: {L[i]} {textroad}");
        }
    }

    

    private void SurveyProcess()
    {
        //tim node servey
        int nodeSurvey = FindNodeSurvey();
        if (nodeSurvey == -1)
        {
            return;
        }
        T[nodeSurvey] = false;// Đánh dấu node đã được duyệt.
        //Tim cac canh truyen toi dinh ke.
        var relativeEdges = Array.Empty<EDGE>();
        
        // relativeEdges = listEDGE.Where(edge => edge.Vertex()[0] == nodeSurvey).Aggregate(relativeEdges, (current, edge) => ArrayManipulation.AddEdges(current, edge));
        foreach (EDGE edge in listEDGE)
        {
            if (edge.Vertex()[0]==nodeSurvey)
            {
                relativeEdges = ArrayManipulation.AddEdges(relativeEdges,edge);
            }
        }
        

        if (relativeEdges.Length==0)
        {
            SurveyProcess();
        }
        Updatemethod();

        void Updatemethod()
        {
            foreach (var edge in relativeEdges)
            {
                listEDGE = ArrayManipulation.RemoveEdges(listEDGE, edge);
                int vertextCurrent = edge.Vertex()[0];
                int vertexNext = edge.Vertex()[1];
                if (vertexNext == NodeS)
                {
                    continue;
                }
                if (L[vertexNext]==0)
                {
                    L[vertexNext] = L[vertextCurrent]+edge.EdgeWeight();
                    Pr[vertexNext] = vertextCurrent;
                    continue;
                }

                if (L[vertexNext] <= L[vertextCurrent] + edge.EdgeWeight()) continue;
                L[vertexNext] = L[vertextCurrent]+edge.EdgeWeight();
                Pr[vertexNext] = vertextCurrent;
                
            }
        }
        SurveyProcess();
        
    }

    private int FindNodeSurvey()
    {
        int chosenOne = -1;
        for (int i = 0; i < T.Length; i++)
        {
            if (T[i])
            {
                if (i==NodeS)
                {
                    return i;
                }

                if (L[i] <= 0) continue;
                if (chosenOne ==-1)
                {
                    chosenOne = i;
                }

                if (L[i]<L[chosenOne])
                {
                    chosenOne = i;
                }
            }
        }

        return chosenOne;
    }
}
