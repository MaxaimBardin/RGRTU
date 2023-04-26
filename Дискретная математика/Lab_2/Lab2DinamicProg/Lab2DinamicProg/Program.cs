namespace Lab2DinamicProg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public static int[,] InputMatr(int[,] matr)
        {
            int[,] mat = new int[,] {{0, 8, 11, 0, 0, 0, 0 },
                                     { 0, 0, 10, 9, 7, 12, 0},
                                     { 0, 0, 0, 3, 0, 0, 5},
                                     {0, 0, 0, 0, 2, 0, 0},
                                     {0, 0, 0, 0, 0, 8, 4},
                                     { 0, 0, 0, 0, 0, 0, 6},
                                     { 0, 0, 0, 0, 0, 0, 0}};

            return matr;
        }

        public static int[,] OutputMatr(int[,] matr, int lenght, int hight)
        {
            for (var x = 1; x < lenght; x++)
            {
                for (var y = 1; y < hight)
            }

            return matr;
        }
    }
}