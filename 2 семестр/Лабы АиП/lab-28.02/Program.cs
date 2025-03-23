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