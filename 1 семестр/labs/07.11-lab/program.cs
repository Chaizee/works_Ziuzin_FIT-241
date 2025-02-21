//отформатировать строку чтобы было по одному пробелу
class program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите строку");
        string n = Console.ReadLine();
        string[] words = n.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string s in words)
        {
            Console.Write(s+" ");
        }
    }
}

//необходимо в строке, состоящей из слов, между которыми по 1 пробелу, выдать все палиндромы
class program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите строку");
        string n = Console.ReadLine();
        string[] words = n.Split(new char[] { ' ' });
        
        for (int i = 0; i < words.Length; i++)
        {
            bool exist = true;
            for (int j = 0; j < (words[i].Length/2); j++)
            {
                if (words[i][j] != words[i][words[i].Length -1- j])
                {
                    exist = false;
                    break;
                }  
            }
            if (exist)
            {
                Console.WriteLine(words[i]);
            }
        }
    }
}

//Определить является ли строка палиндромом
using System.Security.Cryptography.X509Certificates;

class program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите строку");
        string n = Console.ReadLine();
        string[] words = n.Split(new char[] { ' ' });
        string s = words[0];
        for (int i = 1; i < words.Length; i++) 
        {
            s+= words[i];
        }

        bool exist = true;
        for (int i = 0; i < s.Length/2; i++)
        {
            
            if (s[i] != s[s.Length - 1 - i])
            {
                exist = false;
                break;
            }
            
        }
        if (exist)
        {
            Console.WriteLine("строка является палиндромом");
        }
        else
        {
            Console.WriteLine("строка не является палндромом");
        }
    }
}

//дано n строк, выдать только те строки, в которых кол-во гласных букв больше, чем кол-во согласных

using System.Security.Cryptography.X509Certificates;

class program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введмте количество строк");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите строки");
        for (int i = 0; i < n; i++)
        {
            int gl = 0; int sogl = 0;
            string s = Console.ReadLine();
            const string glasn = "УуЕеЫыАаОоЭэЯяИиЮю";
            const string soglasn = "ЙйЦцКкНнГгШшЩщЗзХхЪъЖжДдЛлРрПпВвФфЧчСсМмТтЬьБб";
            for (int j = 0; j < s.Length; j++)
            {
                for (int k = 0; k < glasn.Length; k++)
                {
                    if (s[j] == glasn[k])
                    {
                        gl++;
                    }
                }
                for (int k = 0; k < soglasn.Length; k++)
                {
                    if (s[j] == soglasn[k])
                    {
                        sogl++;
                    }
                }
            }
            if (gl == sogl)
            {
                Console.WriteLine($"В строке \"{s}\" одинаковое количество согласных и гласных");
            }
            else
            {
                Console.WriteLine("В введенной строке количество гласных и согласных не одинаково");
            }
        }   
    }
}

