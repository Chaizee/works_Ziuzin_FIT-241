class Floyd
{
    static void Main(string[] args)
    {
        int verticesCount = 4;
        int[,] WeightArray = new int[4, 4]
        {
            {0, 1, 6, 0},
            {0, 0, 4, 1},
            {0, 0, 0, 0},
            {0, 0, 1, 0}
        };

        for (int i = 0; i < verticesCount; i++)
        {
            for (int j = 0; j < verticesCount; j++)
            {
                if (i != j && WeightArray[i, j] == 0)
                {
                    WeightArray[i, j] = int.MaxValue;
                }
            }
        }

        for (int k = 0; k < verticesCount; k++)
        {
            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = 0; j < verticesCount; j++)
                {
                    if (WeightArray[i, k] != int.MaxValue && WeightArray[k,j] != int.MaxValue)
                    {
                        WeightArray[i, j] = Math.Min(WeightArray[i, j], WeightArray[i, k] + WeightArray[k, j]);
                    }
                }
            }
        }

        Console.WriteLine("Введите номер вершины с которой будет произведен поиск путей до остальных");
        int startVertices = Convert.ToInt32(Console.ReadLine()) - 1;

        for (int i = 0; i < verticesCount; i++)
        {
            if (WeightArray[startVertices, i] != int.MaxValue)
            {
                Console.WriteLine($"Путь из вершины {startVertices} в вершину {i + 1} : {WeightArray[startVertices, i]}");
            }
            else
            {
                Console.WriteLine($"Из вершины {startVertices} в вершину {i + 1} нет пути");
            }
        }
    }
}