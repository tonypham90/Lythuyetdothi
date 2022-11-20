// See https://aka.ms/new-console-template for more information

using BTT4;
using Cau1;

Console.WriteLine("Hello, World!");
var path = "/Users/tonypham/Documents/GitHub/Lythuyetdothi/BTTuan4/BTT4/BTT4/DataSample/vd1-2.txt";
var Graph = new AdjacencyMatrix(path);
var dijkstra = new Dijkstra(Graph);
Console.WriteLine("done");