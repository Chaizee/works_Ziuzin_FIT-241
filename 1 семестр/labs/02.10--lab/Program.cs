//Лаба 02.10 
//Определить максимальный размер подпоследовательности состоящей из одинаковых элементов
class Lab
{
    public static void Main (string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int k, f, mx=0, o, c=1;
        f = int.Parse(Console.ReadLine());
        for (k = 1; k < n; k++) {
            o = int.Parse(Console.ReadLine());
            if (o == f) {
                c++;
            }
            f = o;
            mx = c > mx ? c : mx;
        }
        Console.WriteLine(c);
    }
}

//определить минимальный размер подпоследовательности состоящей из четных элементов

using static System.Math;
class Lab
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int pred, min = int.MaxValue, k, count = 0, next;
        pred = int.Parse(Console.ReadLine());
        if (Math.Abs(pred) % 2 == 0)
        {
            count++;
        }
        else
        {
            count = 0;
        }
        for (k = 1; k < n; k++)
        {
            next = int.Parse(Console.ReadLine());
            if (Math.Abs(next) % 2 == 0)
            {
                count++;
            }
            else
            {
                if (count > 0) 
                { 
                    min = Math.Min(min, count); 
                    count = 0; 
                }
            }
        }
        if (count > 0) 
        {
            min = Math.Min(min, count); 
        } 
        if (min == int.MaxValue) 
        {
            Console.WriteLine("Четных элементов нет"); 
        } 
        else 
        {
            Console.WriteLine(min); 
        }
    }
}




//определить максимальную сумму подпоследовательности состоящей из четных элементов
using static System.Math;
class Lab
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int pred, max = -10000, k, sum = 0, next;
        pred = int.Parse(Console.ReadLine());
        if (Math.Abs(pred) % 2 == 0)
        {
            sum = sum + pred;
        }
        else
        {
            sum = 0;
        }
        for (k = 1; k < n; k++)
        {
            next = int.Parse(Console.ReadLine());
            if (Math.Abs(next) % 2 == 0)
            {
                sum = sum + next;
            }
            else
            {
                max = Math.Max(max, sum);
                sum = 0;
            }
        }
        Console.WriteLine(max);
    }
}
