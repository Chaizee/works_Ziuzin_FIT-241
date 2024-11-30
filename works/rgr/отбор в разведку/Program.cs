class intelligence
{
    public static void Main(string[] args)
    {

        int n = int.Parse(File.ReadAllText($"C:\\Users\\Дмитрий\\Desktop\\олимпиады\\Отбор в разведку\\Отбор в разведку\\input_s1_01.txt"));
        
        if ((n - Math.Pow(2, Math.Floor(Math.Log2(n)))) > ((((Math.Pow(2, ((Math.Floor(Math.Log2(n))) + 1)) - (Math.Pow(2, (Math.Floor(Math.Log2(n)))))) / 2)))){ Console.WriteLine(Math.Pow(2, ((Math.Floor(Math.Log2(n))) + 1)) - n);}
        else { Console.WriteLine(n - Math.Pow(2, ((Math.Floor(Math.Log2(n)))))); }
        
    }
}