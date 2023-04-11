

using System;

namespace lab1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите количество вершин");
            var countVersh = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество ребер");
            var countRebr = int.Parse(Console.ReadLine());
            int[,] MatrixInc = new int[countRebr,countVersh];
            int[,] MatrixSmegnost = new int[countRebr, countRebr];
            InputInc(countRebr,countVersh,MatrixInc);
        }
        
        public static void InputInc(int countRebr,int countVersh, int[,]MatrixInc)
        {
            Console.WriteLine("Введите матрицу инцидентности");
            for (var i = 0; i < countRebr; i++)
            {
                for (int j = 0; j < countVersh; j++)
                {
                    MatrixInc[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("Вывод матрицы инцидентности");
            for (var i = 0; i < countRebr; i++)
            {
                for (int j = 0; j < countVersh; j++)
                {
                    Console.Write(MatrixInc[i,j]+ "  ");
                }
                Console.WriteLine();
            }
        }

        public static void ToSmegnost(int countRebr, int countVersh, int[,]MatrixSmegnost)
        {
            for (var i = 0; i < countRebr; i++)
            {
                for (int j = 0; j < countVersh; j++)
                {
                    if 
                }
            } 
        }
    }    
}