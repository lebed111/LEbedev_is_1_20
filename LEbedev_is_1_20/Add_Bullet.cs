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
using System.Text.RegularExpressions;

namespace LEbedev_is_1_20
{
    public partial class Add_Bullet : Form
    {
        Requests f2 = new Requests();
        public BindingSource bSource = new BindingSource();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        public DataTable table = new DataTable();
        int start = 1;
        double cof = 0;
        public void Week()
        {
            string q = "";
            string s = table.Rows[start - 1][2].ToString();
            button6.BackColor = Color.White;
            button7.BackColor = Color.White;
            button8.BackColor = Color.White;
            button9.BackColor = Color.White;
            button10.BackColor = Color.White;
            button11.BackColor = Color.White;
            button12.BackColor = Color.White;

            Regex regex = new Regex(@"Понедельник");
            MatchCollection matches = regex.Matches(s);
            foreach (Match match in matches)
                q = match.Value;
            if (button6.Text == q)
            {
                button6.BackColor = Color.Green;
            }

            regex = new Regex(@"Вторник");
            matches = regex.Matches(s);
            foreach (Match match in matches)
                q = match.Value;
            if (button7.Text == q)
            {
                button7.BackColor = Color.Green;
            }

            regex = new Regex(@"Среда");
            matches = regex.Matches(s);
            foreach (Match match in matches)
                q = match.Value;
            if (button8.Text == q)
            {
                button8.BackColor = Color.Green;
            }

            regex = new Regex(@"Четверг");
            matches = regex.Matches(s);
            foreach (Match match in matches)
                q = match.Value;
            if (button9.Text == q)
            {
                button9.BackColor = Color.Green;
            }

            regex = new Regex(@"Пятница");
            matches = regex.Matches(s);
            foreach (Match match in matches)
                q = match.Value;
            if (button10.Text == q)
            {
                button10.BackColor = Color.Green;
            }

            regex = new Regex(@"Суббота");
            matches = regex.Matches(s);
            foreach (Match match in matches)
                q = match.Value;
            if (button11.Text == q)
            {
                button11.BackColor = Color.Green;
            }

            regex = new Regex(@"Воскресенье");
            matches = regex.Matches(s);
            foreach (Match match in matches)
                q = match.Value;
            if (button12.Text == q)
            {
                button12.BackColor = Color.Green;
            }
        }
        public void Moon()
        {
            if (table.Rows[start - 1][3].ToString() == "" && table.Rows[start - 1][4].ToString() == "")
            {
                dateTimePicker1.Value = DateTime.Today;
                dateTimePicker2.Value = DateTime.Today;
            }
            else
            {
                try
                {
                    dateTimePicker1.Value = Convert.ToDateTime(table.Rows[start - 1][3]);
                    dateTimePicker2.Value = Convert.ToDateTime(table.Rows[start - 1][4]);
                }
                catch { }
            }
        }
        public Add_Bullet()
        {
            InitializeComponent();
        }

        private void Add_Bullet_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            f2.con();
            label2.Text = "0 %";
            f2.conn.Open();
            string tab = "SELECT * FROM Percent";
            MyDA.SelectCommand = new MySqlCommand(tab, f2.conn);
            bSource.DataSource = table;
            MyDA.Fill(table);
            f2.conn.Close();
            for (int i = 1; i <= table.Rows.Count; i++)
            {
                comboBox1.Items.Add(table.Rows[i-1][0]);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.Green;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.Green;
            button3.BackColor = Color.White;
            button5.BackColor = Color.White;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.BackColor = Color.Green;
            button4.BackColor = Color.White;
            button3.BackColor = Color.White;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "")
                {
                    textBox4.Text = textBox3.Text;
                }
                else
                {
                    textBox4.Text = $"{Convert.ToDouble(textBox3.Text) - (Convert.ToDouble(textBox3.Text) * Convert.ToDouble(table.Rows[start - 1][1]) / 100) }";
                }
            }
            catch { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(comboBox1.Text == "")
                {
                    label2.Text = "0 %";
                    textBox4.Text = textBox3.Text;
                }
                int i = Convert.ToInt32(comboBox1.Text);
                for (int c = 0; i >= Convert.ToInt32(table.Rows[c][0]); c++)
                {
                    if (i == Convert.ToInt32(table.Rows[c][0]))
                    {
                        start = c + 1;
                        Week();
                        Moon();
                        label2.Text = $"{table.Rows[c][1]} %";
                        textBox4.Text = $"{Convert.ToDouble(textBox3.Text) - (Convert.ToDouble(textBox3.Text) * Convert.ToDouble(table.Rows[start - 1][1]) / 100) }";                     
                    }
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox2.Text;
                string opi = textBox1.Text;
                double pri = Convert.ToDouble(textBox3.Text);
                string yer = "";
                if (button3.BackColor == Color.Green)
                {
                    yer = button3.Text;
                }
                if (button4.BackColor == Color.Green)
                {
                    yer = button4.Text;
                }
                if (button5.BackColor == Color.Green)
                {
                    yer = button5.Text;
                }
                if (yer == "")
                {
                    uint tet = 0;
                    uint error = 10 / tet;
                }
                int dsc = 1;
                try { dsc = Convert.ToInt32(comboBox1.Text); } catch { }
                f2.conn.Open();
                string com = $"INSERT INTO  Bullet (Name,Description,Price,Discount,Lecture) VALUES (\"{name}\",\"{opi}\",{pri},{dsc},\"{yer}\")";
                MySqlCommand command = new MySqlCommand(com, f2.conn);
                command.ExecuteNonQuery();
                f2.conn.Close();
                this.Close();
            }
            catch (System.DivideByZeroException) { MessageBox.Show("Укажите возрастнуюую категорию"); }
            catch { MessageBox.Show("Заполните все поля"); }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
    }
}
