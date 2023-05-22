using System;
using System.Windows.Forms;

namespace MOPR8
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        double[,] myArr = new double[2, 3]; // состояние среды
        double[] myArr1 = new double[2]; // количество
        double[] myArr2 = new double[2]; // вероятность
        double[] myArr3 = new double[3]; // ожидание полезности
        public Form1()
        {
            InitializeComponent();
            GenArray();
            dataGridView1.RowCount = 5;
            dataGridView1.Rows[0].Cells[0].Value = "D1";
            dataGridView1.Rows[1].Cells[0].Value = "D2";
            //dataGridView1.Rows[2].Cells[0].Value = "D3";
            dataGridView1.Rows[2].Cells[0].Value = "Количество";
            ShowArray();

        }

        public void ShowArray()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    dataGridView1.Rows[i].Cells[j + 1].Value = myArr[j, i];
                }
            }
            for (int i = 0; i < 2; i++)
            {
                dataGridView1.Rows[2].Cells[i + 1].Value = myArr1[i];
            }
        }

        public void GenArray()
        {
            myArr[0, 0] = 600.0;
            myArr[0, 1] = -250.0;
            //myArr[0, 2] = 0.0;

            myArr[1, 0] = -250.0;
            myArr[1, 1] = 800.0;
            //myArr[1, 2] = 0.0;

            myArr1[0] = 61.5;
            myArr1[1] = 38.5;
        }

        public void ReadArray() // чтение массива с таблицы при изменении значений массива
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    myArr[i, j] = Convert.ToDouble(dataGridView1.Rows[i].Cells[j + 1].Value);
                }
            }
            for (int i = 0; i < 2; i++)
            {
                myArr1[i] = Convert.ToDouble(dataGridView1.Rows[4].Cells[i + 1].Value);
            }
        }

        private void button1_Click(object sender, EventArgs e) //алгоритм
        {
            label1.Text = " ";
            label2.Text = " ";
            double a = myArr1[0] + myArr1[1]; //общее количество
            double min = 0; //общее количество
            double max = 0; //общее количество
            for (int j = 0; j < 2; j++)
            {
                myArr2[j] = (myArr1[j] / (a / 100.0)) / 100.0;
            }
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    myArr3[i] += (myArr[j, i] * myArr2[j]);
                }
            }
            for (int i = 0; i < 2; i++)
            {
                dataGridView1.Rows[i].Cells[3].Value = myArr3[i];
            }
            min = myArr3[0];
            max = myArr3[0];
            double b = 0;
            double c = 0;
            for (int i = 1; i < 3; i++)
            {
                if (myArr3[i] < min)
                {
                    min = myArr3[i];
                    b = i + 1;
                }
            }

            for (int i = 1; i < 3; i++)
            {
                if (myArr3[i] > max)
                {
                    max = myArr3[i];
                    c = i + 1;
                }
            }
            label1.Text = " " + c;
            label2.Text = " " + b;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GenArray();
            ShowArray();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReadArray();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}