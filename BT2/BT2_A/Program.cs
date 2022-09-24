namespace BT2_A;

public static class Program
{
    public static void Main(string[] args)
    {
        var Graph = new AdjacencyMatrix();
        Console.WriteLine("BT2-Câu a: Tìm kiếm duyệt sâu DFS với stack ưu tiên nhập vào từ lớn đến bé:" +
                          "\nFile nhập dữ liệu có:\n - Dòng đầu là số đỉnh,\n - Dòng 2 là cạnh và đích cách nhau 1 space\n - Các dòng tiếp theo là ma trận biểu diễn quan hệ kết nối các đỉnh");
        Console.Write("Nhập đường dẫn tuyệt đối (bao gồm file) đến file chứa dữ liệu: ");
        var path = Console.ReadLine();
        Graph.readAdjacencyMatrix(path);
        // Graph.showAdjacencyMatrix();
        var a = new DFS();
        a.Import(Graph);
        a.Run();
    }
}