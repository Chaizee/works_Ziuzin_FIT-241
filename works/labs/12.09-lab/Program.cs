//задача поменять значение переменых используя только 2 переменные
class Lab
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите значение переменной a");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите значение переменной b");
        int b = int.Parse(Console.ReadLine());
        a = a + b;
        b = a - b;
        a = a - b;

        Console.WriteLine($"a={a}, b={b}");
    }
    
}

//задача надо из 2 переменных вывести наибольшую нельзя использовать max , if , знаки сравненияx`
class Lab
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите значение переменной a");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите значение переменной b");
        int b = int.Parse(Console.ReadLine());
        int c = (a + b + Math.Abs(a - b))/2;
        Console.WriteLine(c);
    }
    
}
//задача про грядки
class Lab
{
    public static void Main(string[] args)
    {
        int p, m, l, n, res;
        Console.WriteLine("Введите длину от колодца до грядки");
        p = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите длину грядки");
        m = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите ширину грядки");
        l = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите количество  грядок");
        n = Convert.ToInt32(Console.ReadLine());
        res = (p + m * 2 + l * 2 + l * (n - 1) + p) * n;
        Console.WriteLine("Пройденный путь: " + res);
    }
    
}
