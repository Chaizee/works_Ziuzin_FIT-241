//Определить количество строк, в которых присутствуют сочетания a*b, где * - любой символ.
class lab
{
    public static void Main(string[] args)
    {
       string n = Console.ReadLine();
       int Count = 0;
       while (n != "")
       {
            n = n.ToLower();
            for (int i = 0; i < n.Length-2; i++)
            {
                if (n[i] == 'a' && n[i+2] == 'b')
                {
                    Count++;
                }
            }
            n = Console.ReadLine();
        }
       Console.WriteLine(Count);
    }
}

//Определить максимальную длину подстроки в каждой строе, состоящей из сочетания abc
class lab
{
    public static void Main(string[] args)
    {
       string n = Console.ReadLine();
       int outmax = 0;       
       while (n != "")
       {           
            n = n.ToLower();
            string temp = "a";
            int maxlen = 0;

            while (n.Contains(temp))
            {
                maxlen++;
                int len = temp.Length+1;
                if (len % 3 ==1)
                {
                    temp += "a";
                }
                else if (len % 3 == 2)
                {
                    temp += "b";
                }
                else { temp += "c";}
            }
            outmax = Math.Max(outmax,maxlen);
            Console.WriteLine(outmax);
            n = Console.ReadLine();
            temp = "a";
            outmax = 0;
            maxlen = 0;
        }       
    }
}
