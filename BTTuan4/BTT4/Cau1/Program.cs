// See https://aka.ms/new-console-template for more information

using BTT4;
using Cau1;

Console.WriteLine("Vui lòng nhập đường dẫn đến file input:");
var path = Console.ReadLine();
var Graph = new AdjacencyMatrix(path);
var dijkstra = new Dijkstra(Graph);
Console.WriteLine("done");