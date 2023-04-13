using System;
using System.Linq;
using System.Windows.Forms;

namespace upr3
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        int[,] myArr = new int[8, 7];  //Массив значений
        int max_krit = 0;
        int count_krit = 0;

        public Form1()
        {
            InitializeComponent();
            GenArray();
            dataGridViewPareto.RowCount = 8;
            dataGridViewPareto1.RowCount = 8;
            for (int i = 0; i < 8; i++)
            {
                dataGridViewPareto.Rows[i].Cells[0].Value = "Вариант N" + Convert.ToString(i + 1);
                dataGridViewPareto1.Rows[i].Cells[0].Value = "Вариант N" + Convert.ToString(i + 1);
            }
            ShowArray();
            ShowArray1();
        }
        public void ShowArray() // Отображение массива в таблице
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    dataGridViewPareto.Rows[i].Cells[j + 1].Value = myArr[i, j];
                }
            }
        }

        public void ShowArray1() // Отображение массива в таблице
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    dataGridViewPareto1.Rows[i].Cells[j + 1].Value = myArr[i, j];
                }
            }
        }

        public void GenArray() // Генерация массива случайных значений
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    myArr[i, j] = rand.Next(1, 6);
                }
            }
        }

        public void ReadArray() // Чтение массива с таблицы при изменении значений массива
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    myArr[i, j] = Convert.ToInt32(dataGridViewPareto.Rows[i].Cells[j + 1].Value);
                }
            }
        }

        public void ReadArray1() // Чтение массива с таблицы при изменении значений массива
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    myArr[i, j] = Convert.ToInt32(dataGridViewPareto1.Rows[i].Cells[j + 1].Value);
                }
            }
        }

        public bool CompareArray(int[] arr1, int[] arr2) // Сравнение одномерных массивов
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

        public void FillArray(int[] arr3, int size, int arr_row) // Заполнение одномерного массива для сравнения
        {
            for (int i = 0; i < size; i++)
            {
                arr3[i] = myArr[arr_row, i];
            }
        }

        public void ZeroArray(int size_row, int arr_row) // Заполнение одномерного массива в (удаление массива)
        {
            for (int i = 0; i < size_row; i++)
            {
                myArr[arr_row, i] = 0;
            }
        }

        public void BestResult() // Вывод лучших результатов
        {
            label_Result.Text = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (myArr[i, j] != 0)
                    {
                        if (i == 8)
                            label_Result.Text += "Вариант N'" + Convert.ToString(i + 1);
                        else label_Result.Text += "Вариант N*" + Convert.ToString(i + 1) + " , ";
                        j = 8;
                    }
                }
            }
        }

        public void Pareto()
        {
            int i = 0;
            int j = 1;
            int N = 7;
            Boolean flag = true;
            ReadArray1();
            do
            {
                int[] a = new int[7];
                int[] b = new int[7];
                FillArray(a, 7, i);
                FillArray(b, 7, j);
                if (CompareArray(a, b)) //Шаг 2
                {
                    ZeroArray(7, j); //Шаг 3
                    if (j < N) // 4
                    {
                        j++;
                    }
                    else
                    {
                        if (i < (N - 1)) // Шаг 7
                        {
                            i++;
                            j = i + 1;
                        }
                        else flag = false; // Конец вычислений
                    }
                }
                else
                {
                    int[] c = new int[7];
                    int[] d = new int[7];
                    FillArray(c, 7, j);
                    FillArray(d, 7, i);
                    if (CompareArray(c, d)) // ar 5
                    {
                        ZeroArray(7, i); // Шаг 6
                        if (i < (N - 1)) // Ш 7
                        {
                            i++;
                            j = i + 1;
                        }
                        else flag = false; // Конец вычислений
                    }
                    else
                    {
                        if (j < N)
                        {
                            j++;
                        }
                        else
                        {
                            if (i < (N - 1))
                            {
                                i++;
                                j = i + 1;
                            }
                            else flag = false; // Конец вычислений
                        }
                    }
                }
            }
            while (flag);
            ShowArray1();
            BestResult();
        }


        private void Button_Pareto_Click(object sender, EventArgs e)
        {
            Pareto();
        }

        private void ButtonArray_Click(object sender, EventArgs e)
        {
            GenArray();
            ShowArray();
            ShowArray1();
        }

        public void Suzhenie1()
        {
            ReadArray();
            int wk = Convert.ToInt32(textBox_krit.Text); // важный критерий wk--;
            wk--;
            double w_j = 1;// wj
            double w_i;//wi
            double q = Convert.ToDouble(textBox_otv.Text);//wi
            w_i = Math.Round((w_j - (q * w_j)) / (q), 4);// расчет wj из 9
            if (textBox_krit.Text == "1")
            {
                max_krit = 1;
            }
            else if (textBox_krit.Text == "2")
            {
                max_krit = 2;
            }
            else if (textBox_krit.Text == "3")
            {
                max_krit = 3;
            }
            else if (textBox_krit.Text == "4")
            {
                max_krit = 4;
            }
            else if (textBox_krit.Text == "5")
            {
                max_krit = 5;
            }
            else if (textBox_krit.Text == "6")
            {
                max_krit = 6;
            }
            else if (textBox_krit.Text == "7")
            {
                max_krit = 7;
            }



            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (myArr[i, j] == 0)
                    {
                        count_krit += 1;
                    }
                }
                if (count_krit != 7)
                {
                    if (max_krit == 1)
                        for (int j = 1; j < 7; j++)
                        {
                            myArr[i, j] = Convert.ToInt32(myArr[i, wk] * w_j + w_i * myArr[i, j]);
                        }
                    else if (max_krit == 2)
                        for (int j = 0; j < 7; j++)
                        {
                            if (i == 1)
                                continue;
                            myArr[i, j] = Convert.ToInt32(myArr[i, wk] * w_j + w_i * myArr[i, j]);
                        }
                    else if (max_krit == 3)
                        for (int j = 0; j < 7; j++)
                        {
                            if (i == 2)
                                continue;
                            myArr[i, j] = Convert.ToInt32(myArr[i, wk] * w_j + w_i * myArr[i, j]);
                        }
                    else if (max_krit == 4)
                        for (int j = 0; j < 7; j++)
                        {
                            if (i == 3)
                                continue;
                            myArr[i, j] = Convert.ToInt32(myArr[i, wk] * w_j + w_i * myArr[i, j]);
                        }
                    else if (max_krit == 5)
                        for (int j = 0; j < 7; j++)
                        {
                            if (i == 4)
                                continue;
                            myArr[i, j] = Convert.ToInt32(myArr[i, wk] * w_j + w_i * myArr[i, j]);
                        }
                    else if (max_krit == 6)
                        for (int j = 0; j < 7; j++)
                        {
                            if (i == 5)
                                continue;
                            myArr[i, j] = Convert.ToInt32(myArr[i, wk] * w_j + w_i * myArr[i, j]);
                        }
                    else if (max_krit == 7)
                        for (int j = 0; j < 7; j++)
                        {
                            if (i == 6)
                                continue;
                            myArr[i, j] = Convert.ToInt32(myArr[i, wk] * w_j + w_i * myArr[i, j]);
                        }


                }
                count_krit = 0;
            }
            label_wi.Text = Convert.ToString(w_i);
            label_wj.Text = Convert.ToString(w_j);
            label_Result.Text = "Нажмите ввод.";

        }

        private void Button_Suzhenie_Click(object sender, EventArgs e)
        {
            Suzhenie1();
            ShowArray1();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ShowArray1();
        }

        public void Suzhenie2()
        {
            ReadArray();

            if (!int.TryParse(textBox_krit.Text, out int wk))// важный критерий
            {
                wk = 1;
                textBox_krit.Text = Convert.ToString(wk);
            }
            wk--;
            if (double.TryParse(textBox_otv.Text, out double q))// коэфициент
            {
                q = 0.5;
                textBox_otv.Text = Convert.ToString(q);
            }

            if (textBox_krit.Text == "1")
            {
                max_krit = 1;
            }
            else if (textBox_krit.Text == "2")
            {
                max_krit = 2;
            }
            else if (textBox_krit.Text == "3")
            {
                max_krit = 3;
            }
            else if (textBox_krit.Text == "4")
            {
                max_krit = 4;
            }
            else if (textBox_krit.Text == "5")
            {
                max_krit = 5;
            }
            else if (textBox_krit.Text == "6")
            {
                max_krit = 6;
            }
            else if (textBox_krit.Text == "7")
            {
                max_krit = 7;
            }



            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (myArr[i, j] == 0)
                    {
                        count_krit += 1;
                    }
                }
                if (count_krit != 7)
                {
                    if (max_krit == 1)
                        for (int j = 1; j < 7; j++)
                        {
                            myArr[i, j] = Convert.ToInt32(myArr[i, wk] * q + (1 - q) * myArr[i, j]);
                        }
                    else if (max_krit == 2)
                        for (int j = 0; j < 7; j++)
                        {
                            if (j == 1)
                                continue;
                            myArr[i, j] = Convert.ToInt32(myArr[i, wk] * q + (1 - q) * myArr[i, j]);
                        }
                    else if (max_krit == 3)
                        for (int j = 0; j < 7; j++)
                        {
                            if (j == 2)
                                continue;
                            myArr[i, j] = Convert.ToInt32(myArr[i, wk] * q + (1 - q) * myArr[i, j]);
                        }
                    else if (max_krit == 4)
                        for (int j = 0; j < 7; j++)
                        {
                            if (j == 3)
                                continue;
                            myArr[i, j] = Convert.ToInt32(myArr[i, wk] * q + (1 - q) * myArr[i, j]);
                        }
                    else if (max_krit == 5)
                        for (int j = 0; j < 7; j++)
                        {
                            if (j == 4)
                                continue;
                            myArr[i, j] = Convert.ToInt32(myArr[i, wk] * q + (1 - q) * myArr[i, j]);
                        }
                    else if (max_krit == 6)
                        for (int j = 0; j < 7; j++)
                        {
                            if (j == 5)
                                continue;
                            myArr[i, j] = Convert.ToInt32(myArr[i, wk] * q + (1 - q) * myArr[i, j]);
                        }
                    else if (max_krit == 7)
                        for (int j = 0; j < 7; j++)
                        {
                            if (j == 6)
                                continue;
                            myArr[i, j] = Convert.ToInt32(myArr[i, wk] * q + (1 - q) * myArr[i, j]);
                        }


                }
            }
            label_wi.Text = "wi";
            label_wj.Text = "wj";
            label_Result.Text = "Нажмите ввод.";
        }

        private void Button_Prog_Click(object sender, EventArgs e)
        {
            Suzhenie2();
            ShowArray1();
        }

        private void ButtonCP_Click(object sender, EventArgs e)
        {  //метод целевого программирования
            if (radioButton1.Checked == true)
            {
                Suzhenie1();
                Pareto();
            }
            if (radioButton2.Checked == true)
            {
                Suzhenie2();
                Pareto();
            }

            double[] val2_arr = new double[8]; //массив значений
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    val2_arr[i] += Math.Pow(myArr[i, j], 2);
                }
                val2_arr[i] = Math.Sqrt(val2_arr[i]);
                if (val2_arr[i] == 0)
                    val2_arr[i] = 9999999999999999;
            }

            int min = Array.IndexOf(val2_arr, val2_arr.Min());

            for (int i = 0; i <8; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i == min)
                    {
                        myArr[i, j] = myArr[i, j];
                    }
                    else
                    {
                        myArr[i, j] = 0;
                    }
                }
            }
            ShowArray1();
            BestResult();
        }
    }
}
