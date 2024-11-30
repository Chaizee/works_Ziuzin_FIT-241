class lab
{
    public int x;
    public int y;

    public lab()
    {
        x = 0;
        y = 0;
    }

    public lab(int a)
    {
        x = a;
        y = 0;
    }

    public lab(int a, int b)
    {
        x = a;
        y = b;
    }

    public int Sum()
    {
        return x + y;
    }

    public int Multiply()
    {
        return y * x;
    }

    public int Subtract() 
    { 
        return x - y; 
    }

    public double Divide()
    {
        if (y == 0)
        {
            throw new DivideByZeroException("Деление на ноль невозможно");
        }
        return x / y;
    }
}
class Program
{
    static void Main(string[] args)
    {
        lab konstr1 = new lab();
        lab konstr2 = new lab(5);
        lab konstr3 = new lab(10,2);

        Console.WriteLine($"Sum konstr1: {konstr1.Sum()}");
        Console.WriteLine($"Multiply konstr1: {konstr1.Multiply()}");
        Console.WriteLine($"Subtract konstr1: {konstr1.Subtract()}");
        try
        {
            Console.WriteLine($"Divide konstr1: {konstr1.Divide()}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Divide konstr1: {ex.Message}");
        }
        Console.WriteLine($"Sum konstr2: {konstr2.Sum()}");
        Console.WriteLine($"Multiply konstr2: {konstr2.Multiply()}");
        Console.WriteLine($"Subtract konstr2: {konstr2.Subtract()}");
        try
        {
            Console.WriteLine($"Divide konstr2: {konstr1.Divide()}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Divide konstr2: {ex.Message}");
        }

        Console.WriteLine($"Sum konstr3: {konstr3.Sum()}");
        Console.WriteLine($"Multiply konstr3: {konstr3.Multiply()}");
        Console.WriteLine($"Subtract konstr3: {konstr3.Subtract()}");
        Console.WriteLine($"Divide konstr3: {konstr3.Divide()}");

    }
}