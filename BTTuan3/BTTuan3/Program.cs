// See https://aka.ms/new-console-template for more information

using BTTuan3;
using BTTuan3;


Console.WriteLine("Tìm cây khung nhỏ nhất theo phương pháp Prim vui lòng chạy solution BT3a");
Console.WriteLine("Tìm cây khung nhỏ nhất theo phương pháp Kruskal vui lòng chạy solution BT3b");

Console.WriteLine("Nhap duong dan tuyet doi den file input:");
var text = Console.ReadLine() ?? throw new InvalidOperationException();
var a = new AdjacencyMatrix(text);
