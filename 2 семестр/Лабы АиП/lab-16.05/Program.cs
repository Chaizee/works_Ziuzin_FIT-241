class Program
{
    unsafe static void Main()
    {
        int[] mus = new int[5];

        Console.WriteLine("Введите элементы массива");
        for (int i = 0; i < 5; i++)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            mus[i] = n;
        }

        fixed (int* ptr = mus)
        {
            int* p = ptr;
            int Count = 0;

            for (int i = 0; i < 5; i++)
            {
                if (*p % 2 == 0)
                {
                    ++Count;
                }
                p++;
            }
            Console.WriteLine(Count);
        }
        
    }
}