// See https://aka.ms/new-console-template for more information

using BTT4;
using Cau2;

Console.WriteLine("Hello, World!");
var path = "/Users/tonypham/Documents/GitHub/Lythuyetdothi/BTTuan4/BTT4/BTT4/DataSample/vd2-1.txt";
var Graph = new AdjacencyMatrix(path);
var bellmanFord = new Bellman_Ford(Graph);