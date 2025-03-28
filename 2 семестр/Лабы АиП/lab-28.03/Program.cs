//Задача 1
class Program
{
    static void Main(string[] args)
    {
        float first = 10.0f;
        float second = 0.0f;

        var sum = (float x, float y) => x + y;
        Console.WriteLine($"{first} + {second} = {sum(first, second)}");

        var substract = (float x, float y) => (x - y);
        Console.WriteLine($"{first} - {second} = {substract(first, second)}");

        var multiply = (float x, float y) => (float)x * y;
        Console.WriteLine($"{first} * {second} = {multiply(first, second)}");

        if (second != 0.0f)
        {
            var divide = (float x, float y) => (float)(x / y);
            Console.WriteLine($"{first} / {second} = {divide(first, second)}");
        }
        else
        {
            throw new DivideByZeroException("Деление на ноль невозможно");
        }
    }
}

//Задача 2

class Program
{
    static void Main(string[] args)
    {
        List<string> list = new List<string>();

        Console.WriteLine("Введите элементы списка (Чтобы перестать введите '.')");
        string Temp = Console.ReadLine();
        while (Temp != ".")
        {
            list.Add(Temp);
            Temp = Console.ReadLine();
        }

        static void SearchChar(string str, char substr) => Console.Write(str[0] == substr ? str + "\n": "");

        Console.WriteLine("\nПолученные элементы: ");
        foreach (string s in list)
        {
            SearchChar(s, 'm');
        }
    }
}