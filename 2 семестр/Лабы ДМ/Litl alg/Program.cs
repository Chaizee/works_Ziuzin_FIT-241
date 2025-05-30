using System;
using System.Collections.Generic;

class LittleAlgorithm
{
    private int N;
    private int[,] matrix;
    private int[] path;
    private int[] bestPath;
    private int bestCost;

    public void Solve(int[,] inputMatrix)
    {
        N = inputMatrix.GetLength(0);
        matrix = new int[N, N];

        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
                matrix[i, j] = inputMatrix[i, j];

        path = new int[N + 1];
        bestPath = new int[N + 1];
        bestCost = int.MaxValue;

        BranchAndBound(0, new List<int> { 0 }, 0);

        Console.WriteLine("Стоимость: " + bestCost);
        Console.Write("Путь: ");
        for (int i = 0; i <= N; i++)
            Console.Write(bestPath[i] + " ");
        Console.WriteLine();
    }

    private void BranchAndBound(int level, List<int> currentPath, int cost)
    {
        if (level == N - 1)
        {
            int lastCity = currentPath[level];
            int firstCity = currentPath[0];
            if (matrix[lastCity, firstCity] == 0) return;

            cost += matrix[lastCity, firstCity];
            currentPath.Add(firstCity);

            if (cost < bestCost)
            {
                bestCost = cost;
                for (int i = 0; i <= N; i++)
                    bestPath[i] = currentPath[i];
            }

            currentPath.RemoveAt(currentPath.Count - 1);
            return;
        }

        int nextCity = level + 1;
        for (int city = 1; city < N; city++)
        {
            if (currentPath.Contains(city)) continue;

            int currentCity = currentPath[level];
            if (matrix[currentCity, city] == 0) continue;

            currentPath.Add(city);
            cost += matrix[currentCity, city];

            BranchAndBound(nextCity, currentPath, cost);

            cost -= matrix[currentCity, city];
            currentPath.RemoveAt(currentPath.Count - 1);
        }
    }
}

class Program
{
    static void Main()
    {
        int[,] distMatrix = {
            { 0, 20, 18, 25, 30 },
            { 20, 0, 16, 22, 15 },
            { 18, 16, 0, 12, 18 },
            { 25, 22, 12, 0, 10 },
            { 30, 15, 18, 10, 0 }
        };

        var little = new LittleAlgorithm();
        little.Solve(distMatrix);
    }
}