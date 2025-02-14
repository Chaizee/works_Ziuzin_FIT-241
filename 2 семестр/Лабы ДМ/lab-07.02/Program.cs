//Первый алгоритм

class Program
{

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите количество вершин");
        int n = int.Parse(Console.ReadLine());
        int[,] graf = new int[n, n];
        Console.WriteLine("Введите матрицу смежности");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                graf[i, j] = int.Parse(Console.ReadLine());
            }
        }
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
                        if (graf[k - 1, j] == 1)
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
        Console.WriteLine($"Граф имеет {count} компонент связанностей");

    }
}

//Второй алгоритм

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите количество вершин");
        int n = int.Parse(Console.ReadLine());
        int[,] graf = new int[n, n];
        Console.WriteLine("Введите матрицу смежности");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                graf[i, j] = int.Parse(Console.ReadLine());
            }
        }

        List<int> list1 = new List<int>();
        for (int i = 1; i <= n; i++)
        {
            list1.Add(i);
        }

        List<int> listt = new List<int>();
        listt.Add(1);
        int c = 0;
        while (listt.Count != n)
        {
            c++;
            List<int> temp = new List<int>();
            for (int i = 0; i <= c - 1; i++)
            {

                if (graf[c, i] == 1)
                {
                    temp.Add(listt[i]);

                }
            }

            if (listt.Count != c + 1)
            {
                temp.Add(listt[c - 1] + 1);

            }
            listt.Add(Enumerable.Min(temp));

        }
        for (int f = 0; f < n; f++)
        {
            for (int i = 1; i < listt.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (listt[i] < listt[j])
                    {

                        if (graf[i, j] == 1)
                        {
                            listt[j] = listt[i];
                        }

                    }
                }
            }
        }
        HashSet<int> hah = new HashSet<int>(listt);
        listt = hah.ToList();

        Console.WriteLine($"Граф имеет {listt.Count} компонент связанностей");
    }
}
