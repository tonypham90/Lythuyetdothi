namespace BT2_B;

public static class Program
{

    public static void Main(string[] args)
    {
        AdjacencyMatrix GraphBFS = new AdjacencyMatrix();
        GraphBFS.readAdjacencyMatrix("/Users/tonypham/Documents/GitHub/Lythuyetdothi/BT2/BT2_B/InputData/VD4.txt");
        BFS bfs = new BFS(GraphBFS);
        



    }
}