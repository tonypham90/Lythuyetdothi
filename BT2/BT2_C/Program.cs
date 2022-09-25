namespace BT2_C;

public static class Program
{
    public static void Main(string[] args)
    {
        var Graph = new AdjacencyMatrix();
        Console.WriteLine("BT2-Câu a: Xét liên thông và thành phần liên thông " +
                          "\nFile nhập dữ liệu có:\n - Dòng đầu là số đỉnh," +
                          "\n - Dòng 2 là cạnh và đích tuy nhiên sẽ không có giá trị vì bài C xét liên thông" +
                          "\n - Các dòng tiếp theo là ma trận biểu diễn quan hệ kết nối các đỉnh\n");
        Console.Write("Nhập đường dẫn tuyệt đối (bao gồm file) đến file chứa dữ liệu: ");
        var path = Console.ReadLine();
        Graph.readAdjacencyMatrix(path);
        var lienthong = new ConnectedComponent(Graph);

    }
}
