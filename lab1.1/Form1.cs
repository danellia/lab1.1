/*Вариант 5
Дана целочисленная квадратная матрица порядка 5. Найдите
максимальный элемент среди элементов, лежащих левее вспомогательной
диагонали, и максимальный элемент среди элементов, лежащих правее
вспомогательной диагонали, поменяйте их местами*/

using System.Collections;

namespace lab1._1
{
    public partial class Form1 : Form
    {
        Matrix m;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m = new Matrix();
            dataGridView1.RowCount = Matrix.size;
            dataGridView1.ColumnCount = Matrix.size;
            for (int i = 0; i < Matrix.size; ++i)
            {
                dataGridView1.Columns[i].Width = 40;
                dataGridView1.Rows[i].Height = 25;
                dataGridView1.Columns[i].ValueType = typeof(int);
            }
        }

        private void startToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            readMatrix();
            m.changeMaxes();
            showMatrix();
        }

        private void randomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m.fillRandom();
            showMatrix();
        }

        private void readMatrix()
        {
            try
            {
                for (int i = 0; i < Matrix.size; ++i)
                {
                    for (int j = 0; j < Matrix.size; ++j)
                    {
                        m[i, j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Пустая Матрица!");
                clear();
            }
        }

        private void showMatrix()
        {
            for (int i = 0; i < Matrix.size; ++i)
            {
                for (int j = 0; j < Matrix.size; ++j)
                {
                    dataGridView1.Rows[i].Cells[j].Value = m[i, j];
                }
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            m = new Matrix();
            for (int i = 0; i < Matrix.size; ++i)
            {
                for (int j = 0; j < Matrix.size; ++j)
                {
                    dataGridView1.Rows[i].Cells[j].Value = "";
                }
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Введите целое число!");
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
            e.ThrowException = false;
        }
    }
}