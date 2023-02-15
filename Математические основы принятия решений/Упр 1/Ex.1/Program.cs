using System;
using System.Collections.Generic;

namespace Ex._1
{
    public class Simplex
    {
        private double[,] table;
        private int m, n;
        private List<int> basis;

        private Simplex(double[,] source)
        {
            m = source.GetLength(0);
            n = source.GetLength(1);
            table = new double[m, n + m - 1];
            basis = new List<int>();
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < table.GetLength(1); j++)
                {
                    if (j < n) table[i, j] = source[i, j];
                    else table[i, j] = 0;
                }

                if ((n + i) < table.GetLength(1))
                {
                    table[i, n + 1] = 1;
                    basis.Add(n + i);
                }
            }

            n = table.GetLength(1);
        }

        private double[,] Calculate(double[] result)
        {
            while (!IsItEnd())
            {
                var mainCol = FindMainCol();
                var mainRow = FindMainRow(mainCol);
                basis[mainRow] = mainCol;

                double[,] newTable = new double[m, n];

                for (int j = 0; j < n; j++)
                    newTable[mainRow, j] = table[mainRow, j] / table[mainRow, mainCol];

                for (int i = 0; i < m; i++)
                {
                    if (i == mainRow)
                        continue;

                    for (int j = 0; j < n; j++)
                        newTable[i, j] = table[i, j] - table[i, mainCol] * newTable[mainRow, j];
                }

                table = newTable;
            }

            for (var i = 0; i < result.Length; i++)
            {
                var k = basis.IndexOf(i + 1);
                if (k != -1)
                    result[i] = table[k, 0];
                else
                    result[i] = 0;
            }

            return table;
        }

        private bool IsItEnd()
        {
            bool flag = true;

            for (int j = 1; j < n; j++)
            {
                if (table[m - 1, j] < 0)
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }

        private int FindMainCol()
        {
            int mainCol = 1;

            for (int j = 2; j < n; j++)
                if (table[m - 1, j] < table[m - 1, mainCol])
                    mainCol = j;

            return mainCol;
        }

        private int FindMainRow(int mainCol)
        {
            int mainRow = 0;

            for (int i = 0; i < m - 1; i++)
                if (table[i, mainCol] > 0)
                {
                    mainRow = i;
                    break;
                }

            for (int i = mainRow + 1; i < m - 1; i++)
                if ((table[i, mainCol] > 0) &&
                    ((table[i, 0] / table[i, mainCol]) < (table[mainRow, 0] / table[mainRow, mainCol])))
                    mainRow = i;

            return mainRow;
        }

        class Program
        {
            static void Main()
            {
                double[,] table =
                {
                    {13, 2, 5, 2},
                    {18, 7, 1, 2},
                    {0, -4, -1, -6}
                };

                double[] result = new double[3];
                Simplex s = new Simplex(table);
                double[,] tableResult = s.Calculate(result);

                Console.WriteLine("Решенная симплекс-таблица:");
                for (int i = 0; i < tableResult.GetLength(0); i++)
                {
                    for (int j = 0; j < tableResult.GetLength(1); j++)
                        Console.Write(tableResult[i, j] + " ");
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine("Решение:");
                Console.WriteLine("X[1] = " + result[0]);
                Console.WriteLine("X[2] = " + result[1]);
                Console.WriteLine("X[3] = " + result[2]);
                Console.ReadLine();
            }

        }
    }
}