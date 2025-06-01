using System;
using System.Collections.Generic;

class Program
{
    static bool BFS(int V, int[,] residualGraph, int s, int t, int[] parent)
    {
        bool[] visited = new bool[V];
        Queue<int> queue = new Queue<int>();

        visited[s] = true;
        queue.Enqueue(s);

        while (queue.Count > 0)
        {
            int u = queue.Dequeue();

            for (int v = 0; v < V; v++)
            {
                if (!visited[v] && residualGraph[u, v] > 0)
                {
                    visited[v] = true;
                    parent[v] = u;
                    queue.Enqueue(v);

                    if (v == t)
                        return true;
                }
            }
        }

        return false;
    }

    static void Main()
    {
        int V = 6;
        int[,] graph = {
            { 0, 12, 65,  0,  41,  0 }, 
            { 0,  0, 0, 17,  33, 38 }, 
            { 0,  0,  0,  0, 11,  16 }, 
            { 0,  0,  34,  0,  0, 19 }, 
            { 0,  0,  0,  0,  0,  50 }, 
            { 0,  0,  0,  0,  0,  0 }  
        };

        int s = 0;
        int t = 5;
        
        int[,] residualGraph = new int[V, V];
        for (int u = 0; u < V; u++)
            for (int v = 0; v < V; v++)
                residualGraph[u, v] = graph[u, v];

        int[] parent = new int[V];
        int max_flow = 0;

        while (BFS(V, residualGraph, s, t, parent))
        {
            int path_flow = int.MaxValue;
            for (int v = t; v != s; v = parent[v])
            {
                int u = parent[v];
                path_flow = Math.Min(path_flow, residualGraph[u, v]);
            }

            for (int v = t; v != s; v = parent[v])
            {
                int u = parent[v];
                residualGraph[u, v] -= path_flow;
                residualGraph[v, u] += path_flow;
            }

            max_flow += path_flow;
        }

        Console.WriteLine("Максимальный поток: " + max_flow);
    }
}