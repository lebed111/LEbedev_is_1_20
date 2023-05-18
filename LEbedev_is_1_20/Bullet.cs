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
    public partial class Bullet : Form
    {
        public BindingSource bSource = new BindingSource();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        public DataTable table = new DataTable();
        Requests f2 = new Requests();
        int start = 1;
        int cout = 0;
        public Bullet()
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
            string q = "";
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
        private void Bullet_Load(object sender, EventArgs e)
        {
            f2.con();
            f2.conn.Open();
            string stroc = "SELECT ID FROM Bullet";
            MySqlCommand command = new MySqlCommand(stroc, f2.conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cout++;
            }
            label1.Text = $"{start}/{cout}";
            f2.conn.Close();
            f2.conn.Open();
            string tab = "SELECT * FROM Bullet  LEFT JOIN Percent ON Bullet.Discount = Percent.ID";
            MyDA.SelectCommand = new MySqlCommand(tab, f2.conn);
            bSource.DataSource = table;
            MyDA.Fill(table);
            for (int i = 1; i <= table.Rows.Count; i++)
            {
                comboBox1.Items.Add(table.Rows[i - 1][1]);
            }
            f2.conn.Close();
            label2.Text = $"ID {table.Rows[start - 1][0]}";
            label3.Text = $"Название биллета : {table.Rows[start - 1][1]}";
            label4.Text = $"Цена без скидки : {table.Rows[start - 1][3]}";
            label5.Text = $"Цена со скидкой : {Convert.ToDouble(table.Rows[start - 1][3]) - Convert.ToDouble(table.Rows[start - 1][3]) * (Convert.ToDouble(table.Rows[start - 1][7]) / 100)}";
            textBox1.Text = $"{table.Rows[start - 1][1]}";
            label9.Text = $"ID скидки {table.Rows[start - 1][6]}";
            yers();
            Week();
            Moon();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (start < cout)
            {
                start += 1;
                label1.Text = $"{start}/{cout}";
                label2.Text = $"ID {table.Rows[start - 1][0]}";
                label3.Text = $"Название биллета : {table.Rows[start - 1][1]}";
                label4.Text = $"Цена без скидки : {table.Rows[start - 1][3]}";
                label5.Text = $"Цена со скидкой : {Convert.ToDouble(table.Rows[start - 1][3]) - Convert.ToDouble(table.Rows[start - 1][3]) * (Convert.ToDouble(table.Rows[start - 1][7]) / 100)}";
                textBox1.Text = $"{table.Rows[start - 1][1]}";
                label9.Text = $"ID скидки {table.Rows[start - 1][6]}";
                yers();
                Week();
                Moon();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (start > 1)
            {
                start -= 1;
                label1.Text = $"{start}/{cout}";
                label2.Text = $"ID {table.Rows[start - 1][0]}";
                label3.Text = $"Название биллета : {table.Rows[start - 1][1]}";
                label4.Text = $"Цена без скидки : {table.Rows[start - 1][3]}";
                label5.Text = $"Цена со скидкой : {Convert.ToDouble(table.Rows[start - 1][3]) - Convert.ToDouble(table.Rows[start - 1][3]) * (Convert.ToDouble(table.Rows[start - 1][7]) / 100)}";
                textBox1.Text = $"{table.Rows[start - 1][1]}";
                label9.Text = $"ID скидки {table.Rows[start - 1][6]}";
                yers();
                Week();
                Moon();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label9_MouseClick(object sender, MouseEventArgs e)
        {
            f2.Kk(1);
            Precent s2 = new Precent();
            s2.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                string r = comboBox1.Text;
                for (int c = 0; c <= 999999999; c++)
                {
                    if (r == table.Rows[c][1].ToString())
                    {
                        start = c + 1;
                        label1.Text = $"{start}/{cout}";
                        label2.Text = $"ID {table.Rows[start - 1][0]}";
                        label3.Text = $"Название биллета : {table.Rows[start - 1][1]}";
                        label4.Text = $"Цена без скидки : {table.Rows[start - 1][3]}";
                        label5.Text = $"Цена со скидкой : {Convert.ToDouble(table.Rows[start - 1][3]) - Convert.ToDouble(table.Rows[start - 1][3]) * (Convert.ToDouble(table.Rows[start - 1][7]) / 100)}";
                        textBox1.Text = $"{table.Rows[start - 1][1]}";
                        label9.Text = $"ID скидки {table.Rows[start - 1][6]}";
                        yers();
                        Week();
                        Moon();
                        break;
                    }
                }
            }
            catch(Exception ex) {  }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
