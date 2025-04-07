class FordBelman
{
    static void Main(string[] args)
    {
        int verticesCount = 5;
        int[,] WeightArray = new int[5, 5]
        {
            {0, 6, 7, 0, 0 },
            {0, 0, 8, -4, 5 },
            {0, 0, 0, 9, -3 },
            {2, 0, 0, 0, 7 },
            {0, -2, 0, 0, 0 },
        };

        Console.Write("Введите номер вершины из которого найти путь: ");
        int startVertices = Convert.ToInt32(Console.ReadLine()) - 1;

        int[] distances = new int[verticesCount];
        for (int i = 0; i < verticesCount; i++)
        {
            distances[i] = int.MaxValue;
        }
        distances[startVertices] = 0;

        for (int i = 1; i < verticesCount; i++)
        {
            for (int j = 0; j < verticesCount; j++)
            {
                for (int k = 0; k < verticesCount; k++)
                {
                    if (WeightArray[j, k] != 0 && distances[j] != int.MaxValue && WeightArray[j, k] + distances[j] < distances[k])
                    {
                        distances[k] = WeightArray[j, k] + distances[j];
                    }
                }
            }
        }

        bool NegativeCicle = false;

        for (int i = 0; i < verticesCount; i++)
        {
            for (int j = 0; j < verticesCount; j++)
            {
                if (WeightArray[i, j] != 0 && distances[i] != int.MaxValue && WeightArray[i, j] > distances[i] + WeightArray[i, j])
                {
                    NegativeCicle = true;
                    break;
                }
            }

            if (NegativeCicle)
            {
                break;
            }
        }

        if (NegativeCicle)
        {
            Console.WriteLine("Граф содержит отрицательный цикл");
        }
        else
        {
            for (int i = 0; i < verticesCount; i++)
            {
                if (startVertices != i)
                {
                    if (distances[i] == int.MaxValue)
                    {
                        Console.WriteLine($"Путь из {startVertices + 1} вершины в {i + 1} не существует");
                    }
                    else
                    {
                        Console.WriteLine($"Путь из {startVertices + 1} вершины в {i + 1}: {distances[i]}");
                    }
                }
            }
        }
    }
}
