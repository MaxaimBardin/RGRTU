using System;
using System.Collections.Generic;

public class Program
{
    
        private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;
 
            for (int i = 0; i < verticesCount; ++i)
            {
                if (shortestPathTreeSet[i] == false && distance[i] <= min)
                {
                    min = distance[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }

        public static void PrintGraph(int[,] graph,int verticesCount)
        {
            Console.WriteLine("Граф: ");
            for (var i = 0; i < verticesCount; i++)
            {
                for (var j = 0; j < verticesCount; j++)
                {
                    Console.Write(graph[i,j] + "  ");
                }
                Console.WriteLine();
            }
        }
 
        private static void PrintDistance(int[] distance, int verticesCount,int end)
        {
            Console.WriteLine("Вершина    Расстояние от вершины");
 
            for (int i = 0; i < verticesCount; ++i)
                Console.WriteLine("{0}\t  {1}", i, distance[i]);
            Console.Write("Минимальное рассояние до вершины {0} = {1}",end,distance[end]);
        }
 
        public static void DijkstraAlgo(int[,] graph, int source, int verticesCount,int end)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];
 
            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }
 
            distance[source] = 0;
 
            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;
 
                for (int v = 0; v < verticesCount; ++v)
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                        distance[v] = distance[u] + graph[u, v];
            }
            
            PrintDistance(distance, verticesCount, end);
        }
 
        static void Main(string[] args)
        {
            int[,] graph =  {
                         { 0, 6, 0, 0, 0, 0, 0, 9, 0 },
                         { 6, 0, 9, 0, 0, 0, 0, 6, 0 },
                         { 0, 9, 0, 5, 0, 6, 0, 0, 2 },
                         { 0, 0, 5, 0, 9, 7, 0, 0, 0 },
                         { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                         { 0, 0, 6, 0, 10, 0, 2, 0, 0 },
                         { 0, 0, 0, 7, 0, 2, 0, 1, 6 },
                         { 9, 6, 0, 0, 0, 0, 1, 0, 5 },
                         { 0, 0, 2, 0, 0, 0, 6, 5, 0 }
                            };
            PrintGraph(graph, 9);
            
            Console.WriteLine("Какая вершина будет начальной?");
            int source = int.Parse(Console.ReadLine());
            Console.WriteLine("До какой вершины будем идти?");
            int end = int.Parse(Console.ReadLine());
            DijkstraAlgo(graph, source, 9,end);
            Console.ReadKey();
        }
}
