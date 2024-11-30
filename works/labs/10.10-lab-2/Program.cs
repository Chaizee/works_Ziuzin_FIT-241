//определить кол-во элементов, все цифры которых четные
using System.Dynamic;
using System.Transactions;

class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] mus = new int[n];
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            mus[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < n; i++)
        {
            int number = mus[i];
            int chet = 0;    
            int prom = 0;
            while (number > 0) {
                if (( number % 10) % 2 == 0)
                {
                    chet++;
                }
                number/=10;
                prom++;
            }
            if (chet == prom)
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }
}


//заменить все четные элементы на 0, нечетные - на 1
class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] mus = new int[n];
        for (int i = 0; i < n; i++)
        {
            mus[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < n; i++)
        {
            if (mus[i] % 2 == 0)
            {
                mus[i] = 0;
            }
            else
            {
                mus[i] = 1;
            }
        }
        Console.WriteLine();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(mus[i]);
        }    
    }
}
//сформировать выходной массив, в который необходимо сначала положить все четные элементы, а потом нечетные
class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] mus = new int[n];
        int[] exits = new int[n];
        int evenindex = 0;
        int oddindexs = n;
        for (int i = 0; i < n; i++)
        {
            mus[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < n; i++)
        {
            if (mus[i] % 2 == 0)
            {
                exits[evenindex]= mus[i];
                evenindex++;
            }

            else
            {
                oddindexs--;
                exits[oddindexs] = mus[i];
            }
        }

        Console.WriteLine();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(exits[i]);
        }
    }
}
