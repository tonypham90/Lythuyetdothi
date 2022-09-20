using System.Collections.Generic;
namespace BT2;

public static class Program
{

    public static void Main(string[] args)
    {
        AdjacencyMatrix Graph = new AdjacencyMatrix();
        Graph.readAdjacencyMatrix("/Users/tonypham/Documents/GitHub/Lythuyetdothi/BT2/BT2/InputData/VD1.txt");
        Graph.showAdjacencyMatrix();
        DFS A = new DFS(Graph);
        A.Search();

    }
}