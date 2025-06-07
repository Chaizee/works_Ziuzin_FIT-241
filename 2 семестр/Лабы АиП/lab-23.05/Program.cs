class Program
{
    static unsafe void Main()
    {
        int* freq = stackalloc int[256];

        for (int i = 0; i < 256; i++)
            freq[i] = 0;

        Console.WriteLine("Введите строки. Чтобы закончить, введите 'stop'.");

        string input;
        while ((input = Console.ReadLine()) != "stop")
        {
            fixed (char* ptr = input)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    char c = *(ptr + i);
                    if (c < 256)
                        freq[(byte)c]++;
                }
            }
        }

        int minCount = int.MaxValue;
        int maxCount = int.MinValue;

        for (int i = 0; i < 256; i++)
        {
            if (freq[i] == 0)
                continue;

            if (freq[i] < minCount)
                minCount = freq[i];
            if (freq[i] > maxCount)
                maxCount = freq[i];
        }

        List<char> minChars = new List<char>();
        List<char> maxChars = new List<char>();

        for (int i = 0; i < 256; i++)
        {
            if (freq[i] == 0)
                continue;

            if (freq[i] == minCount)
                minChars.Add((char)i);
            if (freq[i] == maxCount)
                maxChars.Add((char)i);
        }

        Console.WriteLine($"\nСимвол(ы), который(е) встречался(ись) реже всего ({minCount} раз):");
        for (int i = 0; i < minChars.Count; i++)
            Console.Write(minChars[i] + " ");

        Console.WriteLine($"\n\nСимвол(ы), который(е) встречался(ись) чаще всего ({maxCount} раз):");
        for (int i = 0; i < maxChars.Count; i++)
            Console.Write(maxChars[i] + " ");
    }
}