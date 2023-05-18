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
    public partial class Change_Precent : Form
    {
        public BindingSource bSource = new BindingSource();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        public DataTable table = new DataTable();
        Requests f2 = new Requests();
        int cout = 0;
        int start = 1;
        public Change_Precent()
        {
            InitializeComponent();
        }
        public void Week()
        {
            string q = "";
            string s = table.Rows[start - 1][2].ToString();
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;
            button6.BackColor = Color.White;
            button7.BackColor = Color.White;
            button8.BackColor = Color.White;
            button9.BackColor = Color.White;

            Regex regex = new Regex(@"Понедельник");
            MatchCollection matches = regex.Matches(s);
            foreach (Match match in matches)
                q = match.Value;
            if (button3.Text == q)
            {
                button3.BackColor = Color.Green;
            }

            regex = new Regex(@"Вторник");
            matches = regex.Matches(s);
            foreach (Match match in matches)
                q = match.Value;
            if (button4.Text == q)
            {
                button4.BackColor = Color.Green;
            }

            regex = new Regex(@"Среда");
            matches = regex.Matches(s);
            foreach (Match match in matches)
                q = match.Value;
            if (button5.Text == q)
            {
                button5.BackColor = Color.Green;
            }

            regex = new Regex(@"Четверг");
            matches = regex.Matches(s);
            foreach (Match match in matches)
                q = match.Value;
            if (button6.Text == q)
            {
                button6.BackColor = Color.Green;
            }

            regex = new Regex(@"Пятница");
            matches = regex.Matches(s);
            foreach (Match match in matches)
                q = match.Value;
            if (button7.Text == q)
            {
                button7.BackColor = Color.Green;
            }

            regex = new Regex(@"Суббота");
            matches = regex.Matches(s);
            foreach (Match match in matches)
                q = match.Value;
            if (button8.Text == q)
            {
                button8.BackColor = Color.Green;
            }

            regex = new Regex(@"Воскресенье");
            matches = regex.Matches(s);
            foreach (Match match in matches)
                q = match.Value;
            if (button9.Text == q)
            {
                button9.BackColor = Color.Green;
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

        private void Change_Precent_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            f2.con();
            f2.conn.Open();
            string stroc = "SELECT ID FROM Percent";
            MySqlCommand command = new MySqlCommand(stroc, f2.conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cout++;
            }
            label1.Text = $"{start}/{cout}";
            f2.conn.Close();
            f2.conn.Open();
            string tab = "SELECT * FROM Percent";
            MyDA.SelectCommand = new MySqlCommand(tab, f2.conn);
            bSource.DataSource = table;
            MyDA.Fill(table);
            f2.conn.Close();
            label4.Text = $"Коэфициент скидки";
            textBox2.Text = $"{table.Rows[start - 1][1]}";
            label3.Text = $"{table.Rows[0][0]}";
            Week();
            Moon();
            textBox1.Text = table.Rows[start - 1][5].ToString();
        }

        #region
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.White)
            {
                button3.BackColor = Color.Green;
            }
            else
            {
                button3.BackColor = Color.White;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.White)
            {
                button4.BackColor = Color.Green;
            }
            else
            {
                button4.BackColor = Color.White;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.White)
            {
                button5.BackColor = Color.Green;
            }
            else
            {
                button5.BackColor = Color.White;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.BackColor == Color.White)
            {
                button6.BackColor = Color.Green;
            }
            else
            {
                button6.BackColor = Color.White;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.BackColor == Color.White)
            {
                button7.BackColor = Color.Green;
            }
            else
            {
                button7.BackColor = Color.White;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.BackColor == Color.White)
            {
                button8.BackColor = Color.Green;
            }
            else
            {
                button8.BackColor = Color.White;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.BackColor == Color.White)
            {
                button9.BackColor = Color.Green;
            }
            else
            {
                button9.BackColor = Color.White;
            }
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            if (start > 1)
            {
                start -= 1;
                textBox2.Text = $"{table.Rows[start - 1][1]}";
                label3.Text = $"{table.Rows[start - 1][0]}";
                label1.Text = $"{start}/{cout}";
                Week();
                Moon();
                textBox1.Clear();
                textBox1.Text = table.Rows[start - 1][5].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (start < cout)
            {
                start += 1;
                textBox2.Text = $"{table.Rows[start - 1][1]}";
                label3.Text = $"{table.Rows[start - 1][0]}";
                label1.Text = $"{start}/{cout}";
                Week();
                Moon();
                textBox1.Clear();
                textBox1.Text = table.Rows[start - 1][5].ToString();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string id = label3.Text;
            string cof = textBox2.Text;
            string wensday = "";
            //Определение дней недели
            #region
            if (button3.BackColor == Color.Green)
            {
                wensday += button3.Text;
            }
            if (button4.BackColor == Color.Green)
            {
                wensday += button4.Text;
            }
            if (button5.BackColor == Color.Green)
            {
                wensday += button5.Text;
            }
            if (button6.BackColor == Color.Green)
            {
                wensday += button6.Text;
            }
            if (button7.BackColor == Color.Green)
            {
                wensday += button7.Text;
            }
            if (button8.BackColor == Color.Green)
            {
                wensday += button8.Text;
            }
            if (button9.BackColor == Color.Green)
            {
                wensday += button9.Text;
            }
            #endregion
            var date = Convert.ToDateTime(dateTimePicker2.Value.ToShortDateString());
            var date1 = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());
            string info = textBox1.Text;
            if(dateTimePicker2.Value == dateTimePicker1.Value)
            {
                f2.conn.Open();
                string cl = $"UPDATE Percent SET Percent = {cof}, PeriodWeek = \"{wensday}\", Yslovia=\"{info}\" WHERE ID ={id};";
                MySqlCommand command = new MySqlCommand(cl, f2.conn);
                command.ExecuteNonQuery();
                f2.conn.Close();
            }
            if(dateTimePicker2.Value < dateTimePicker1.Value)
            {
                MessageBox.Show("Вы неправильно указали дату");
            }
            if (dateTimePicker2.Value > dateTimePicker1.Value)
            {
                f2.conn.Open();
                string cl = $"UPDATE Percent SET Percent = {cof} , PeriodWeek = \"{wensday}\" , ReriodMon = \"{date1.ToString("yyyy-MM-dd")}\" , ReriodMoon = \"{date.ToString("yyyy-MM-dd")}\" , Yslovia=\"{info}\" WHERE ID = {id};";
                MySqlCommand command = new MySqlCommand(cl, f2.conn);
                command.ExecuteNonQuery();
                f2.conn.Close();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                int i = Convert.ToInt32(textBox2.Text);
                for (int c = 0; i >= Convert.ToInt32(table.Rows[c][0]); c++)
                {
                    if (i == Convert.ToInt32(table.Rows[c][0]))
                    {
                        start = c + 1;
                        label4.Text = $"Коэфициент скидки {table.Rows[start - 1][1]}%";
                        label3.Text = $"{table.Rows[start - 1][0]}";
                        label1.Text = $"{start}/{cout}";
                        Week();
                        Moon();
                        textBox1.Clear();
                        textBox1.Text = table.Rows[start - 1][5].ToString();
                    }
                }
            }
            catch { }
        }
    }
}
