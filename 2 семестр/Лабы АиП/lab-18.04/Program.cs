class Program
{
    static void Main(string[] args)
    {
        List<string> list = File.ReadAllLines("input.txt").ToList();

        using (StreamWriter writer = new StreamWriter("output.txt"))
        {


            foreach (string line in list)
            {
                string tempString = null;

                for (int i = 0; i < line.Length; i++)
                {

                    if (char.IsDigit(line[i]))
                    {
                        tempString += line[i];
                    }

                    if (!char.IsDigit(line[i]) && tempString != null)
                    {
                        if ((Convert.ToInt32(tempString)) % 2 == 0)
                        {
                            writer.WriteLine(line);
                            break;
                        }
                        tempString = null;
                    }
                }
            }
        }
    }
}