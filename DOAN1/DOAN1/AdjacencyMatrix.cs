namespace DOAN1;

public class AdjacencyMatrix
{
    public int[,]? a = new int[0, 0]; //Ma tran bieu dien do thi
    public Dictionary<int, int[]> Adjacency_list;
    public int[] Degrees; //Bậc hay bậc vào của Đỉnh
    public int[] DegreesOut; // Bậc ra của đỉnh bao gồm 
    public int Goal;
    public int n; // so dinh
    public int Start;
    public bool Undirect; //Mo ta vo huong true; co huong: false

    //input du lieu va duong dan
    public void ReadAdjacencyMatrix(string? pathInput)
    {
        var file = new StreamReader(pathInput);
        var input = file.ReadToEnd();
        // Console.WriteLine(input);
        var result = input.Split("\n");
        for (var i = 0; i < result.Length; i++)
            if (i == 0)
            {
                var parse = int.Parse(result[0]);
                n = parse;
                Adjacency_list = new Dictionary<int, int[]>();
            }
            else
            {
                if (result[i].Length==1|| Convert.ToInt32(result[i][0])==0)
                {
                    continue;
                }
                var line = result[i].Split(" ");
                int countConnect = int.Parse(line[0]);
                if (countConnect ==0)
                {
                    continue;
                }
                else
                {
                    int[] connectionlist = new int[countConnect];
                    for (int j = 1; j < line.Length; j++)
                    {
                        connectionlist[j - 1] = int.Parse(line[j]);
                    }

                    Adjacency_list.Add(i-1,connectionlist);
                }
            }
        ConvertAdjacencylistToMatrix();

        IsUndirectedGraph();
        countDegrees();
        // ConvertMatrixToAdjacencylist();
        
    }

    private void ConvertAdjacencylistToMatrix()
    {
        int[,] Matrix = new int[n, n];
        
        foreach (var element in Adjacency_list)
        {
            int Node = element.Key;
            int[] Connect = element.Value;
            for (int i = 0; i < Connect.Length; i++)
            {
                Matrix[Node, Connect[i]] = 1;
            }
        }

        a = Matrix;
    }

    //Convert matrix to Adjacency list

    public void ConvertMatrixToAdjacencylist()
    {
        var dictionary = new Dictionary<int, int[]>();
        Adjacency_list = new Dictionary<int, int[]>();
        for (var i = 0; i < n; i++)
        {
            var srow = 0;
            // tinh tong element 1 row
            for (var j = 0; j < n; j++)
                if (a[i, j] != 0)
                    srow += 1;

            var list = new int[srow];
            var countIndex = 0;
            for (var j = 0; j < n; j++)
                if (a[i, j] != 0)
                {
                    list[countIndex] = j;
                    countIndex += 1;
                }

            if (srow != 0) dictionary.Add(i, list);
        }

        Adjacency_list = dictionary;
    }

    public void IsUndirectedGraph() //kiem tra tinh co huong cua do thi
    {
        int i, j;
        var isSymmetric = true;
        for (i = 0; i < n && isSymmetric; ++i)
        {
            for (j = i + 1; j < n && a[i, j] == a[j, i]; ++j) ;
            if (j < n) isSymmetric = false;
        }

        Undirect = isSymmetric;
    }

    public void countDegrees() //Dem dinh
    {
        var degrees = new int[n]; // Mảng chứa bậc của các đỉnh
        var degreesOuts = new int[n];
        for (var i = 0; i < n; i++) degreesOuts[i] = 0;

        for (var i = 0; i < n; i++)
        {
            var count = 0;
            for (var j = 0; j < n; j++)
                if (a[i, j] != 0)
                {
                    count += a[i, j];
                    degreesOuts[j] += a[i, j];
                    if (i == j && Undirect) // xet truong hop canh khuyen
                        count += a[i, i];
                }

            degrees[i] = count;
        }

        Degrees = degrees;
        DegreesOut = degreesOuts;
    }

    //Show propertive of graph
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

        // Undirect = IsUndirectedGraph(this);
        // Bac
        // this.Degrees = CheckGraph.countDegrees(this);
        //Check tinh co huong 
        if (Undirect)
            Console.WriteLine("Đồ Thị Vô Hướng");
        else
            Console.WriteLine("Đồ Thị có Hướng");
        Console.WriteLine("Convert matrix to Adjacency list:");
        Console.WriteLine(Adjacency_list);
        //Tong so canh
        // Console.WriteLine($"Tổng số cạnh đồ thị: {CountConnect(this)}");
        // //Số cặp cạnh bôi
        // Console.WriteLine($"Tổng số cặp cạnh bội: {CheckGraph.CountDoubleConnect(this)}");
        // Console.WriteLine($"Tổng số cạnh khuyên: {CheckGraph.countloopsGraph(this)}");
        // Console.WriteLine($"Tổng số đỉnh treo: {CheckGraph.CountPendant(this)}");
        //in so bac moi dinh
        // switch (this.Undirect)
        // {
        //     case true:
        //         Console.WriteLine("Bac tung dinh:");
        //         for (int i = 0; i < this.Degrees.Length; i++)
        //         {
        //             Console.Write($"{i}({Degrees[i]}) ");
        //         }
        //         break;
        //     case false:
        //         Console.WriteLine("(Bac vao - Bac ra)Bac tung dinh:");
        //         for (int i = 0; i < this.n; i++)
        //         {
        //             Console.Write($"{i}({DegreesOut[i]}-{Degrees[i]}) ");
        //         }
        //         break;
        // }
        // //loai do thi:
        // string firsttext,Secondtext;
        //
        // switch (this.Undirect)
        // {
        //     case true:
        //         Secondtext = "Vô Hướng";
        //         break;
        //     case false:
        //         Secondtext = "Có Hướng";
        //         break;
        // }
        // if (CheckGraph.CountDoubleConnect(this)>0)
        // {
        //     if (CheckGraph.countloopsGraph(this)>0)
        //     { 
        //         firsttext = "Giả Đồ Thị";
        //     }
        //     else
        //     {
        //         firsttext = "Đa Đồ Thị";
        //     }
        // }
        // else
        // {
        //     firsttext = "Đơn Đồ Thị";
        // }
        // Console.WriteLine($"\n{firsttext} {Secondtext}");
        foreach (var Connect in Adjacency_list)
        {
            var TextValue = string.Empty;
            for (var i = 0; i < Connect.Value.Length; i++)
                if (i == 0)
                    TextValue = string.Concat(Connect.Value[i]);
                else
                    TextValue += $" {Connect.Value[i]}";
            Console.WriteLine($"Node: {Connect.Key}, Connect to: {TextValue}");
        }
    }
}