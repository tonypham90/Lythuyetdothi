// See https://aka.ms/new-console-template for more information

using BTT4;
using Cau2;

Console.WriteLine("Vui lòng nhập đường dẫn đến file input:");
var path = Console.ReadLine();
var Graph = new AdjacencyMatrix(path);
var bellmanFord = new Bellman_Ford(Graph);