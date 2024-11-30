using System.IO;

class guessthenumber
{
    
    public static void Main(string[] args)
    {        
        
        string[] lines = File.ReadAllLines("C:\\Users\\Дмитрий\\Desktop\\олимпиады\\Отгадай число\\Отгадай число\\input_s1_12.txt");
        int n= int.Parse(lines[0]);
        string[] actions = new string[n];

        for (int i = 0; i < n; i++)
        {
            actions[i] = lines[i+1];
        }
        int result = int.Parse(lines[n+1]);

        int x = FindX(n, actions, result);
        Console.WriteLine(x);

        

        
    }
    static int FindX(int n, string[] actions, int result)
    {
        int coeff = 1; //коэфицент перед X
        int constant = 0; //свободный член

        foreach (string action in actions)
        {
            string[] parts = action.Split(' ');
            char opers = parts[0][0];
            string value = parts[1];

            if (value == "x")
            {
                if (opers == '+')
                {

                    coeff += 1;
                }
                else if (opers == '-')
                {
                    coeff -= 1;
                }
            }
            else
            {
                int intValue = int.Parse(value);
                if (opers == '+')
                {
                    constant += intValue;

                }
                else if (opers == '-')
                {
                    constant -= intValue;
                }
                else if (opers == '*')
                {
                    constant *= intValue;
                    coeff *= intValue;
                }
            }
        }
        return (result - constant) / coeff;
    }
}