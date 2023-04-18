using System;
using System.Windows.Forms;

namespace mopr5
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        double[,] myArr = new double[10, 10];
        double[,] myArr1 = new double[10, 10];

        public Form1()
        {
            InitializeComponent();
            GenArray();
            dataGridViewPareto.RowCount = 10;
            dataGridViewPareto1.RowCount = 10;
            for (int i = 0; i < 10; i++)
            {
                dataGridViewPareto.Rows[i].Cells[0].Value = "Вариант N" + Convert.ToString(i + 1);
                dataGridViewPareto1.Rows[i].Cells[0].Value = "Вариант N" + Convert.ToString(i + 1);
            }
            ShowArray();
            ShowArray1();
        }
        public void ShowArray() // Отображение массива в таблице
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    dataGridViewPareto.Rows[i].Cells[j + 1].Value = myArr[i, j];
                }
            }
        }

        public void ShowArray1() // Отображение массива в таблице
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    dataGridViewPareto1.Rows[i].Cells[j + 1].Value = myArr[i, j];
                }
            }
        }

        public void GenArray() // Генерация массива случайных значений
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == j)
                    {
                        myArr[i, j] = 1.0;
                    }
                    else
                    if (i > j)
                    {
                        myArr[i, j] = Math.Round(1.0 / Convert.ToDouble(myArr[j, i]), 3);
                    }
                    else
                    {
                        myArr[i, j] = rand.Next(1, 6);
                    }
                }
            }
        }

        public void ReadArray() // Чтение массива с таблицы при изменении значений массива
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    myArr1[i, j] = Convert.ToInt32(dataGridViewPareto.Rows[i].Cells[j + 1].Value);
                    if (i == j)
                        myArr1[i, j] = 1.0;
                }
            }
        }

        private double[] NormalMatrix(double[,] matrix)
        {
            var sum = new double[10];
            var norm_v = new double[10];
            double summ = 0;
            for (int i = 0; i < 10; i++)
            {
                sum[i] = 1;
                for (int j = 0; j < 10; j++)
                {
                    sum[i] = matrix[i, j];
                }
                sum[i] = Math.Pow(sum[i], 1/10.0);//оценки компомент собственого вектора
            }
            for (int i = 0; i < 10; i++)
            {
                summ += sum[i];//сумма оценки компонент собственого вектора
            }
            for (int i = 0; i < 10; i++)
            {
                norm_v[i] = sum[i]/summ;//Нормализованые оценки вектора приоритета
            }
            return norm_v;
        }

        public double MaxZnM(double[,] matrix, double[] norm_v)
        {
            var sum = new double[10];
            var lmax = new double[10];
            double lmaxx = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    sum[i] += matrix[j, i];//сумма столбцов
                }
            }
            for (int i = 0; i < 10; i++)
            {
                lmax[i] = sum[i]* norm_v[i];
            }
            for (int i = 0; i < 10; i++)
            {
                lmaxx += lmax[i];//максимальное собственное значение
            }
            return lmaxx;
        }

        private void Button_Pareto_Click(object sender, EventArgs e)  //Реализация МАИ
        {
            ReadArray();
            label1.Text = "";
            label2.Text = "";
            var n = 10;
            ShowArray();
            var norm_v = NormalMatrix(myArr); //Нормализованные оценки вектора приоритета
            var lmax = MaxZnM(myArr, norm_v); //Максимальное собственное значение
            ShowArray1();

            for (int c = 0; c < 10; c++)
                label1.Text += Convert.ToString(Math.Round(norm_v[c], 2)) + " ";

            var IC = (lmax - n) / (n - 1); //индекс согласованности
            var CC = 1.49; //значение случайной согласованности для матрицы 6-го порядка
            var OC = IC / CC; //оценка согласованности матрицы

            label2.Text = Convert.ToString(Math.Round(OC, 2));
            if (OC <= 0.1)
                label2.Text += " - матрица согласованная";
            else
                label2.Text += " - матрица не согласованная";
        }

        private void ButtonArray_Click(object sender, EventArgs e) //генерация и вывод массива случайных значений
        {
            GenArray();
            ShowArray();
            ShowArray1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReadArray();
            ShowArray1();
        }
    }
}

       