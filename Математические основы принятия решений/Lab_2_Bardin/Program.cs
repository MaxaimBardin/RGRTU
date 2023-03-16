using System;
using System.Drawing;

public class Program
{
    public static void ShowArray(int[,] myArr) // Отображение массива в таблице
    {
        for (int i = 0; i < 8; i++)
        {
            Console.WriteLine();
            for (int j = 0; j < 7; j++)
            {
                Console.Write(myArr[i, j] + " ");

            }
        }
    }
    public static void GenArray(int[,] myArr) // Генерация массива случайных значений
    {
        Random rand = new Random();
        int k = 0;
        int t;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                t = rand.Next(1, 10);
                if (t > k)
                    myArr[i, j] = t - k;
                else myArr[i, j] = 0;
            }
            k = k + 1;
        }
    }

    public static bool CompareArray(int[] arr1, int[] arr2) // Сравнение одномерных массивов
    {
        int count = 0;
        for (int n = 0; n < arr1.Length; n++)
        {
            if (arr1[n] >= arr2[n])
                count += 1;
        }
        if (count == arr1.Length)
            return true;
        else return false;
    }
    public static void FillArray(int[,] myArr, int[] arr3, int size, int arr_row) // Заполнение одномерного массива для сравнения
    {
        for (int i = 0; i < size; i++)
        {
            arr3[i] = myArr[arr_row, i];
        }
    }
    public static void ZeroArray(int[,] myArr, int size_row, int arr_row) // Заполнение одномерного массива в (удаление массива)
    {
        for (int i = 0; i < size_row; i++)
        {
            myArr[arr_row, i] = 0;
        }
    }
    public static void BestResult(int[,] myArr) // Вывод лучших результатов
    {
        for (int i = 0; i < 8; i++)
        {
            if (myArr[i, 0] != 0)
            {
                if (i == 8)
                    Console.WriteLine("Сигнал N " + Convert.ToString(i + 1));
                else Console.WriteLine("Сигнал N " + Convert.ToString(i + 1) + "\n");
            }
        }
    }
    public static void Main()
    {
        int[,] myArr = new int[8, 7]; // Текущее множество парето-оптимальных векторов

        GenArray(myArr);
        Console.WriteLine("Исходный массив:");
        ShowArray(myArr);
        // Шаг 1
        int i = 0;
        int j = 1;
        int N = 7;
        Boolean flag = true;
        do
        {
            int[] a = new int[7];
            int[] b = new int[7];
            FillArray(myArr, a, 7, i);
            FillArray(myArr, b, 7, j);
            if (CompareArray(a, b)) // ar 2
            {
                ZeroArray(myArr, 7, j); //Шаг 3
                if (j < N) // Шаг 4
                {
                    j = j + 1;
                }
                else
                {

                    if (i < (N - 1)) // Шаг 7
                    {
                        i = i + 1;
                        j = i + 1;
                    }

                    else flag = false; // Конец вычислений
                }
            }
            else
            {
                int[] c = new int[7];
                int[] d = new int[7];
                FillArray(myArr, c, 7, j);
                FillArray(myArr, d, 7, i);
                if (CompareArray(c, d)) // Шаг 5
                {
                    ZeroArray(myArr, 7, i); // Шаг 6
                    if (i < (N - 1)) // Шаг 7
                    {
                        i = i + 1;
                        j = i + 1;
                    }
                    else flag = false; // Конец вычислений
                }
                else
                {
                    if (j < N) // ar 4
                    {
                        j = j + 1;
                    }
                    else
                    {

                        if (i < (N - 1)) // Шаг 7
                        {
                            i = 1 + 1;
                            j = i + 1;
                        }


                        else flag = false; // Конец вычислений
                    }
                }
            }

        } // конец do
        while (flag);
        Console.WriteLine();
        Console.WriteLine("Результирующий массив:");
        ShowArray(myArr);
        Console.WriteLine();
        BestResult(myArr);
    }
}
