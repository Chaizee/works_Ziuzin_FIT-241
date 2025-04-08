class Program
{
    static void Main(string[] args)
    {
        string[,] array = new string[7, 7]
        {
            { "x", "x", "x", "x", "x", "x", "x" },
            { "x", " ", " ", " ", " ", " ", "x" },
            { "x", " ", " ", " ", "x", "x", "x" },
            { "x", "x", "x", " ", " ", " ", "x" },
            { "x", " ", " ", " ", "x", "x", "x" },
            { "x", " ", " ", " ", "x", " ", "x" },
            { "x", "x", "x", "x", "x", "x", "x" }
        };

        Console.WriteLine("Введите координаты начальной вершины: ");
        int start1 = Convert.ToInt32(Console.ReadLine());
        int start2 = Convert.ToInt32(Console.ReadLine());

        int MaxWeight = 0;
        array[start1, start2] = "0";
        bool HasPath = true;
        while (HasPath)
        {
            bool conditionsfulfillment = false;
            for (int i = 1; i < array.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < array.GetLength(0) - 1; j++)
                {
                    if (array[i, j] != " " && array[i, j] != "x" && Convert.ToInt32(array[i, j]) == MaxWeight)
                    {
                        if (array[i + 1, j] == " ")
                        {
                            array[i + 1, j] = (Convert.ToInt32(array[i, j]) + 1).ToString();
                            HasPath = true;
                            conditionsfulfillment = true;
                        }
                        if (array[i - 1, j] == " ")
                        {
                            array[i - 1, j] = (Convert.ToInt32(array[i, j]) + 1).ToString();
                            HasPath = true;
                            conditionsfulfillment = true;
                        }
                        if (array[i, j + 1] == " ")
                        {
                            array[i, j + 1] = (Convert.ToInt32(array[i, j]) + 1).ToString();
                            HasPath = true;
                            conditionsfulfillment = true;
                        }
                        if (array[i, j - 1] == " ")
                        {
                            array[i, j - 1] = (Convert.ToInt32(array[i, j]) + 1).ToString();
                            HasPath = true;
                            conditionsfulfillment = true;
                        }
                        if (!conditionsfulfillment)
                        {
                            HasPath = false;
                        }
                    }
                }
            }
            MaxWeight++;
        }

        Console.WriteLine("Введите координаты конечной вершины: ");
        int end1 = Convert.ToInt32(Console.ReadLine());
        int end2 = Convert.ToInt32(Console.ReadLine());

        if (array[end1, end2] == " ")
        {
            Console.WriteLine("До этой выршины нет пути");
        }
        else
        {
            Console.WriteLine($"Минимальный путь до вершины ({end1},{end2}) из ({start1},{start2}): {(array[end1, end2])}");
        }
    }
}
