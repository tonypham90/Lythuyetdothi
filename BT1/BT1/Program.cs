using System.Runtime.CompilerServices;


namespace BT1
{
    
    public class AdjacencyMatrix
    {
        public int[,]? a;
        public int n;

        public void ReadAdjacencyMatrix(string filename)
        {
            StreamReader file = new StreamReader("/Users/tonypham/Documents/GitHub/Lythuyetdothi/BT1/BT1/Input.txt");
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
                        this.a[i - 1, j] = int.Parse(line[j]);
                    }
                }
            }
        }
        public void showAdjacencyMatrix()
        {
            Console.WriteLine(n);

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
        }
    }
    internal static class Program
    {
        
        public static bool IsUndirectedGraph(AdjacencyMatrix g)//Kiem tra do thi co huong
        {
            int i, j;
            bool isSymmetric = true;
            for (i = 0; i < g.n && isSymmetric; ++i)
            {
                for (j = i + 1; (j < g.n) && (g.a[i, j] == g.a[j, i]); ++j)
                {
                    if (j < g.n)
                        isSymmetric = false;
                }
            }
            return isSymmetric;
        }
        
        
        private static void Main(string[] args)
        { 
            AdjacencyMatrix g = new AdjacencyMatrix(); 
            g.ReadAdjacencyMatrix("input.txt"); 
            g.showAdjacencyMatrix();

            bool isVoHuong = IsUndirectedGraph(g);
            if (isVoHuong == true)
            {
                Console.WriteLine("Đồ Thị Vô Hướng");
            }
            
            else
            {
                Console.WriteLine("Đồ Thị có Hướng");
            }
        }
    }
}