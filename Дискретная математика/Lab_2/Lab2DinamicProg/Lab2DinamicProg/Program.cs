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
/*
 * В коде определены два метода: TopologicalSort и FindShortestDistance, а также метод Main, который является точкой входа в программу.

Метод TopologicalSort выполняет топологическую сортировку графа. Он принимает матрицу смежности adjacencyMatrix и количество вершин n в графе. Внутри метода создается список sortedVertices, который будет содержать отсортированные вершины графа. Также создается массив visited, который отслеживает посещение вершин.

Метод DFS (обход в глубину) реализует рекурсивный обход графа, начиная с вершины vertex. Он помечает текущую вершину visited[vertex] как посещенную и рекурсивно вызывает себя для всех непосещенных смежных вершин. Затем вершина vertex добавляется в начало списка sortedVertices, чтобы сохранить порядок топологической сортировки.

В методе TopologicalSort происходит инициализация массива visited и запуск обхода в глубину для всех вершин графа, которые еще не были посещены. После завершения обхода, список sortedVertices переворачивается, чтобы получить правильный порядок топологической сортировки. Отсортированный список вершин возвращается из метода.

Метод FindShortestDistance находит кратчайшее расстояние между исходной вершиной source и целевой вершиной destination с использованием алгоритма Дейкстры. Он принимает матрицу смежности adjacencyMatrix, отсортированный список вершин sortedVertices, исходную вершину source и целевую вершину destination. Внутри метода создается массив distances, который будет содержать кратчайшие расстояния от исходной вершины до всех остальных вершин.

Сначала массив distances инициализируется значением int.MaxValue (бесконечность), кроме исходной вершины, которая инициализируется значением 0. Затем происходит итерация по отсортированным вершинам. Если расстояние до текущей вершины vertex не является бесконечностью, происходит обновление кратчайшего расстояния до всех смежных вершин i, если новое расстояние меньше текущего значения distances[i]. Расстояние обновляется суммой текущего расстояния до вершины vertex и веса ребра между вершинами vertex и i (adjacencyMatrix[vertex, i]).

После завершения итерации по вершинам, метод возвращает кратчайшее расстояние от исходной вершины до целевой вершины (distances[destination]).

В методе Main задается количество вершин в графе n, матрица смежности adjacencyMatrix, исходная вершина source и целевая вершина destination. Затем вызывается метод TopologicalSort для получения отсортированных вершин и выводится результат. Затем вызывается метод FindShortestDistance для нахождения минимального расстояния между вершинами source и destination и выводится результат.
 */