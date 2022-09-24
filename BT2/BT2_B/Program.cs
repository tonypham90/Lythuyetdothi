namespace BT2_B;

public static class Program
{
    public static void Main(string[] args)
    {
        var GraphBFS = new AdjacencyMatrix();
        Console.WriteLine("BT2-Câu a: Tìm kiếm duyệt sâu BFS:" +
                          "\nFile nhập dữ liệu có:\n - Dòng đầu là số đỉnh," +
                          "\n - Dòng 2 là cạnh và đích cách nhau 1 space" +
                          "\n - Các dòng tiếp theo là ma trận biểu diễn quan hệ kết nối các đỉnh\n");
        Console.Write("Nhập đường dẫn tuyệt đối (bao gồm file) đến file chứa dữ liệu: ");
        var path = Console.ReadLine();
        GraphBFS.readAdjacencyMatrix(path);
        var bfs = new BFS();
        bfs.Import(GraphBFS);
        bfs.Run();
    }
}