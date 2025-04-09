class Edge
{
    public int Start { get; set; }
    public int End { get; set; }

    public Edge(int start, int end)
    {
        Start = start;
        End = end;
    }
}

class Program
{
    static List<Edge> Prima(int VerticesCount, int[,] KoefArray)
    {
        List<int> visitedVertices = new List<int>();
        List<Edge> minSpanningTree = new List<Edge>();

        int VerticesNumber = 1;

        visitedVertices.Add(VerticesNumber);

        while (visitedVertices.Count() != VerticesCount)
        {
            int TempMinWeight = int.MaxValue;
            Edge minEdge = null;

            for (int i = 0; i < visitedVertices.Count(); i++)
            {
                for (int j = 0; j < VerticesCount; j++)
                {
                    if (KoefArray[visitedVertices[i] - 1, j] < TempMinWeight && KoefArray[visitedVertices[i] - 1, j] != 0 && !visitedVertices.Contains(j + 1))
                    {
                        TempMinWeight = KoefArray[visitedVertices[i] - 1, j];
                        minEdge = new Edge(visitedVertices[i], j + 1);
                    }
                }
            }

            if (minEdge != null)
            {
                minSpanningTree.Add(minEdge);
                visitedVertices.Add(minEdge.End);
            }

        }

        return minSpanningTree;
    }

    static int SearchComponent(int n, int[,] graf)
    {
        List<int> list1 = new List<int>();
        for (int i = 1; i <= n; i++)
        {
            list1.Add(i);
        }


        int count = 0;
        while (list1.Count != 0)
        {
            List<int> listt = new List<int> { };
            listt.Add(list1[0]);
            list1.Remove(list1[0]);
            int c = 0;
            while (list1.Count != 0)
            {
                c++;
                for (int i = c; i <= listt.Count; i++)
                {
                    int k = listt[i - 1];

                    for (int j = 0; j < n; j++)
                    {
                        if (graf[k - 1, j] != 0)
                        {
                            listt.Add(j + 1);
                            list1.Remove(j + 1);
                        }
                    }
                    break;
                }
                HashSet<int> hah = new HashSet<int>(listt);
                listt = hah.ToList();
                if (c == n + 1)
                {
                    break;
                }
            }
            count++;
        }
        return count;
    }



    static void Main(string[] args)
    {
        int VerticesCount = 6;
        int[,] KoefArray = new int[6, 6]
        {
            { 0, 1, 0, 1, 0, 0},
            { 1, 0, 1, 0, 1, 0 },
            { 0, 1, 0, 1, 0, 1 },
            { 1, 0, 1, 0, 0, 0 },
            { 0, 1, 0, 0, 0, 1 },
            { 0, 0, 1, 0, 1, 0 }
        };

        List<Edge> EdgeList = new List<Edge>();
        EdgeList = Prima(VerticesCount, KoefArray);

        List<Edge> BridgesList = new List<Edge>();
        int BridgesCount = 0;

        for (int i = 0; i < EdgeList.Count; i++)
        {
            int[,] TempKoefArray = (int[,])KoefArray.Clone();
            TempKoefArray[EdgeList[i].Start - 1, EdgeList[i].End - 1] = 0;
            TempKoefArray[EdgeList[i].End - 1, EdgeList[i].Start - 1] = 0;

            if (SearchComponent(VerticesCount, TempKoefArray) == 2)
            {
                BridgesList.Add(EdgeList[i]);
                BridgesCount++;
            }
        }

        if (BridgesCount == 0)
        {
            Console.WriteLine("Граф не имеет мостов");
        }
        else
        {
            Console.WriteLine($"Количество мостов в графе: {BridgesCount}");
            Console.WriteLine("Мосты: ");
            for (int i = 0; i < BridgesList.Count; i++)
            {
                Console.WriteLine(BridgesList[i].Start + " " + BridgesList[i].End);
            }
        }
    }
}