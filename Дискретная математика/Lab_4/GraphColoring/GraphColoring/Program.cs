using System;
using System.Collections.Generic;

class GraphColoring
{
    static void Main()
    {
        int[,] adjacencyMatrix = 
        {
            {8, 0, 0, 0, 0, 14, 8},
            {13, 0, 0, 7, 0, 0, 20},
            {7, 0, 7, 0, 6, 1, 0},
            {0, 0, 0, 6, 0, 5, 0},
            {1, 14, 0, 1, 5, 0, 10},
            {0, 8, 20, 0, 0, 10, 0}
        };

        int numVertices = adjacencyMatrix.GetLength(0);

        int[] colors = ColorGraph(adjacencyMatrix, numVertices);

        Console.WriteLine("Раскраска графа:");
        for (int i = 0; i < numVertices; i++)
        {
            Console.WriteLine($"Вершина {i + 1}: Цвет {colors[i]}");
        }
    }

    static int[] ColorGraph(int[,] adjacencyMatrix, int numVertices)
    {
        int[] colors = new int[numVertices];

        for (int i = 0; i < numVertices; i++)
        {
            // Инициализируем цвет текущей вершины
            colors[i] = 0;

            // Создаем список доступных цветов
            List<int> availableColors = new List<int>();

            for (int j = 1; j <= numVertices; j++)
            {
                availableColors.Add(j);
            }

            // Проверяем соседние вершины и удаляем их цвет из списка доступных цветов
            for (int j = 0; j < numVertices; j++)
            {
                if (adjacencyMatrix[i, j] > 0 && colors[j] != 0)
                {
                    availableColors.Remove(colors[j]);
                }
            }

            // Устанавливаем минимально доступный цвет для текущей вершины
            if (availableColors.Count > 0)
            {
                colors[i] = availableColors[0];
            }
        }

        return colors;
    }
}
/*
 *     Функция ColorGraph принимает матрицу смежности adjacencyMatrix и количество вершин numVertices в качестве параметров.
    Создается массив colors, который будет содержать цвета для каждой вершины графа.
    Для каждой вершины графа:
        Инициализируется цвет текущей вершины в массиве colors как 0.
        Создается список availableColors, содержащий все доступные цвета (нумерация цветов начинается с 1).
        Для каждой соседней вершины текущей вершины:
            Если соседняя вершина уже имеет цвет (не равен 0), этот цвет удаляется из списка availableColors.
        Если в списке availableColors остались доступные цвета:
            Назначается минимальный доступный цвет текущей вершине из списка availableColors.
        Раскрашенная вершина сохраняется в массиве colors.
    В конце функция ColorGraph возвращает массив colors, содержащий цвета для каждой вершины графа.
 */