class Potion
{
    public static void Main(string[] args)
    {
        for (int l = 1; l <= 10; l++)
        {
            string[] lines = File.ReadAllLines($"C:\\Users\\Дмитрий\\Desktop\\олимпиады\\Зельеварение\\Зельеварение\\input{l}.txt");
            string[] output = File.ReadAllLines($"C:\\Users\\Дмитрий\\Desktop\\олимпиады\\Зельеварение\\Зельеварение\\output{l}.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                int count = 0;
                string[] zakl = lines[i].Split(' ');
                lines[i] = lines[i].Remove(0);
                for (int j = 1; j < zakl.Length; j++)
                {
                    int num;
                    bool isNumber = int.TryParse(zakl[j], out num);
                    if (isNumber)
                    {
                        string temp = lines[num - 1];

                        for (int k = 2; k < zakl.Length; k++)
                        {
                            bool isNumber2 = int.TryParse(zakl[j], out int num2);
                            if (num2 == null && zakl[k] != null)
                            {
                                temp += $"{zakl[k]}";
                            }
                        }
                        lines[i] += temp;
                    }
                    else if (isNumber == false)
                    {
                        lines[i] += $"{zakl[j]}";
                    }
                }
                if (zakl[0] == "DUST")
                {
                    lines[i] = "DT" + lines[i] + "TD";
                }
                if (zakl[0] == "WATER")
                {
                    lines[i] = "WT" + lines[i] + "TW";
                }
                if (zakl[0] == "MIX")
                {
                    lines[i] = "MX" + lines[i] + "XM";
                }
                if (zakl[0] == "FIRE")
                {
                    lines[i] = "FR" + lines[i] + "RF";
                }
            }
            if (lines[lines.Length - 1] == output[0])
            {
                Console.WriteLine("true");
            }
        }
    }    
}