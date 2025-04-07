class DeikstraAlg
{
    static void Main(string[] args)
    {
        int verticesCount = 6;
        int[,] WeightArray = new int[6, 6]
        {
            {0, 7, 9, 0, 0, 14 },
            {7, 0, 10, 15, 0, 0 },
            {9, 10, 0, 11, 0, 2 },
            {0, 15, 11, 0, 6, 0 },
            {0, 0, 0, 6, 0, 9 },
            {14, 0, 2, 0, 9, 0 },
        };

        Console.Write("Введите номер вершины из которого найти путь: ");
        int startVertices = Convert.ToInt32(Console.ReadLine()) - 1;
        Console.Write("Введите номер вершины до которой найти путь: ");
        int endVertices = Convert.ToInt32(Console.ReadLine()) - 1;

        int[] distances = new int[verticesCount];
        for (int i = 0; i < verticesCount; i++)
        {
            distances[i] = int.MaxValue;
        }
        distances[startVertices] = 0;


        List<int> visitedVertices = new List<int>();
        visitedVertices.Add(startVertices);

        while (visitedVertices.Count != verticesCount)
        {
            int minWeightVerticesNumber = 0;
            int minWeight = int.MaxValue;
            for (int i = 0; i < verticesCount; i++)
            {
                if (WeightArray[visitedVertices[^1], i] != 0 && !visitedVertices.Contains(i))
                {
                    if (distances[i] > WeightArray[visitedVertices[^1], i] + distances[visitedVertices[^1]])
                    {
                        distances[i] = WeightArray[visitedVertices[^1], i] + distances[visitedVertices[^1]];
                    }

                    (minWeight, minWeightVerticesNumber) = minWeight > WeightArray[visitedVertices[^1], i]
                    ? (WeightArray[visitedVertices[^1], i], i) : (minWeight, minWeightVerticesNumber);
                }
            }
            visitedVertices.Add(minWeightVerticesNumber);
        }
        Console.WriteLine(distances[endVertices]);
    }
}