/*
double[] x = new double[10];
double[] y = new double[10];

double[] xn = new double[10];
double[] yn = new double[10];

double[] a = new double[10];
double[] b = new double[10];

x[0] = 1.0; y[0] = 1.0;
x[1] = 2.0; y[1] = 2.1;
x[2] = 3.0; y[2] = 3.3;
x[3] = 4.0; y[3] = 4.4;
x[4] = 5.0; y[4] = 5.5;
x[5] = 6.0; y[5] = 6.7;
x[6] = 7.0; y[6] = 7.9;
x[7] = 8.0; y[7] = 8.9;
x[8] = 9.0; y[8] = 10.2;
x[9] = 10.0; y[9] = 11.5;

xn[0] = 1.5;
xn[1] = 2.5;
xn[2] = 3.5;
xn[3] = 4.5;
xn[4] = 5.5;
xn[5] = 6.5;
xn[6] = 7.5;
xn[7] = 8.5;
xn[8] = 9.5;

Console.WriteLine("Коэффициенты:");
for (int i = 1; i < 10; i++)
{
    a[i] = (y[i] - y[i - 1]) / (x[i] - x[i - 1]);
    b[i] = y[i - 1] - a[i] * x[i - 1];
    Console.WriteLine("a[" + i + "]=" + a[i]);
    Console.WriteLine("b[" + i + "]=" + b[i]);
}
Console.WriteLine("");
Console.WriteLine("Результирующие точки");
for (int i = 0; i < 9; i++)
{
    yn[i] = a[i + 1] * xn[i] + b[i + 1];
    Console.WriteLine("x = " + xn[i] + " y = " + yn[i]);
}
Console.ReadKey();
*/

double[] x = new double[10];
double[] y = new double[10];
double[] xn = new double[10];

//исходная функция
x[0] = 1.0; y[0] = 1.0;
x[1] = 2.0; y[1] = 2.1;
x[2] = 3.0; y[2] = 3.3;
x[3] = 4.0; y[3] = 4.4;
x[4] = 5.0; y[4] = 5.5;
x[5] = 6.0; y[5] = 6.7;
x[6] = 7.0; y[6] = 7.9;
x[7] = 8.0; y[7] = 8.9;
x[8] = 9.0; y[8] = 10.2;
x[9] = 10.0; y[9] = 11.5;

//точки интерполяции
xn[0] = 1.5;
xn[1] = 2.5;
xn[2] = 3.5;
xn[3] = 4.5;
xn[4] = 5.5;
xn[5] = 6.5;
xn[6] = 7.5;
xn[7] = 8.5;
xn[8] = 9.5;

int lenght = 10;

Console.WriteLine("Расчет многочлена(полинома) Лангранжа");
for (int i = 0; i < lenght - 1; i++)
{
    var Po1 = 0.0;
    for (int j = 0; j < lenght; j++)
    {
        var Lag = 1.0;
        for (int k = 0; k < lenght; k++)
        {
            if (j != k)
            {
                Lag *= (xn[i] - x[k]) / (x[j] - x[k]);
                Po1 += y[j] * Lag;
            }
        }
    }
    Console.WriteLine($"x = {xn[i],-6:0.0} y = {Po1,-6:0.00}");
}

/*
double[] x = new double[10];
double[] y = new double[10];
double[] xn = new double[10];

x[0] = 1.0; y[0] = 1.0;
x[1] = 2.0; y[1] = 2.1;
x[2] = 3.0; y[2] = 3.3;
x[3] = 4.0; y[3] = 4.4;
x[4] = 5.0; y[4] = 5.5;
x[5] = 6.0; y[5] = 6.7;
x[6] = 7.0; y[6] = 7.9;
x[7] = 8.0; y[7] = 8.9;
x[8] = 9.0; y[8] = 10.2;
x[9] = 10.0; y[9] = 11.5;

xn[0] = 1.5;
xn[1] = 2.5;
xn[2] = 3.5;
xn[3] = 4.5;
xn[4] = 5.5;
xn[5] = 6.5;
xn[6] = 7.5;
xn[7] = 8.5;
xn[8] = 9.5;

int lenght = 10;
Console.WriteLine("Расчет методом первой интерполяционной формулой Ньютона");
var h = x[1] - x[0];
for (int i = 0; i < (lenght - 1); i++)
{
    double[] delta_y = y.ToArray();
    double Pol = delta_y[0];
    double Fnct = 1.0;
    for (int j = 0; j < (lenght - 1); j++)
    {
        for (int k = 0; k < (lenght - j - 1); k++)
        {
            delta_y[k] = delta_y[k + 1] - delta_y[k];
        }
        Fnct *= (xn[i] - x[j]) / ((j + 1) * h);
        Pol += delta_y[0] * Fnct;
    }
    Console.WriteLine($"x = {xn[i],-6:0.0} y={Pol,-6:0.0}");
}
*/