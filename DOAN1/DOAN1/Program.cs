// See https://aka.ms/new-console-template for more information

using DOAN1;

Console.WriteLine("Hello, World!");
var Graph = new AdjacencyMatrix();
Graph.ReadNeiborNodefile("/Users/tonypham/Documents/GitHub/Lythuyetdothi/DOAN1/DOAN1/Input/VD4.txt");
switch (Graph.Undirect)
{
    case true:
        var CCU = new ConnectedComponentUndirected(Graph);
        break;
    case false:
        var CCD = new ConnectedComponentDirected(Graph);
        break;
}
// Grapinput.ShowAdjacencyMatrix();
// DFS Method = new DFS();
// Method.Import(Grapinput);