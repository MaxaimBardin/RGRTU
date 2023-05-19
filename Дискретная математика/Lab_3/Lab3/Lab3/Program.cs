using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int N = 7; // Количество вершин

        int[][] matr = {
            new[] { 7, 3, 5, 0, 0, 7, 0, 0, 0, 0 },
            new[] { 0, 3, 0, 3, 0, 0, 12, 0, 0, 0 },
            new[] { 0, 0, 0, 3, 12, 0, 0, 4, 0, 0 },
            new[] { 0, 0, 5, 0, 0, 0, 0, 0, 7, 0 },
            new[] { 0, 0, 0, 0, 12, 7, 12, 0, 0, 3 },
            new[] { 0, 0, 0, 0, 0, 0, 0, 4, 7, 0 },
            new[] { 7, 0, 0, 0, 0, 0, 0, 0, 0, 3 }
        };

        List<int>[] graph = new List<int>[N];
        for (int i = 0; i < N; i++)
        {
            graph[i] = new List<int>();
        }

        // Построение графа на основе матрицы инцидентности
        for (int i = 0; i < N; i++)
        {
            for (int j = i + 1; j < N; j++)
            {
                if (matr[i][j] != 0)
                {
                    graph[i].Add(j);
                    graph[j].Add(i);
                }
            }
        }

        // Выбор случайной начальной вершины
        int startVertex = 0;

        List<Edge> minimumSpanningTree = GetMinimumSpanningTree(graph, startVertex, matr);

        int minDistance = GetMinimumDistance(minimumSpanningTree);
        
        Console.WriteLine("Кратчайшее остовное дерево:");
        foreach (Edge edge in minimumSpanningTree)
        {
            Console.WriteLine($"{edge.StartVertex} - {edge.EndVertex}");
        }

        Console.WriteLine($"Минимальное расстояние: {minDistance}");

        Console.ReadLine();
    }

    static List<Edge> GetMinimumSpanningTree(List<int>[] graph, int startVertex, int[][] matr)
    {
        int N = graph.Length;
        bool[] visited = new bool[N];

        List<Edge> minimumSpanningTree = new List<Edge>();
        PriorityQueue<Edge> priorityQueue = new PriorityQueue<Edge>();

        visited[startVertex] = true;

        // Начинаем с начальной вершины и добавляем все инцидентные ей ребра в очередь с приоритетом
        foreach (int neighbor in graph[startVertex])
        {
            priorityQueue.Enqueue(new Edge(startVertex, neighbor, matr[startVertex][neighbor]), matr[startVertex][neighbor]);
        }

        while (priorityQueue.Count > 0)
        {
            Edge edge = priorityQueue.Dequeue();

            int vertex = edge.EndVertex;

            if (visited[vertex])
            {
                continue;
            }

            visited[vertex] = true;
            minimumSpanningTree.Add(edge);

            foreach (int neighbor in graph[vertex])
            {
                if (!visited[neighbor])
                {
                    priorityQueue.Enqueue(new Edge(vertex, neighbor, matr[vertex][neighbor]), matr[vertex][neighbor]);
                }
            }
        }

        return minimumSpanningTree;
    }

    static int GetMinimumDistance(List<Edge> minimumSpanningTree)
    {
        int minDistance = 0;

        foreach (Edge edge in minimumSpanningTree)
        {
            minDistance += edge.Weight;
        }

        return minDistance;
    }
}

class Edge : IComparable<Edge>
{
    public int StartVertex { get; }
    public int EndVertex { get; }
    public int Weight { get; }

    public Edge(int startVertex, int endVertex, int weight)
    {
        StartVertex = startVertex;
        EndVertex = endVertex;
        Weight = weight;
    }

    public int CompareTo(Edge other)
    {
        return Weight.CompareTo(other.Weight);
    }
}

class PriorityQueue<T> where T : IComparable<T>
{
    private List<(T Item, int Priority)> heap;

    public int Count => heap.Count;

    public PriorityQueue()
    {
        heap = new List<(T, int)>();
    }

    public void Enqueue(T item, int priority)
    {
        heap.Add((item, priority));
        HeapifyUp(heap.Count - 1);
    }

    public T Dequeue()
    {
        (T Item, int Priority) firstItem = heap[0];
        int lastIndex = heap.Count - 1;
        heap[0] = heap[lastIndex];
        heap.RemoveAt(lastIndex);

        if (heap.Count > 1)
        {
            HeapifyDown(0);
        }

        return firstItem.Item;
    }

    private void HeapifyUp(int index)
    {
        int parentIndex = (index - 1) / 2;

        while (index > 0 && heap[index].Priority.CompareTo(heap[parentIndex].Priority) < 0)
        {
            Swap(index, parentIndex);
            index = parentIndex;
            parentIndex = (index - 1) / 2;
        }
    }

    private void HeapifyDown(int index)
    {
        int leftChildIndex = 2 * index + 1;
        int rightChildIndex = 2 * index + 2;

        while (leftChildIndex < heap.Count)
        {
            int smallestIndex = leftChildIndex;

            if (rightChildIndex < heap.Count && heap[rightChildIndex].Priority.CompareTo(heap[leftChildIndex].Priority) < 0)
            {
                smallestIndex = rightChildIndex;
            }

            if (heap[smallestIndex].Priority.CompareTo(heap[index].Priority) >= 0)
            {
                break;
            }

            Swap(index, smallestIndex);
            index = smallestIndex;
            leftChildIndex = 2 * index + 1;
            rightChildIndex = 2 * index + 2;
        }
    }

    private void Swap(int index1, int index2)
    {
        (T Item, int Priority) temp = heap[index1];
        heap[index1] = heap[index2];
        heap[index2] = temp;
    }
}
 /*   Определение размерности графа и создание пустого списка graph для представления графа в виде списков смежности.
    Построение графа на основе матрицы инцидентности. Для каждой вершины i и каждого ребра (i, j), где j > i и значение в матрице инцидентности не равно нулю, добавляем вершину j в список смежности вершины i и вершину i в список смежности вершины j.
    Выбор начальной вершины startVertex (в данном случае выбираем вершину с индексом 0).
    Создание списка minimumSpanningTree для хранения ребер кратчайшего остовного дерева и очереди с приоритетом priorityQueue для выбора ребра с наименьшим весом.
    Установка флага visited для начальной вершины в значение true.
    Для каждой вершины neighbor, смежной с startVertex, добавляем ребро (startVertex, neighbor, weight) в очередь с приоритетом, где weight - вес ребра.
    Пока очередь с приоритетом не пуста, извлекаем ребро с наименьшим весом из очереди.
    Если конечная вершина ребра уже посещена, пропускаем шаги 9-10 и переходим к следующей итерации.
    Устанавливаем флаг visited для конечной вершины ребра в значение true.
    Добавляем ребро в список minimumSpanningTree.
    Для каждой вершины neighbor, смежной с конечной вершиной ребра, добавляем ребро (vertex, neighbor, weight) в очередь с приоритетом, где vertex - конечная вершина ребра, а weight - вес ребра.
    Возвращаем список minimumSpanningTree как кратчайшее остовное дерево.
    Вычисляем минимальное расстояние, суммируя веса всех ребер в кратчайшем остовном дереве.
    Выводим кратчайшее остовное дерево и минимальное расстояние.

Для реализации очереди с приоритетом используется класс PriorityQueue, основанный на списке с корректным сохранением порядка элементов. Это позволяет эффективно извлекать элемент с наименьшим приоритетом.*/