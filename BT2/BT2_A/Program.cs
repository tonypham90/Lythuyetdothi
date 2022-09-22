using System.Collections.Generic;
namespace BT2_A;

public static class Program
{

    public static void Main(string[] args)
    {
        AdjacencyMatrix Graph = new AdjacencyMatrix();
        Graph.readAdjacencyMatrix("/Users/tonypham/Documents/GitHub/Lythuyetdothi/BT2/BT2_A/InputData/VD1.txt");
        Graph.showAdjacencyMatrix();
        DFS a = new DFS(Graph);
        // AdjacencyMatrix GraphBFS = new AdjacencyMatrix();
        // GraphBFS.readAdjacencyMatrix("/Users/tonypham/Documents/GitHub/Lythuyetdothi/BT2_A/BT2_A/InputData/VD4.txt");
        // BFS bfs = new BFS(GraphBFS);
        



    }
}