using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace XMLex3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Заповність усі поля", "Помилка");
            }
            else
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
                dataGridView1.Rows[n].Cells[2].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[3].Value = comboBox1.Text;
                dataGridView1.Rows[n].Cells[4].Value = comboBox2.Text;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int n = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
                dataGridView1.Rows[n].Cells[2].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[3].Value = comboBox1.Text;
                dataGridView1.Rows[n].Cells[4].Value = comboBox2.Text;
            }
            else
            {
                MessageBox.Show("Виберіть рядок для редагування.", "Помилка.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Виберіть рядок для видалення.", "Помилка.");
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            int n = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value);
            numericUpDown1.Value = n;
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.TableName = "Employee";
                dt.Columns.Add("Name");
                dt.Columns.Add("Surname");
                dt.Columns.Add("Age", typeof(int)); 
                dt.Columns.Add("Designer", typeof(bool));
                dt.Columns.Add("Web", typeof(bool));
                ds.Tables.Add(dt);

                foreach (DataGridViewRow r in dataGridView1.Rows) 
                {
                    DataRow row = ds.Tables["Employee"].NewRow();

                    row["Name"] = r.Cells[0].Value;
                    row["Surname"] = r.Cells[1].Value;
                    row["Age"] = Convert.ToInt32(r.Cells[2].Value); 
                    row["Designer"] = Convert.ToBoolean(r.Cells[3].Value); 
                    row["Web"] = Convert.ToBoolean(r.Cells[4].Value);
                    ds.Tables["Employee"].Rows.Add(row);
                }

                ds.WriteXml("D:\\Data.xml");
                MessageBox.Show("XML файл успішно збережено", "Виконано");
            }
            catch
            {
                MessageBox.Show("XML файл успішно збережено", "Виконано");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                MessageBox.Show("Очистіть поле перед завантаженням нового файлу.", "Помилка.");
            }
            else
            {
                if (File.Exists("D:\\Data.xml"))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml("D:\\Data.xml");
                    foreach (DataRow item in ds.Tables["Employee"].Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells[0].Value = item["Name"];
                        dataGridView1.Rows[n].Cells[1].Value = item["Surname"];
                        dataGridView1.Rows[n].Cells[2].Value = item["Age"];
                        dataGridView1.Rows[n].Cells[3].Value = item["Designer"];
                        dataGridView1.Rows[n].Cells[4].Value = item["Web"];
                    }
                }
                else
                {
                    MessageBox.Show("XML файл не знайдено.", "Помилка.");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Таблиця порожня.", "Помилка.");
            }
        }
    }
}