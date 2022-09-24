namespace BT2_A;

public static class Program
{
    public static void Main(string[] args)
    {
        var Graph = new AdjacencyMatrix();
        Graph.readAdjacencyMatrix("/Users/tonypham/Documents/GitHub/Lythuyetdothi/BT2/BT2_A/InputData/VD1.txt");
        Graph.showAdjacencyMatrix();
        var a = new DFS(Graph);
    }
}