//Прима
class AlgByPrima
{
    static void Main(string[] args)
    {
        int VerticesCount = 6;
        int[,] KoefArray = new int[6, 6]
        {
            { 0, 0, 2, 3, 0, 0 },
            { 0, 0, 0, 10, 0, 0 },
            { 2, 0, 0, 7, 10, 15 },
            { 3, 10, 7, 0, 9, 0 },
            { 0, 0, 10, 9, 0, 4 },
            { 0, 0, 15, 0, 4, 0 }
        };

        List<int> VerticesList = new List<int>();

        int MinSumm = 0;
        int VerticesNumber = 1;

        VerticesList.Add(VerticesNumber);

        while (VerticesList.Count() != VerticesCount)
        {
            int TempMinWeight = int.MaxValue;

            for (int i = 0; i < VerticesList.Count(); i++)
            {
                for (int j = 0; j < VerticesCount; j++)
                {
                    if (KoefArray[VerticesList[i] - 1, j] < TempMinWeight && KoefArray[VerticesList[i] - 1, j] != 0 && !VerticesList.Contains(j + 1))
                    {
                        TempMinWeight = KoefArray[VerticesList[i] - 1, j];
                        VerticesNumber = j + 1;
                    }
                }
            }

            MinSumm += TempMinWeight;
            VerticesList.Add(VerticesNumber);
        }
        Console.WriteLine(MinSumm);
    }
}

//Крускала

class EdgeWeihgtList
{
    public int Weight { get; set; }
    public int StartVertices { get; set; }
    public int EndVertices { get; set; }

    public EdgeWeihgtList(int startvertices, int endvertices, int weight)
    {
        Weight = weight;
        StartVertices = startvertices;
        EndVertices = endvertices;
    }
}

class AlgByKruskal
{
    static void Main(string[] args)
    {
        int VerticesCount = 6;
        int[,] KoefArray = new int[6, 6]
        {
            { 0, 0, 2, 3, 0, 0 },
            { 0, 0, 0, 10, 0, 0 },
            { 2, 0, 0, 7, 10, 15 },
            { 3, 10, 7, 0, 9, 0 },
            { 0, 0, 10, 9, 0, 4 },
            { 0, 0, 15, 0, 4, 0 }
        };

        List<int> VerticesList = new List<int>();

        List<EdgeWeihgtList> EdgeList = new List<EdgeWeihgtList>();

        for (int i = 0; i < VerticesCount; i++)
        {
            for (int j = i; j < VerticesCount; j++)
            {
                if (KoefArray[i, j] != 0)
                {
                    EdgeList.Add(new EdgeWeihgtList(i, j, KoefArray[i, j]));
                }
            }
        }

        EdgeList.Sort((x, y) => x.Weight.CompareTo(y.Weight));

        int MinOstSumm = 0;
        VerticesList.Add(EdgeList[0].StartVertices);
        VerticesList.Add(EdgeList[0].EndVertices);
        MinOstSumm += EdgeList[0].Weight;
        Console.WriteLine(MinOstSumm);

        EdgeList.RemoveAt(0);

        List<EdgeWeihgtList> NewComponentList = new List<EdgeWeihgtList>();

        while (VerticesList.Count() != VerticesCount && EdgeList.Count() != 0)
        {
            if ((VerticesList.Contains(EdgeList[0].StartVertices) && !VerticesList.Contains(EdgeList[0].EndVertices)) ||
                (!VerticesList.Contains(EdgeList[0].StartVertices) && VerticesList.Contains(EdgeList[0].EndVertices)))
            {
                if (NewComponentList.Count() != 0)
                {
                    int RepeatCount = 0;
                    while (NewComponentList.Count() != 0)
                    {
                        RepeatCount++;
                        if (VerticesList.Contains(NewComponentList[0].StartVertices) && !VerticesList.Contains(NewComponentList[0].EndVertices) ||
                            !VerticesList.Contains(NewComponentList[0].StartVertices) && VerticesList.Contains(NewComponentList[0].EndVertices))
                        {
                            VerticesList.Add(NewComponentList[0].EndVertices);
                            MinOstSumm += NewComponentList[0].Weight;
                            Console.WriteLine(MinOstSumm);

                            NewComponentList.RemoveAt(0);
                        }
                        if (RepeatCount >= NewComponentList.Count())
                        {
                            break;
                        }
                    }
                }

                VerticesList.Add(EdgeList[0].EndVertices);
                MinOstSumm += EdgeList[0].Weight;
                Console.WriteLine(MinOstSumm);

                EdgeList.RemoveAt(0);
            }

            else if (!VerticesList.Contains(EdgeList[0].StartVertices) && !VerticesList.Contains(EdgeList[0].EndVertices))
            {
                NewComponentList.Add(new EdgeWeihgtList(EdgeList[0].StartVertices, EdgeList[0].EndVertices, EdgeList[0].Weight));
                EdgeList.RemoveAt(0);
            }
            else
            {
                EdgeList.RemoveAt(0);
            }
        }
    }
}
