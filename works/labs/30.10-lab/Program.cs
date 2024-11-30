using System.Security.Cryptography;

class Program
{
    public static void Main(string[] args)
    {

        {
            int sum0 = 0, sum1 = 0, sum2 = 0, sum3 = 0, mx0 = 0, mx1 = 0, mx2 = 0, mx3 = 0, c0 = 0, c1 = 0, c2 = 0, c3 = 0;
            int[][] mus = new int[4][];

            Console.WriteLine("Введите количество столбцов в первом массиве");
            int v = int.Parse(Console.ReadLine());
            mus[0] = new int[v];
            Console.WriteLine("Введите элементы первого массива");
            for (int j = 0; j < v; j++)
            {
                mus[0][j] = int.Parse(Console.ReadLine());
                if ((mus[0][j]) % 2 == 0)
                {
                    c0++;
                }
                sum0 += mus[0][j];
            }
            for (int j = 0; j < v; j++)
            {
                if (mus[0][j] > sum0 - mus[0][j])
                {
                    mx0 = j;
                }
            }

            Console.WriteLine("Введите количество столбцов во втором массиве");
            int c = int.Parse(Console.ReadLine());
            mus[1] = new int[c];
            Console.WriteLine("Введите элементы второго массива");
            for (int j = 0; j < c; j++)
            {
                mus[1][j] = int.Parse(Console.ReadLine());
                if ((mus[1][j]) % 2 == 0)
                {
                    c1 += 1;
                }
                sum1 += mus[1][j];
            }
            for (int j = 0; j < c; j++)
            {
                if (mus[1][j] > sum1 - mus[1][j])
                {
                    mx1 = j;
                }
            }

            Console.WriteLine("Введите количество столбцов в третьем массиве");
            int x = int.Parse(Console.ReadLine());
            mus[2] = new int[x];
            Console.WriteLine("Введите элементы третьего массива");
            for (int j = 0; j < x; j++)
            {
                mus[2][j] = int.Parse(Console.ReadLine());
                if ((mus[2][j]) % 2 == 0)
                {
                    c2 += 1;
                }
                sum2 += mus[2][j];
            }
            for (int j = 0; j < x; j++)
            {
                if (mus[2][j] > sum2 - mus[2][j])
                {
                    mx2 = j;
                }
            }

            Console.WriteLine("Введите количество столбцов в четвертом массиве");
            int z = int.Parse(Console.ReadLine());
            mus[3] = new int[z];
            Console.WriteLine("Введите элементы четвертого массива");
            for (int j = 0; j < z; j++)
            {
                mus[3][j] = int.Parse(Console.ReadLine());
                if ((mus[3][j]) % 2 == 0)
                {
                    c3 += 1;
                }
                sum3 += mus[3][j];
            }
            for (int j = 0; j < z; j++)
            {
                if (mus[3][j] > sum3 - mus[3][j])
                {
                    mx3 = j;
                }
            }

            Console.WriteLine($"Количество чётных чисел в первом массиве: {c0}");
            Console.WriteLine($"Количество нечётных чисел в первом массиве: {v - c0}");
            if (mx0 != 0)
            {
                Console.WriteLine($"Положение элемента, который больше суммы других: {0 + 1} {mx0+1}");
            }
            else
            {
                Console.WriteLine("В первой строке нет элемента который больше суммы остальных");
            }
            Console.WriteLine();
            Console.WriteLine($"Количество чётных чисел во втором массиве: {c1}");
            Console.WriteLine($"Количество нечётных чисел во втором массиве: {c - c1}");
            if (mx1 != 0)
            {
                Console.WriteLine($"Положение элемента, который больше суммы других: {1 + 1} {mx1+1}");
            }
            else
            {
                Console.WriteLine("Во второй строке нет элемента который больше суммы остальных");
            }
            Console.WriteLine();
            Console.WriteLine($"Количество чётных чисел в третьем массиве: {c2}");
            Console.WriteLine($"Количество нечётных чисел в третьем массиве: {x - c2}");
            if (mx2 != 0)
            {
                Console.WriteLine($"Положение элемента, который больше суммы других: {2 + 1} {mx2+1}");
            }
            else
            {
                Console.WriteLine("В третьей строке нет элемента который больше суммы остальных");
            }
            Console.WriteLine();
            Console.WriteLine($"Количество чётных чисел в четвертом массиве: {c3}");
            Console.WriteLine($"Количество нечётных чисел в четвертом массиве: {z - c3}");
            if (mx3 != 0)
            {
                Console.WriteLine($"Положение элемента, который больше суммы других: {3 + 1} {mx3+1}");
            }
            else
            {
                Console.WriteLine("В четвертой строке нет элемента который больше суммы остальных");
            }

        }
    }
}