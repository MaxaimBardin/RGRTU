using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace ELECTRE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dgV_Alternativa.RowCount = 4;
            dgV_Alternativa.ColumnCount = 3;
            dgV_Soglasie.RowCount = 4;
            dgV_Soglasie.ColumnCount = 4;
            dgV_Nesoglasie.RowCount = 4;
            dgV_Nesoglasie.ColumnCount = 4;
            dgV_Alternativa.Rows[0].Cells[0].Value = 100;
            dgV_Alternativa.Rows[0].Cells[1].Value = 90;
            dgV_Alternativa.Rows[0].Cells[2].Value = 5;

            dgV_Alternativa.Rows[1].Cells[0].Value = 75;
            dgV_Alternativa.Rows[1].Cells[1].Value = 60;
            dgV_Alternativa.Rows[1].Cells[2].Value = 15;

            dgV_Alternativa.Rows[2].Cells[0].Value = 50;
            dgV_Alternativa.Rows[2].Cells[1].Value = 40;
            dgV_Alternativa.Rows[2].Cells[2].Value = 30;

            dgV_Alternativa.Rows[3].Cells[0].Value = 25;
            dgV_Alternativa.Rows[3].Cells[1].Value = 30;
            dgV_Alternativa.Rows[3].Cells[2].Value = 50;

            nud_w1.Text = "3";
            nud_w2.Text = "2";
            nud_w3.Text = "1";
        }

        int[,] matrix = new int[4, 3]; //Матрица альтернатив 
        int[] w = new int[3]; //Матрица весов 
        double[] L = new double[3]; //Матрица длин шкал 
        double[,] C_matrix = new double[4, 4]; //Матрица согласия 
        double[,] D_matrix = new double[4, 4]; //Матрица несогласия

        public void Row_Compare_MC(int[,] mtr)
        {
            int c1 = 0;
            int c2 = 0;
            int n = 0; //Номер строки 
            double sum_w = w[0] + w[1] + w[2]; //Сумма весов 
            for (int i = 0; i < 4; i++)
            {
                for (int i1 = 0; i1 < 4; i1++)
                {
                    if ((i1 == 0) & (i == 0) & (n == 0)) continue;
                    if (((i1 == 1) & (i == 1) & (n == 1))) continue;
                    if (((i1 == 2) & (i == 2) & (n == 2))) continue;
                    if ((i1 == 3) & (i == 3) & (n == 3)) continue;
                    int sum_row = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        if (mtr[i, j] <= mtr[i1, j])
                        {
                            sum_row += w[j];
                        }
                    }
                    if (c2 > 3)
                    {
                        c1 += 1;
                        c2 = 0;
                    }
                    if (c1 == c2)
                    {
                        C_matrix[c1, c2] = 0;
                        c2 += 1;
                    }
                    C_matrix[c1, c2] = sum_row / sum_w;
                    c2 += 1;
                }
                n += 1;
            }
        }

        public void Row_Compare_MD(int[,] mtr)
        {
            int c1 = 0;
            int c2 = 0;
            int n = 0; //Номер строки 
            double[] d = new double[3]; //Индекс несогласия 
            double res = 0.0;
            for (int i = 0; i < 4; i++)
            {
                for (int i1 = 0; i1 < 4; i1++)
                {
                    if ((i1 == 0) & (i == 0) & (n == 0)) continue;
                    if (((i1 == 1) & (i == 1) & (n == 1))) continue;
                    if (((i1 == 2) & (i == 2) & (n == 2))) continue;
                    if ((i1 == 3) & (i == 3) & (n == 3)) continue;
                    Array.Clear(d, 0, 2);
                    for (int j = 0; j < 3; j++)
                    {
                        if (mtr[i, j] > mtr[i1, j])
                        {
                            res = (mtr[i, j] - mtr[i1, j]) / L[j];
                            d[j] = res;
                        }
                    }
                    if (c2 > 3)
                    {
                        c1 += 1;
                        c2 = 0;
                    }
                    if (c1 == c2)
                    {
                        D_matrix[c1, c2] = 0;
                        c2 += 1;
                    }
                    D_matrix[c1, c2] = d.Max();
                    c2 += 1;
                }
                n += 1;
            }
        }

        //Создание матриц согласия и несогласия 
        private void btn_Create_Mtrxs_Click_1(object sender, EventArgs e)
        {
            if ((Convert.ToString(nud_l1.Value) == "0") ||
            (Convert.ToString(nud_l2.Value) == "0") ||
            (Convert.ToString(nud_l3.Value) == "0") ||
            (Convert.ToString(nud_w1.Value) == "0") ||
            (Convert.ToString(nud_w2.Value) == "0"))
            {
                MessageBox.Show("Заполните все длины шкал!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Заполнение матрицы из таблицы 
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[i, j] = Convert.ToInt32(dgV_Alternativa.Rows[i].Cells[j].Value);
                }
            }
            //Заполнение матрицы весов критериев 
            w[0] = 3;
            w[1] = 2;
            w[2] = 1;
            //Заполнение матрицы длин шкал 
            L[0] = Convert.ToInt32(nud_l1.Value);
            L[1] = Convert.ToInt32(nud_l2.Value);
            L[2] = Convert.ToInt32(nud_l3.Value);
            Row_Compare_MC(matrix);
            Row_Compare_MD(matrix);
            var n = dgV_Soglasie.RowCount;
            var m = dgV_Soglasie.ColumnCount;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    dgV_Soglasie[j, i].Value = Math.Round(C_matrix[i, j], 2).ToString(); //Вывод матрицы согласия 
                    dgV_Nesoglasie[j, i].Value = Math.Round(D_matrix[i, j], 2).ToString(); //Вывод матрицы несогласия 
                }
            }
        }

        //Расчет лучшей альтернативы 
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (tb_sogl.Text == "" || tb_nesogl.Text == "")
            {
                MessageBox.Show("Заполните все уровни!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Задание уровней согласия и несогласия 
            double a = Convert.ToDouble(tb_sogl.Text);
            double l = Convert.ToDouble(tb_nesogl.Text);
            int[] sum_a = new int[4];
            int[] sum_l = new int[4];
            var n = dgV_Soglasie.RowCount;
            var m = dgV_Soglasie.ColumnCount;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (Convert.ToDouble(dgV_Soglasie[j, i].Value) >= a)
                    {
                        dgV_Soglasie[j, i].Style.BackColor = Color.Green;
                        sum_a[i] += 1;
                    }
                    if (Convert.ToDouble(dgV_Nesoglasie[j, i].Value) <= l && Convert.ToDouble(dgV_Soglasie[j, i].Value) != 0)
                    {
                        dgV_Nesoglasie[j, i].Style.BackColor = Color.Green;
                        sum_l[i] += 1;
                    }
                }
            }
            int max1 = sum_a[0];
            int max2 = sum_l[0];
            int maxind1 = 0;
            int maxind2 = 0;
            for (int i = 0; i < 4; i++)
            {
                if (sum_a[i] > max1)
                {
                    max1 = sum_a[i];
                    maxind1 = i;
                }
                if (sum_l[i] > max2)
                {
                    max2 = sum_l[i];
                    maxind2 = i;
                }
            }
            if (maxind1 == maxind2)
            {
                label_result.Text = "";
                if (maxind1 == 0)
                    label_result.Text += "Наилучшая альтернатива - A";
                if (maxind1 == 1)
                    label_result.Text += "Наилучшая альтернатива - B";
                if (maxind1 == 2)
                    label_result.Text += "Наилучшая альтернатива - C";
                if (maxind1 == 3)
                    label_result.Text += "Наилучшая альтернатива - D";
            }
            else label_result.Text = "Необходимо продолжить \nвычисления." +
            "На данный момент \n" +
            "НЕТ лучшей альтернативы.";
        }

        private void tb_sogl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back && (e.KeyChar != ','))
                {
                    e.Handled = true;
                }
            }
        }

        private void tb_nesogl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back && (e.KeyChar != ','))
                {
                    e.Handled = true;
                }
            }
        }

        private void nud_l1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

