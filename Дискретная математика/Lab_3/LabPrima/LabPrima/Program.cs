using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 7;

            int[,] C = new int[n, n]
            {
                {-8,-11,  0, 0, 0,  0,  0,  0,  0,  0,  0,0},
                {8,   0,-10,-9,-7,-12,  0,  0,  0,  0,  0,0},
                {0,  11, 10, 0, 0,  0, -3,  0,  0,  0,  0,0},
                {0,   0,  0, 9, 0,  0,  3, -2,  0,  0,  0,0},
                {0,   0,  0, 0, 7,  0,  0,  2, -8, -4,  0,0},
                {0,   0,  0, 0, 0,-12,  0,  0,  8,  4, -6,0},
                {0,   0,  0, 0, 0,  0,  0,  0,  0,  0,  6,0},
            };
            
                                        { {0, 8, 11, 0, 0,  0, 0 },
                                       {0, 0, 10, 9, 7, 12, 0 },
                                       {0, 0,  0, 3, 0,  0, 5 },
                                       {0, 0,  0, 0, 2,  0, 0 },
                                       {0, 0,  0, 0, 0,  8, 4 },
                                       {0, 0,  0, 0, 0,  0, 6 },
                                        {0, 0,  0, 0, 0,  0, 0}};

            Console.WriteLine("Исходная матрица:"); array.Print(C);
            Console.WriteLine();

            int[,] Cp = new int[n, n]; 
            int[] b = new int[n];      
            int minW = Int32.MaxValue; 
            int minI = 3;              
            int minJ = 4;
            int L = 0;                 

            b[0] = 1;
            while (b.Contains(0))
            {
                for (int i = 0; i < n; i++)
                {
                    if (b[i] == 1)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if ((C[i, j] != 0) && (b[j] == 0))
                            {
                                if (C[i, j] < minW)
                                {
                                    minI = i;
                                    minJ = j;
                                    minW = C[i, j];
                                }
                            }
                        }
                    }
                }

                b[minJ] = 1;
                L += minW;
                Cp[minI, minJ] = minW; Cp[minJ, minI] = minW;
                minW = Int32.MaxValue;
            }

            Console.WriteLine("Результат формирования дерева:"); array.Print(Cp);
            Console.WriteLine("Длина порожденного дерева:" + L.ToString());
        }
    }

    public class array
    {
        public static void Print<T>(T[,] array)
        {
            Console.Write("    ");
            for (int j = 0; j < array.GetLength(1); j++)
                Console.Write("  x" + j);
            Console.WriteLine();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write("x" + i + "|");
                for (int j = 0; j < array.GetLength(1); j++)
                    Console.Write(String.Format("{0, 4}", array[i, j]));
                Console.WriteLine();
            }
        }
    }
}

