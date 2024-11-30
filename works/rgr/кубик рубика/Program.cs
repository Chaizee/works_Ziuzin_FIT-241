using System.ComponentModel;
using System.Globalization;
class Rubik
{

    public static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("C:\\Users\\Дмитрий\\Desktop\\олимпиады\\Кубик рубика\\Кубик Рубика\\input_s1_01.txt");
        string[] firststr = lines[0].Split(' ');
        int n = int.Parse(firststr[0]);
        int m = int.Parse(firststr[1]);
        string[] positionstr = lines[1].Split(' ');
        int[] position = new int[3];
        for (int i = 0; i < 3; i++)
        {
            position[i] = int.Parse(positionstr[i]);
        }
        for (int i = 0; i < m; i++)
        {
            string[] rotations = lines[i+2].Split(' ');
            string Axis = rotations[0];
            int row = int.Parse(rotations[1]);
            int direction = int.Parse(rotations[2]);

            Rotate(n, position, Axis, row, direction);
        }
        Console.WriteLine(position[0] + " " + position[1] + " " + position[2]);       
    }

    static void Rotate(int n, int[] position, string axis, int row, int direction)
    {
        if (axis == "X" && position[0] == row)
        {
            RotateAxis(n, position, 1, 2, direction);
        }
        if (axis == "Y" && position[1] == row)
        {
            RotateAxis(n, position, 0, 2, direction);
        }
        if (axis == "Z" && position[2] == row)
        {
            RotateAxis(n, position, 0, 1, direction);
        }
    }

    static void RotateAxis(int n, int[] position, int idx1, int idx2, int direction)
    {
        if (direction == -1)
        {
            int temp = position[idx1];
            position[idx1] = n + 1 - position[idx2];
            position[idx2] = temp;
        }
        else
        {
            int temp = position[idx2];
            position[idx2] = n + 1 - position[idx1];
            position[idx1] = temp;
        }
        position[idx1] = (position[idx1] - 1 + n) % n + 1;
        position[idx2] = (position[idx2] - 1 + n) % n + 1;
    }
}   