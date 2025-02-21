using System.Globalization;
class Milk
{
    public static void Main()
    {
        string[] lines = File.ReadAllLines("C:\\Users\\Дмитрий\\Desktop\\олимпиады\\Упаковки молока\\Упаковки молока\\input2.txt");
        int n = int.Parse(lines[0]);
        double minPrice = int.MaxValue;
        int minind = 0;
        for (int i = 0; i < n; i++)

        {
            string[] cifr = lines[i + 1].Split(' ');
            int X1 = int.Parse(cifr[0]);
            int Y1 = int.Parse(cifr[1]);
            int Z1 = int.Parse(cifr[2]);
            int X2 = int.Parse(cifr[3]);
            int Y2 = int.Parse(cifr[4]);
            int Z2 = int.Parse(cifr[5]);
            double C1 = double.Parse(cifr[6], CultureInfo.InvariantCulture);
            double C2 = double.Parse(cifr[7], CultureInfo.InvariantCulture);

            float V1 = X1 * Y1 * Z1;
            float V2 = X2 * Y2 * Z2;

            float S1 = 2 * (X1 * Y1 + Y1 * Z1 + Z1 * X1);
            float S2 = 2 * (X2 * Y2 + Y2 * Z2 + Z2 * X2);

            double k = V1 / V2;
            double C2x = C2 * k;
            double S2x = S2 * k;

            double price = (C1 - ((S1 / (S2x - S1)) * (C2x - C1))) * 1000 / V1;
            double price1 = Math.Round(price, 2);
            if (price1 < minPrice)
            {
                minPrice = price1;
                minind = i;
            }
        }
        Console.WriteLine($"{minind + 1} {minPrice:F2}");



    }
}