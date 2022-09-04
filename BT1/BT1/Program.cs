using System.Runtime.CompilerServices;
namespace BT1
{
    public class AdjacencyMatrix
    {
        public int n = 0; // so dinh
        public int[,]? a = new int[0,0];
        public bool Undirect; //Mo ta vo huong true; co huong: false
       

        public void readAdjacencyMatrix(string pathInput)
        {
            StreamReader file = new StreamReader(pathInput);
            string input = file.ReadToEnd();
            Console.WriteLine(input);
            string[] result = input.Split("\n");
            int n = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (i==0)
                {
                    n = int.Parse(result[0]);
                    this.n = n;
                    this.a = new int[n, n];
                }
                else
                {
                    string[] line = result[i].Split(" ");
                    for (int j = 0; j < line.Length; j++)
                    {
                        this.a [i - 1, j] = int.Parse(line[j]);
                    }
                }
            }
        }
        public void showAdjacencyMatrix()
        {
            //begin
            Console.WriteLine($"Số Đỉnh đồ thị: {n}");

            for (int i = 0; i < this.a.GetLength(0); i++)
            {
                
                for (int j = 0; j < this.a.GetLength(1); j++)
                {
                    if (j==this.a.GetLength(1)-1)
                    {
                        Console.WriteLine($"{this.a[i,j]} ");
                    }
                    else
                    {
                        Console.Write($"{this.a[i,j]} ");
                    }
                }
            }
            
            this.Undirect = CheckGraph.IsUndirectedGraph(this);
            //Check tinh co huong 
            if (this.Undirect == true)
            {
                Console.WriteLine("Đồ Thị Vô Hướng");
            }
            else
            {
                Console.WriteLine("Đồ Thị có Hướng");
            }
            //Tong so canh
            Console.WriteLine($"Tổng số cạnh đồ thị: {CheckGraph.CountConnect(this)}");
            //Số cặp cạnh bôi
            Console.WriteLine($"Tổng số cặp cạnh bội: {CheckGraph.CountDoubleConnect(this)}");
            Console.WriteLine($"Tổng số cạnh khuyên: {CheckGraph.countloopsGraph(this)}");
            Console.WriteLine($"Tổng số đỉnh treo: {CheckGraph.CountPendant(this)}");
        }
    }
    internal static class Program
    {
        
        private static void Main(string[] args)
        { 
            string pathInputTxt = "/Users/tonypham/Documents/GitHub/Lythuyetdothi/BT1/BT1/Input.txt";
            AdjacencyMatrix g = new AdjacencyMatrix(); 
            g.readAdjacencyMatrix(pathInputTxt); 
            g.showAdjacencyMatrix();
        }
    }
}