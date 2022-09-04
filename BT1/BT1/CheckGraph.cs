namespace BT1;

public class CheckGraph
{
    public static bool IsUndirectedGraph(AdjacencyMatrix g) //kiem tra tinh co huong cua do thi
    {
        int i, j;
        bool isSymmetric = true;
        for (i = 0; i < g.n && isSymmetric; ++i)
        {
            if (g.a != null)
                for (j = i + 1; (j < g.n) && (g.a[i, j] == g.a[j, i]); ++j)
                {
                    if (j < g.n)
                        isSymmetric = false;
                }
        }
        return isSymmetric;
    }
    // Dem so canh
    public static int CountConnect(AdjacencyMatrix g)
    {
        int totalConnect = 0;
        switch (g.Undirect)
        {
            case true:
                for (int i = 0; i < g.n; i++)
                {
                    for (int j = 0; j < g.n && j>=i; j++)
                    {
                        totalConnect += g.a[i, j];
                    }
                }
                //Tinh bo sung canh khuyen
                for (int i = 0; i < g.n; i++)
                {
                    totalConnect += g.a[i, i];
                }
                break;
            case false:
                for (int i = 0; i < g.n; i++)
                {
                    for (int j = 0; j < g.n; j++)
                    {
                        totalConnect += g.a[i, j];
                    }
                }
                break;
        }

        return totalConnect;

    }
    //Dem so canh boi
    public static int CountDoubleConnect(AdjacencyMatrix g)
    {
        int totalDoubleConnect = 0;
        switch (g.Undirect)
        {
            case true:
                for (int i = 0; i < g.n; i++)
                {
                    for (int j = 0; j < g.n && j>=i; j++)
                    {
                        if (g.a[i,j]>1)
                        {
                            totalDoubleConnect += 1;
                        }
                    }
                }
                break;
            case false:
                for (int i = 0; i < g.n; i++)
                {
                    for (int j = 0; j < g.n; j++)
                    {
                        if (g.a[i,j]>0 && g.a[j,i]>0)
                        {
                            totalDoubleConnect += 1;
                        }

                        if (g.a[i,j]>1)
                        {
                            totalDoubleConnect += 1;
                        }
                        
                    }
                }
                break;
        }
        return totalDoubleConnect;
    }
    //kiem tra do thi chua canh khuyen
    private bool isGraphHasNoLoops(AdjacencyMatrix g)
    { 
        for (int i = 0; i < g.n && g.a[i, i] == 0; i++)
        {
            if (i < g.n)
                return false;
        }
        return true;
    }


    //dem so canh khuyen
    public static int countloopsGraph(AdjacencyMatrix g)
    {
        int LoopNode = 0;
        for (int i = 0; i < g.n && g.a[i, i] != 0; i++)
        {
            LoopNode += g.a[i, i];
        }
        return LoopNode;
    }
    //Dem so canh co lap
    private static int countIndependentNode(AdjacencyMatrix g)
    {
        int UnconnectNode = 0;
        for (int i = 0; i<g.n; i++)
        {
            int sumrow = 0;
            for (int j = 0; j < g.n; j++)
            {
                sumrow += g.a[i, j];
            }
            if (sumrow ==0)
            {
                UnconnectNode += 1;
            }
        }

        return UnconnectNode;
    }
    //kiem tra dinh treo
    private static bool isPendant(int NodeName, AdjacencyMatrix g)
    {
        int count = 0;
        if (g.a[NodeName,NodeName]==1)
        {
            return false;
        }

        for (int i = 0; i < g.n && i!=NodeName; i++)
        {
            count += g.a[i, NodeName] + g.a[NodeName, i];
        }

        if (count>0)
        {
            return false;
        }
        return true;
    }
    //Dem so dinh doc lap
    public static int CountPendant(AdjacencyMatrix g)
    {
        int count = 0;
        for (int i = 0; i < g.n; i++)
        {
            if (isPendant(i,g))
            {
                count += 1;
            }
        }

        return count;
    }
    
}