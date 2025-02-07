class Program
{
    
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите количество вершин");
        int n = int.Parse(Console.ReadLine());
        int[,] graf = new int[n, n];
        Console.WriteLine("Введите матрицу смежности");
        for (int i = 0; i <n; i++)
        {
            for (int j = 0; j <n; j++)
            {
                graf[i,j] = int.Parse(Console.ReadLine());
            }
        }
        //int n = 5;
        //int[,] graf = new int[5, 5] { { 0, 1, 0, 0,0 }, { 1, 0, 1, 0,0 }, { 0, 1, 0, 0,0 }, { 0, 0, 0, 0,1 },{ 0,0,0,1,0} };
        List<int> list1 = new List<int>();
        for (int i = 1; i <= n; i++)
        {
            list1.Add(i);
        }

        List<int> listt = new List<int> { };
        listt.Add(1);
        list1.Remove(1);
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
        for (int i = 0; i < listt.Count; i++)
        {
            Console.WriteLine(listt[i]);
        }
        if (list1.Count == 0)
        {
            Console.WriteLine("Граф связанный");
        }
        else
        {
            Console.WriteLine("Граф не связанный");
        }
    }
}