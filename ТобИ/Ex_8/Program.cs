namespace Ex_8
{
    internal class Program
    {
        public static double opred2(double a11, double a12, double a21, double a22)
        {
            return a11 * a22 - a12 * a21;
        }
        static void Main(string[] args)
        {
            double[] x = new double[40]; // исходные данные ось X
            double[] y = new double[40]; // исходные данные ось Y
            double[] z = new double[40]; // результаты экстраполяции ось Y
            double[] eps = new double[40]; // погрешность экстраполяции
            double[] otkl = new double[40]; // отклонения от уровня сглаженного ряда
            double[] s = new double[12]; // коэффициенты сезонности
            double max_eps = 0.0; // Максимальная погрешность
            double otkl_sr;
            double y_sr;
            y[0] = 131.4;
            y[1] = 117.4;
            y[2] = 121.4;
            y[3] = 120.1;
            y[4] = 129.6;
            y[5] = 130.9;
            y[6] = 130.8;
            y[7] = 130.3;
            y[8] = 134.4;
            y[9] = 155.2;
            y[10] = 167.4;
            y[11] = 168.3;
            y[12] = 188.8;
            y[13] = 179.0;
            y[14] = 181.8;
            y[15] = 175.1;
            y[16] = 196.2;
            y[17] = 206.3;
            y[18] = 217.4;
            y[19] = 219.2;
            y[20] = 217.2;
            y[21] = 213.8;
            y[22] = 223.0;
            y[23] = 220.3;
            y[24] = 267.6;
            y[25] = 233.9;
            y[26] = 243.0;
            y[27] = 252.5;
            y[28] = 280.1;
            y[29] = 290.3;
            y[30] = 322.8;
            y[31] = 335.0;
            y[32] = 342.6;
            y[33] = 352.0;
            y[34] = 350.7;
            y[35] = 359.3;

            otkl_sr = 0.0;
            y_sr = 0.0;
            for (int i = 0; i < 30; i++)
            {
                x[i] = i + 1;
                if (i > 5)
                {
                    z[i] = (0.5 * y[i - 6] + y[i - 5] + y[i - 4] + y[i - 3] + y[i - 2] + y[i - 1] + y[i] + y[i + 1] + y[i + 2] + y[i + 3] +
                        +y[i + 4] + y[i + 5] + 0.5 * y[i + 6]) / 12.0;
                    eps[i] = Math.Abs(z[i] - y[i]);
                    if (eps[i] > max_eps)
                        max_eps = eps[i];
                    otkl[i] = y[i] - z[i];  // Расчет отклонения от уровня сглаженного ряда
                    otkl_sr += otkl[i];
                    y_sr += y[i];
                }
                Console.WriteLine("x = " + x[i] + " y = " + y[i] + " z = " + z[i] + " Погрешность = " + eps[i] + " Отклонение = " + otkl[i]);
            }
            otkl_sr = otkl_sr / 24.0;
            y_sr = y_sr / 24.0;
            Console.WriteLine("Ср. откл. = " + otkl_sr);
            // коэффициенты сезонности
            s[0] = z[6] + z[18] - y[6] - y[18];
            Console.WriteLine("Коэфф. сезонности 1 = " + s[0]);
            s[1] = z[7] + z[19] - y[7] - y[19];
            Console.WriteLine("Коэфф. сезонности 2 = " + s[1]);
            s[2] = z[8] + z[20] - y[8] - y[20];
            Console.WriteLine("Коэфф. сезонности 3 = " + s[2]);
            s[3] = z[9] + z[21] - y[9] - y[21];
            Console.WriteLine("Коэфф. сезонности 4 = " + s[3]);
            s[4] = z[10] + z[22] - y[10] - y[22];
            Console.WriteLine("Коэфф. сезонности 5 = " + s[4]);
            s[5] = z[11] + z[23] - y[11] - y[23];
            Console.WriteLine("Коэфф. сезонности 6 = " + s[5]);
            s[6] = z[12] + z[24] - y[12] - y[24];
            Console.WriteLine("Коэфф. сезонности 7 = " + s[6]);
            s[7] = z[13] + z[25] - y[13] - y[25];
            Console.WriteLine("Коэфф. сезонности 8 = " + s[7]);
            s[8] = z[14] + z[26] - y[14] - y[26];
            Console.WriteLine("Коэфф. сезонности 9 = " + s[8]);
            s[9] = z[15] + z[27] - y[15] - y[27];
            Console.WriteLine("Коэфф. сезонности 10 = " + s[9]);
            s[10] = z[16] + z[28] - y[16] - y[28];
            Console.WriteLine("Коэфф. сезонности 11 = " + s[10]);
            s[11] = z[17] + z[29] - y[17] - y[29];
            Console.WriteLine("Коэфф. сезонности 12 = " + s[11]);
        }
    }
}