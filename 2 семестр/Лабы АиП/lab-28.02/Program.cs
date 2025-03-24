// 1 Задача. Обратная польская запись(постфиксная)
class Program
{
    public static void Main(string[] args)
    {
        var stack = new Stack<string>();
        Console.WriteLine("Введите запись: ");
        string String = Console.ReadLine();

        string[] SubstringsArray = String.Split(' ');

        foreach (var Char in SubstringsArray)
        {
            switch(Char)
            {
                case "*":
                    int TempMultiply = int.Parse(stack.Pop()) * int.Parse(stack.Pop());
                    stack.Push(TempMultiply.ToString());
                    break;
                case "+":
                    int TempPlus = int.Parse(stack.Pop()) + int.Parse(stack.Pop());
                    stack.Push(TempPlus.ToString());
                    break;
                case "-":
                    int TempSubtrahend = int.Parse(stack.Pop());
                    int TempMinuend = int.Parse(stack.Pop());
                    int TempMinus =  TempMinuend - TempSubtrahend;
                    stack.Push(TempMinus.ToString());
                    break;
                case "/":
                    int TempDenominator = int.Parse(stack.Pop());
                    if (TempDenominator == 0)
                    {
                        Console.WriteLine("Выражение задано неверно, так как деление на ноль невозможно!");   
                    }
                    int TempNumerator = int.Parse(stack.Pop());
                    int TempDivision = TempNumerator / TempDenominator;
                    stack.Push(TempDivision.ToString());
                    break;
                default:
                    stack.Push(Char);
                    break;
            }
        }
        int FinallResult = int.Parse(stack.Pop());
        if (stack.Count == 0)
        {
            Console.WriteLine($"Выражение задано верно. Полученный результат: {FinallResult}");
        }
        else
        {
            Console.WriteLine("Выражение задано неверно");
        }
    }
}

// 2 Задача. Словарь

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите числовую последовательность (чтобы перестать введите '.')");
        List<int> list = new List<int>();
        string StrInput = Console.ReadLine();

        while (StrInput != ".")
        {
            list.Add(int.Parse(StrInput));
            StrInput = Console.ReadLine();
        }

        Dictionary<int, int> Counts = new Dictionary<int, int>();

        foreach (var i in list)
        {
            if (!Counts.ContainsKey(i))
            {
                Counts[i] = 1;
            }
            else
            {
                Counts[i]++;
            }
        }

        foreach (var (key, val) in Counts)
        {
            Console.WriteLine($"Значение: {key}, Количество: {val}");
        }
    }
}