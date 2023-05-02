using System;
using System.Windows.Forms;

namespace MOPR6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowCount = 3;
            dataGridView1.ColumnCount = 9;

            dataGridView1.Rows[0].Cells[0].Value = 101;
            dataGridView1.Rows[1].Cells[0].Value = 275;
            dataGridView1.Rows[2].Cells[0].Value = 32;

            dataGridView1.Rows[0].Cells[1].Value = 224;
            dataGridView1.Rows[1].Cells[1].Value = 74;
            dataGridView1.Rows[2].Cells[1].Value = 69;

            dataGridView1.Rows[0].Cells[2].Value = 102;
            dataGridView1.Rows[1].Cells[2].Value = 144;
            dataGridView1.Rows[2].Cells[2].Value = 159;

            dataGridView1.Rows[0].Cells[3].Value = 83;
            dataGridView1.Rows[1].Cells[3].Value = 32;
            dataGridView1.Rows[2].Cells[3].Value = 123;

            dataGridView1.Rows[0].Cells[4].Value = 104;
            dataGridView1.Rows[1].Cells[4].Value = 99;
            dataGridView1.Rows[2].Cells[4].Value = 154;

            dataGridView1.Rows[0].Cells[5].Value = 202;
            dataGridView1.Rows[1].Cells[5].Value = 155;
            dataGridView1.Rows[2].Cells[5].Value = 23;

            dataGridView1.Rows[0].Cells[6].Value = 142;
            dataGridView1.Rows[1].Cells[6].Value = 197;
            dataGridView1.Rows[2].Cells[6].Value = 52;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show
                ("Вы действительно хотите выйти?", "Завершение программы", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button_Maut_Click(object sender, EventArgs e)
        {
            int[,] matrix = new int[3, 7]; //Матрица критериев
            double[,] matrix_U = new double[7, 3]; // матрица функций полезности
            double[,] matrix_U_trans = new double[3, 7]; // Транспонир. матрица ф-ий полезности
            double[] w = new double[7]; //матрица весов критериев
            double[] result = new double[3]; //результат
            string bestAlt; //лучшая альтернатива

            if (tB11.Text == "" || tB12.Text == "" || tB13.Text == "" ||
                tB21.Text == "" || tB22.Text == "" || tB23.Text == "" ||
                tB31.Text == "" || tB32.Text == "" || tB33.Text == "" ||
                tB41.Text == "" || tB42.Text == "" || tB43.Text == "" ||
                tB51.Text == "" || tB52.Text == "" || tB53.Text == "" ||
                tB61.Text == "" || tB62.Text == "" || tB63.Text == "" ||
                tB71.Text == "" || tB72.Text == "" || tB73.Text == "" ||

                tBw1.Text == "" || tBw2.Text == "" || tBw3.Text == "" ||
                tBw4.Text == "" || tBw5.Text == "" || tBw6.Text == "" ||
                tBw7.Text == ""  )
            {
                MessageBox.Show("Для начала заполните функции полезности и/или веса критериев",
                    "Ошибка при запуске программы", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Заполнение матрицы из таблицы
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        matrix[i, j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);

                    }
                }

                //
                matrix_U[0, 0] = Convert.ToDouble(tB11.Text);
                matrix_U[0, 1] = Convert.ToDouble(tB12.Text);
                matrix_U[0, 2] = Convert.ToDouble(tB13.Text);

                matrix_U[1, 0] = Convert.ToDouble(tB21.Text);
                matrix_U[1, 1] = Convert.ToDouble(tB22.Text);
                matrix_U[1, 2] = Convert.ToDouble(tB23.Text);

                matrix_U[2, 0] = Convert.ToDouble(tB31.Text);
                matrix_U[2, 1] = Convert.ToDouble(tB32.Text);
                matrix_U[2, 2] = Convert.ToDouble(tB33.Text);

                matrix_U[3, 0] = Convert.ToDouble(tB41.Text);
                matrix_U[3, 1] = Convert.ToDouble(tB42.Text);
                matrix_U[3, 2] = Convert.ToDouble(tB43.Text);

                matrix_U[4, 0] = Convert.ToDouble(tB51.Text);
                matrix_U[4, 1] = Convert.ToDouble(tB52.Text);
                matrix_U[4, 2] = Convert.ToDouble(tB53.Text);

                matrix_U[5, 0] = Convert.ToDouble(tB61.Text);
                matrix_U[5, 1] = Convert.ToDouble(tB62.Text);
                matrix_U[5, 2] = Convert.ToDouble(tB63.Text);

                matrix_U[6, 0] = Convert.ToDouble(tB71.Text);
                matrix_U[6, 1] = Convert.ToDouble(tB72.Text);
                matrix_U[6, 2] = Convert.ToDouble(tB73.Text);

                //
                w[0] = Convert.ToDouble(tBw1.Text);
                w[1] = Convert.ToDouble(tBw2.Text);
                w[2] = Convert.ToDouble(tBw3.Text);
                w[3] = Convert.ToDouble(tBw4.Text);
                w[4] = Convert.ToDouble(tBw5.Text);
                w[5] = Convert.ToDouble(tBw6.Text);
                w[6] = Convert.ToDouble(tBw7.Text);

                //
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        matrix_U_trans[i, j] = matrix_U[j, i];
                    }
                }

                //
                for (int i = 0; i < 3; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < 7; j++)
                    {
                        sum += matrix_U_trans[i, j] * w[j];
                    }

                    result[i] = sum;
                }

                //
                U0.Text = "" + Convert.ToString(result[0]);
                U1.Text = "" + Convert.ToString(result[1]);
                U2.Text = "" + Convert.ToString(result[2]);

                if ((result[0] > result[1]) && (result[0] > result[2]))
                    bestAlt = "А - " + Convert.ToString(result[0]);

                else if (result[1] > result[2])
                    bestAlt = "В - " + Convert.ToString(result[1]);
                else 
                    bestAlt = "С - " + Convert.ToString(result[2]);

                bestAltlab.Text = "Лучшей альтернативой является:\n " + "Альтернатива " + bestAlt;

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (tB11.Text == "" || tB12.Text == "" || tB13.Text == "" ||
                tB21.Text == "" || tB22.Text == "" || tB23.Text == "" ||
                tB31.Text == "" || tB32.Text == "" || tB33.Text == "" ||
                tB41.Text == "" || tB42.Text == "" || tB43.Text == "" ||
                tB51.Text == "" || tB52.Text == "" || tB53.Text == "" ||
                tB61.Text == "" || tB62.Text == "" || tB63.Text == "" ||
                tB71.Text == "" || tB72.Text == "" || tB73.Text == "" ||
                tBw1.Text == "" || tBw2.Text == "" || tBw3.Text == "" ||
                tBw4.Text == "" || tBw5.Text == "" || tBw6.Text == "" ||
                tBw7.Text == ""  )
            {
                MessageBox.Show("Очищать нечего, все поля пустые",
                    "Ошибка при очистке полей", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                tB11.Clear();
                tB12.Clear();
                tB13.Clear();
                tB21.Clear();
                tB22.Clear();
                tB23.Clear();
                tB31.Clear();
                tB32.Clear();
                tB33.Clear();
                tB41.Clear();
                tB42.Clear();
                tB43.Clear();
                tB51.Clear();
                tB52.Clear();
                tB53.Clear();
                tB61.Clear();
                tB62.Clear();
                tB63.Clear();
                tB71.Clear();
                tB72.Clear();
                tB73.Clear();

                tBw1.Clear();
                tBw2.Clear();
                tBw3.Clear();
                tBw4.Clear();
                tBw5.Clear();
                tBw6.Clear();
                tBw7.Clear();

                U0.Text = "U0 = ";
                U1.Text = "U1 = ";
                U2.Text = "U2 = ";

            }    
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
