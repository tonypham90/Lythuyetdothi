namespace BT1;

public class AdjacencyMatrix
{
    public int[,]? a = new int[0, 0];
    public int n; // so dinh
    public bool Undirect; //Mo ta vo huong true; co huong: false
    public int[] Degrees;
    public int[] DegreesOut;
    


    public void readAdjacencyMatrix(string? pathInput)
    {
        var file = new StreamReader(pathInput);
        var input = file.ReadToEnd();
        Console.WriteLine(input);
        var result = input.Split("\n");
        var n = 0;
        for (var i = 0; i < result.Length; i++)
            if (i == 0)
            {
                n = int.Parse(result[0]);
                this.n = n;
                a = new int[n, n];
            }
            else
            {
                var line = result[i].Split(" ");
                for (var j = 0; j < line.Length; j++) a[i - 1, j] = int.Parse(line[j]);
            }
        countDegrees();
    }
    public void countDegrees()
    {
        int[] degrees = new int[this.n]; // Mảng chứa bậc của các đỉnh
        int[] degreesOuts = new int[this.n];
        for (int i = 0; i < this.n; i++)
        {
            degreesOuts[i] = 0;
        }
        for (int i = 0; i < this.n; i++)
        {
            int count = 0;
            for (int j = 0; j < this.n; j++)
                if (this.a[i, j] != 0)
                {
                    count += this.a[i, j];
                    degreesOuts[j] += this.a[i, j];
                    if (i == j && this.Undirect) // xet truong hop canh khuyen
                        count += this.a[i, i];
                }

            degrees[i] = count;
        }

        this.Degrees = degrees;
        this.DegreesOut = degreesOuts;
    }

    public void showAdjacencyMatrix()
    {
        //begin
        Console.WriteLine($"Số Đỉnh đồ thị: {n}");

        // for (var i = 0; i < a.GetLength(0); i++)
        // for (var j = 0; j < a.GetLength(1); j++)
        //     if (j == a.GetLength(1) - 1)
        //         Console.WriteLine($"{a[i, j]} ");
        //     else
        //         Console.Write($"{a[i, j]} ");

        Undirect = CheckGraph.IsUndirectedGraph(this);
        // Bac
        // this.Degrees = CheckGraph.countDegrees(this);
        //Check tinh co huong 
        if (Undirect)
            Console.WriteLine("Đồ Thị Vô Hướng");
        else
            Console.WriteLine("Đồ Thị có Hướng");
        //Tong so canh
        Console.WriteLine($"Tổng số cạnh đồ thị: {CheckGraph.CountConnect(this)}");
        //Số cặp cạnh bôi
        Console.WriteLine($"Tổng số cặp cạnh bội: {CheckGraph.CountDoubleConnect(this)}");
        Console.WriteLine($"Tổng số cạnh khuyên: {CheckGraph.countloopsGraph(this)}");
        Console.WriteLine($"Tổng số đỉnh treo: {CheckGraph.CountPendant(this)}");
        //in so bac moi dinh
        switch (this.Undirect)
        {
            case true:
                Console.WriteLine("Bac tung dinh:");
                for (int i = 0; i < this.Degrees.Length; i++)
                {
                    Console.Write($"{i}({Degrees[i]}) ");
                }
                break;
            case false:
                Console.WriteLine("(Bac vao - Bac ra)Bac tung dinh:");
                for (int i = 0; i < this.n; i++)
                {
                    Console.Write($"{i}({DegreesOut[i]}-{Degrees[i]}) ");
                }
                break;
        }
        //loai do thi:
        string firsttext,Secondtext;
        
        switch (this.Undirect)
        {
            case true:
                Secondtext = "Vô Hướng";
                break;
            case false:
                Secondtext = "Có Hướng";
                break;
        }
        if (CheckGraph.CountDoubleConnect(this)>0)
        {
            if (CheckGraph.countloopsGraph(this)>0)
            { 
                firsttext = "Giả Đồ Thị";
            }
            else
            {
                firsttext = "Đa Đồ Thị";
            }
        }
        else
        {
            firsttext = "Đơn Đồ Thị";
        }
        Console.WriteLine($"\n{firsttext} {Secondtext}");
    }
}

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Nhập đường dẫn tuyệt đối kèm tên file input vd:'/Users/tonypham/Documents/GitHub/Lythuyetdothi/BT1/BT1/Input.txt'\nĐường dẫn:");
        string? path = Console.ReadLine();
        while (string.IsNullOrEmpty(path))
        {
            Console.WriteLine("Nhập đường dẫn tuyệt đối kèm tên file input vd:'/Users/tonypham/Documents/GitHub/Lythuyetdothi/BT1/BT1/Input.txt'\nNhập lại Đường dẫn:");
            path = Console.ReadLine();
        }
        string? pathInputTxt = path;//Duong dan den file input
        
        AdjacencyMatrix g = new AdjacencyMatrix();
        g.readAdjacencyMatrix(pathInputTxt);
        g.showAdjacencyMatrix();
    }
}