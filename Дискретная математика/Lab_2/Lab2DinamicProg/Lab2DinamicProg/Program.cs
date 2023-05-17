using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = 7; // Количество вершин в графе

        int[,] adjacencyMatrix = new int[,]
        {
            { 0, 0, 0, 0, 0, 0, 0 }, // Вершина 0
            { 3, 0, 0, 0, 0, 0, 0 }, // Вершина 1
            { 2, 4, 0, 0, 0, 0, 0 }, // Вершина 2
            { 0, 1, 0, 0, 0, 0, 0 }, // Вершина 3
            { 0, 0, 2, 5, 0, 0, 0 }, // Вершина 4
            { 0, 0, 0, 1, 0, 0, 0 }, // Вершина 5
            { 0, 0, 0, 0, 2, 1, 0 }  // Вершина 6
        };

        int source = 1; // Исходная вершина (a)
        int destination = 6; // Целевая вершина (b)

        List<int> sortedVertices = TopologicalSort(adjacencyMatrix, n);
        Console.WriteLine("Отсортированные вершины:");
        foreach (int vertex in sortedVertices)
        {
            Console.Write(vertex + " ");
        }

        Console.WriteLine();

        int shortestDistance = FindShortestDistance(adjacencyMatrix, sortedVertices, source, destination);
        Console.WriteLine("Минимальное расстояние между вершинами {0} и {1}: {2}", source, destination, shortestDistance);
    }

    static List<int> TopologicalSort(int[,] adjacencyMatrix, int n)
    {
        List<int> sortedVertices = new List<int>();
        bool[] visited = new bool[n];

        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                DFS(adjacencyMatrix, i, visited, sortedVertices);
            }
        }

        sortedVertices.Reverse();
        return sortedVertices;
    }

    static void DFS(int[,] adjacencyMatrix, int vertex, bool[] visited, List<int> sortedVertices)
    {
        visited[vertex] = true;

        for (int i = 0; i < adjacencyMatrix.GetLength(1); i++)
        {
            if (adjacencyMatrix[vertex, i] > 0 && !visited[i])
            {
                DFS(adjacencyMatrix, i, visited, sortedVertices);
            }
        }

        sortedVertices.Add(vertex);
    }

    static int FindShortestDistance(int[,] adjacencyMatrix, List<int> sortedVertices, int source, int destination)
    {
        int n = adjacencyMatrix.GetLength(0);
        int[] distances = new int[n];
        for (int i = 0; i < n; i++)
        {
            distances[i] = int.MaxValue;
        }

        distances[source] = 0;

        foreach (int vertex in sortedVertices)
        {
            if (distances[vertex] != int.MaxValue)
            {
                for (int i = 0; i < n; i++)
                {
                    if (adjacencyMatrix[vertex, i] > 0) // Проверяем, что есть ребро
                    {
                        int newDistance = distances[vertex] + adjacencyMatrix[vertex, i];
                        if (newDistance < distances[i])
                        {
                            distances[i] = newDistance;
                        }
                    }
                }
            }
        }

        return distances[destination];
    }
}
