// See https://aka.ms/new-console-template for more information

using BT3b;
using BTTuan3;

Console.WriteLine("tìm cây khung nhỏ nhất theo phương pháp Kruskal");
Console.WriteLine("Nhap duong dan tuyet doi den file input:");
var text = Console.ReadLine() ?? throw new InvalidOperationException();
var a = new AdjacencyMatrix(text);
var method = new Kruskal(a);