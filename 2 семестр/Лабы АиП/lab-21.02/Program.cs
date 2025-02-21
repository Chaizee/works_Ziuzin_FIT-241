class Program
{
    static void Main(string[] args)
    {
        var stack = new Stack<char>();
        string str = Console.ReadLine();

        foreach (var c in str)
        {
            switch (c)
            {
                case '(':
                    stack.Push(c);
                    break;
                case '{':
                    stack.Push(c);
                    break;
                case '[':
                    stack.Push(c);
                    break;
                case ')':
                    if (stack.Count == 0 || stack.Peek() != '(')
                    {
                        Console.WriteLine("Неправильно задано выражение");
                        return;
                    }
                    stack.Pop();
                    break;
                case '}':
                    if (stack.Count == 0 || stack.Peek() != '{')
                    {
                        Console.WriteLine("Неправильно задано выражение");
                        return;
                    }
                    stack.Pop();
                    break;
                case ']':
                    if (stack.Count == 0 || stack.Peek() != '[')
                    {
                        Console.WriteLine("Неправильно задано выражение");
                        return;
                    }
                    stack.Pop();
                    break;
            }
        }
        if (stack.Count == 0)
        {
            Console.WriteLine("Выражение задано верно");
        }

        else
        {
            Console.WriteLine("Неправильно задано выражение");
        }
    }
}
