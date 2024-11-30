//отсортировать столбцы массива по возрастанию их сумм
class Lab
{
    public static void Main(string[] args)
    {
       Console.WriteLine("Введите размеры массива");
       int g = int.Parse(Console.ReadLine());
       int h = int.Parse(Console.ReadLine());
       int[,] arr = new int[g, h];
       Console.WriteLine("Введите элементы массива");
       for (int i = 0; i < g; i++)
       {
           for (int j = 0; j < g; j++)
           {
               arr[i, j] = int.Parse(Console.ReadLine());
           }
       }

       for (int n = 0; n < arr.GetLength(1); n++)
       {
           for (int j = 1; j < arr.GetLength(1); j++)
           {
               int sumPrevColum = 0;
               for (int i = 0; i < arr.GetLength(0); i++)
               {
                   sumPrevColum += arr[i, j - 1];
               }

               int sumCurrentColum = 0;
               for (int i = 0; i < arr.GetLength(0); i++)
               {
                   sumCurrentColum += arr[i, j];
               }

               if (sumPrevColum > sumCurrentColum)
               {
                   for (int c = 0; c < arr.GetLength(0); c++)
                   {
                       int temp = arr[c, j];
                       arr[c, j] = arr[c, j - 1];
                       arr[c, j - 1] = temp;
                   }
               }
           }
       }

       for (int i = 0; i < arr.GetLength(0); i++)
       {
           for (int j = 0; j < arr.GetLength(1); j++)
           {
               Console.Write("{0}\t", arr[i, j]);
           }
           Console.WriteLine();
       }
       Console.ReadLine();
    } 
}

//определить номера пар строк, состоящих из одинаковых элементов    
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите размеры массива");
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите элементы массива");
        int[,] mus = new int[n, m];
        int[,] exmus = new int[m, 3];
        Console.WriteLine("Введите элементы массива");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                mus[i, j] = int.Parse(Console.ReadLine());
            }
        }

        for (int i = 0; i < m; i++)
        {
            int stlsum = 0, stlpr = 1, nulcount = 0;
            for (int j = 0; j < n; j++)
            {
                stlsum += mus[j, i];
                if (mus[j, i] == 0)
                {
                    nulcount++;
                }
                if (mus[j, i] != 0)
                {
                    stlpr *= mus[j, i];
                }
            }
            exmus[i, 0] = stlsum;
            exmus[i, 1] = stlpr;
            exmus[i, 2] = nulcount;
        }
        bool hasEqualColumns = false;
        for (int i = 0;i < m-1;i++)
        {
            for (int j = i + 1; j < m; j++)
            {
                if ((exmus[i, 0] == exmus[j, 0]) && (exmus[i, 1] == exmus[j, 1]) && (exmus[i, 2] == exmus[j, 2]))
                {
                    if (!hasEqualColumns)
                    {
                        Console.WriteLine("Пары одинаковых столбцов: ");
                        hasEqualColumns = true;
                    }
                    Console.Write($"({i + 1},{j + 1})");
                }
            }
        }
        if (!hasEqualColumns)
        {
            Console.WriteLine("Одинаковых столбцов нет");
        }
    }
}

//определить положение элементов минимакса

using System.Linq.Expressions;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите размеры массива");
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        
        int[,] mus = new int[n, m];

        Console.WriteLine("Введите элементы массива");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                mus[i, j] = int.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine();
        bool ElemExist1 = false;
        bool ElemExist2 = false;
        for (int i = 0; i < n; i++)
        {
            int minstr = int.MaxValue;
            int maxstr = int.MinValue;
            for (int j = 0; j < m; j++)
            {
                if (mus[i, j] < minstr)
                {
                    minstr = mus[i, j];
                }
                if  (mus[i, j] > maxstr)
                {
                    maxstr = mus[i, j];
                }
            }
            
            for (int k = 0; k < m; k++)
            {
                int maxstl = int.MinValue;
                int minstl = int.MaxValue;
                for (int l = 0; l < n; l++)
                {
                    if (mus[l, k] > maxstl)
                    {
                        maxstl = mus[l, k];
                    }
                    if (mus[l, k] < minstl)
                    {
                        minstl = mus[l, k];
                    }
                }
                if (minstr == maxstl)
                {
                    if (!ElemExist1)
                    {
                        Console.WriteLine("Положение элемента(ов) минимального(ых) в строке и максимального(ых) в столбце:");
                        ElemExist1 = true;
                    }
                    Console.WriteLine($"({i + 1};{k + 1})");
                }  
                if (maxstr == minstl)
                {
                    if (!ElemExist2)
                    {
                        Console.WriteLine("Положение элемента(ов) максимального(ых) в строке и минимального(ых) в столбце:");
                        ElemExist2 = true;
                    }
                    Console.WriteLine($"({i + 1};{k + 1})");
                }
            }

        }
        if (!ElemExist1)
        {

            Console.WriteLine("не существует элемента минимального в строке и максимального в столбце");
        }
        if (!ElemExist2)
        {

            Console.WriteLine("не существует элемента максимального в строке и минимального в столбце");
        }
    }
}
