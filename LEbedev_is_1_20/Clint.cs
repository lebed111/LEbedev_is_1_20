using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LEbedev_is_1_20
{
    public partial class Clint : Form
    {
        public BindingSource bSource = new BindingSource();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        public DataTable table = new DataTable();
        Requests f2 = new Requests();
        int start = 1;
     
        // не начато
        public Clint()
        {
            InitializeComponent();
        }
        void blacWait()
        {
            string a = table.Rows[start - 1][6].ToString();
            if (a == "да")
            {
                button10.Text = "да";
                button10.BackColor = Color.Black;
                button10.ForeColor = Color.White;
            }
            else
            {
                button10.Text = "нет";
                button10.BackColor = Color.White;
                button10.ForeColor = Color.Black;
            }
        }

        private void Clint_Load(object sender, EventArgs e)
        {
            f2.con();
            f2.conn.Open();
            string tab = "SELECT * FROM Client";
            MyDA.SelectCommand = new MySqlCommand(tab, f2.conn);
            bSource.DataSource = table;
            MyDA.Fill(table);
            label8.Text = $"{start}/{table.Rows.Count}";
            label1.Text = $"ID : {table.Rows[start -1][0]}";
            label2.Text = $"Фамилия : {table.Rows[start - 1][1]}";
            label3.Text = $"Имя : {table.Rows[start - 1][2]}";
            label4.Text = $"Отчество : {table.Rows[start - 1][3]}";
            label5.Text = $"Телефон : {table.Rows[start - 1][4]}";
            label6.Text = $"Почта : {table.Rows[start - 1][5]}";
            f2.conn.Close();
            for (int i = 1; i <= table.Rows.Count; i++)
            {
                comboBox1.Items.Add(table.Rows[i - 1][0]);
            }
            for (int i = 1; i <= table.Rows.Count; i++)
            {
                comboBox2.Items.Add(table.Rows[i - 1][1]);
            }
            blacWait();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                int r = Convert.ToInt32(comboBox1.Text);
                for (int c = 0; c <= 999999999; c++)
                {
                    if (r == Convert.ToInt32(table.Rows[c][0]))
                    {
                        start = c + 1;
                        label8.Text = $"{start}/{table.Rows.Count}";
                        label1.Text = $"ID : {table.Rows[start - 1][0]}";
                        label2.Text = $"Фамилия : {table.Rows[start - 1][1]}";
                        label3.Text = $"Имя : {table.Rows[start - 1][2]}";
                        label4.Text = $"Отчество : {table.Rows[start - 1][3]}";
                        label5.Text = $"Телефон : {table.Rows[start - 1][4]}";
                        label6.Text = $"Почта : {table.Rows[start - 1][5]}";
                        blacWait();
                        break;
                    }
                }
            }
            catch (Exception ex) {  }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string r = comboBox2.Text;
                for (int c = 0; c <= 999999999; c++)
                {
                    if (r == table.Rows[c][1].ToString())
                    {
                        start = c + 1;
                        label8.Text = $"{start}/{table.Rows.Count}";
                        label1.Text = $"ID : {table.Rows[start - 1][0]}";
                        label2.Text = $"Фамилия : {table.Rows[start - 1][1]}";
                        label3.Text = $"Имя : {table.Rows[start - 1][2]}";
                        label4.Text = $"Отчество : {table.Rows[start - 1][3]}";
                        label5.Text = $"Телефон : {table.Rows[start - 1][4]}";
                        label6.Text = $"Почта : {table.Rows[start - 1][5]}";
                        blacWait();
                        break;
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (start > 1)
            {
                start -= 1;
                label8.Text = $"{start}/{table.Rows.Count}";
                label1.Text = $"ID : {table.Rows[start - 1][0]}";
                label2.Text = $"Фамилия : {table.Rows[start - 1][1]}";
                label3.Text = $"Имя : {table.Rows[start - 1][2]}";
                label4.Text = $"Отчество : {table.Rows[start - 1][3]}";
                label5.Text = $"Телефон : {table.Rows[start - 1][4]}";
                label6.Text = $"Почта : {table.Rows[start - 1][5]}";
                blacWait();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (start < table.Rows.Count)
            {
                start += 1;
                label8.Text = $"{start}/{table.Rows.Count}";
                label1.Text = $"ID : {table.Rows[start - 1][0]}";
                label2.Text = $"Фамилия : {table.Rows[start - 1][1]}";
                label3.Text = $"Имя : {table.Rows[start - 1][2]}";
                label4.Text = $"Отчество : {table.Rows[start - 1][3]}";
                label5.Text = $"Телефон : {table.Rows[start - 1][4]}";
                label6.Text = $"Почта : {table.Rows[start - 1][5]}";
                blacWait();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }
    }
}
