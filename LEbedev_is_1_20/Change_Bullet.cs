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
    public partial class Change_Bullet : Form
    {
        public BindingSource bSource = new BindingSource();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        public DataTable table = new DataTable();
        public DataTable per = new DataTable();
        Requests f2 = new Requests();
        int start = 1;
        string q = "";
        public Change_Bullet()
        {
            InitializeComponent();
        }
        public void Moon()
        {
            if (table.Rows[start - 1][9].ToString() == "" && table.Rows[start - 1][10].ToString() == "")
            {
                dateTimePicker1.Value = DateTime.Today;
                dateTimePicker2.Value = DateTime.Today;
            }
            else
            {
                try
                {
                    dateTimePicker1.Value = Convert.ToDateTime(table.Rows[start - 1][9]);
                    dateTimePicker2.Value = Convert.ToDateTime(table.Rows[start - 1][10]);
                }
                catch { }
            }
        }
        public void Week()
        {
            string s = table.Rows[start - 1][8].ToString();
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
        public void yers()
        {
            string q = "";
            string s = table.Rows[start - 1][5].ToString();
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;

            Regex regex = new Regex(@"4-12");
            MatchCollection matches = regex.Matches(s);
            foreach (Match match in matches)
                q = match.Value;
            if (button3.Text == q)
            {
                button3.BackColor = Color.Green;
            }
            regex = new Regex(@"13-59");
            matches = regex.Matches(s);
            foreach (Match match in matches)
                q = match.Value;
            if (button4.Text == q)
            {
                button4.BackColor = Color.Green;
            }
            regex = new Regex(@"60+");
            matches = regex.Matches(s);
            foreach (Match match in matches)
                q = match.Value;
            if (button5.Text == q)
            {
                button5.BackColor = Color.Green;
            }
        }
        private void Change_Bullet_Load(object sender, EventArgs e)
        {
            f2.con();
            f2.conn.Open();
            string tab = "SELECT * FROM Bullet  LEFT JOIN Percent ON Bullet.Discount = Percent.ID";
            MyDA.SelectCommand = new MySqlCommand(tab, f2.conn);
            bSource.DataSource = table;
            MyDA.Fill(table);
            f2.conn.Close();
            label1.Text = $"ID {table.Rows[start - 1][0]}";
            textBox2.Text = $"{table.Rows[start - 1][1]}";
            textBox3.Text = $"{table.Rows[start - 1][3]}";
            textBox4.Text = $"{Convert.ToDouble(table.Rows[start - 1][3]) - Convert.ToDouble(table.Rows[start - 1][3]) * (Convert.ToDouble(table.Rows[start - 1][7]) / 100)}";
            textBox1.Text = $"{table.Rows[start - 1][1]}";
            comboBox1.Text = $"{table.Rows[start - 1][6]}";
            Moon();
            Week();
            yers();
            f2.conn.Open();
            string perc = "SELECT * FROM Percent";
            MyDA.SelectCommand = new MySqlCommand(perc, f2.conn);
            bSource.DataSource = per;
            MyDA.Fill(per);
            for (int i = 1; i <= per.Rows.Count; i++)
            {
                comboBox1.Items.Add(per.Rows[i - 1][6]);
            }
            f2.conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "")
                {
                    label2.Text = "0 %";
                    textBox4.Text = textBox3.Text;
                }
                string i = comboBox1.Text;
                for (int c = 0; c <= 9999999; c++)
                {
                    if (i == per.Rows[c][6].ToString())
                    {
                        start = c + 1;
                        string q = $"{per.Rows[c][2]}";
                        Week();
                        Moon();
                        textBox4.Text = $"{Convert.ToDouble(textBox3.Text) - (Convert.ToDouble(textBox3.Text) * Convert.ToDouble(per.Rows[start - 1][1]) / 100) }";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
