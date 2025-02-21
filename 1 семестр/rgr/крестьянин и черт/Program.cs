using System;

class Chert
{
    public static void Main(string[] args)
    {
        int MaxN = int.Parse(Console.ReadLine());
        int count = 0;
        for (int n = 1; n <= MaxN; n++)
        {
            for (int k = 2; k <= 3 * n; k++)
            {
                int j = n;
                while (j > 0)
                {
                    int j1 = j;
                    j = (j1 * 2) - k;
                    if (j == j1)
                    {
                        break;
                    }

                    if (j == 0)
                    {
                        count++;
                    }
                }
            }
        }
        Console.WriteLine(count);
    }
}
