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
    public partial class Change_Client : Form
    {
        public BindingSource bSource = new BindingSource();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        public DataTable table = new DataTable();
        Requests f2 = new Requests();
        int start = 1;
        string tel;
        public Change_Client()
        {
            InitializeComponent();
        }
        void telefon()
        {
            tel = table.Rows[start - 1][4].ToString();
            tel = tel.Remove(0,4);
            tel = tel.Remove(3,2);
            tel = tel.Remove(6,1);
            tel = tel.Remove(8,1);

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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Change_Client_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            f2.con();
            f2.conn.Open();
            string tabl = "SELECT * FROM Client";
            MyDA.SelectCommand = new MySqlCommand(tabl, f2.conn);
            bSource.DataSource = table;
            MyDA.Fill(table);
            label1.Text = $"ID : {table.Rows[start - 1][0]}";
            label8.Text = $"{start}/{table.Rows.Count}";
            textBox1.Text = $"{table.Rows[start - 1][1]}";
            textBox2.Text = $"{table.Rows[start - 1][2]}";
            textBox3.Text = $"{table.Rows[start - 1][3]}";
            telefon();
            maskedTextBox1.Text = $"{tel}";
            textBox6.Text = $"{table.Rows[start - 1][5]}";
            blacWait();
            for (int i = 1; i <= table.Rows.Count; i++)
            {
                comboBox1.Items.Add(table.Rows[i - 1][0]);
            }
            for (int i = 1; i <= table.Rows.Count; i++)
            {
                comboBox2.Items.Add(table.Rows[i - 1][1]);
            }
            f2.conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label12.Text = $"{textBox1.TextLength}/255";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label13.Text = $"{textBox2.TextLength}/255";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label14.Text = $"{textBox3.TextLength}/255";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            label17.Text = $"{textBox6.TextLength}/255";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(start < table.Rows.Count)
            {
                start += 1;
                label1.Text = $"ID : {table.Rows[start - 1][0]}";
                label8.Text = $"{start}/{table.Rows.Count}";
                textBox1.Text = $"{table.Rows[start - 1][1]}";
                textBox2.Text = $"{table.Rows[start - 1][2]}";
                textBox3.Text = $"{table.Rows[start - 1][3]}";
                telefon();
                maskedTextBox1.Text = $"{tel}";
                textBox6.Text = $"{table.Rows[start - 1][5]}";
                blacWait();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (start > 1)
            {
                start -= 1;
                label1.Text = $"ID : {table.Rows[start - 1][0]}";
                label8.Text = $"{start}/{table.Rows.Count}";
                textBox1.Text = $"{table.Rows[start - 1][1]}";
                textBox2.Text = $"{table.Rows[start - 1][2]}";
                textBox3.Text = $"{table.Rows[start - 1][3]}";
                telefon();
                maskedTextBox1.Text = $"{tel}";
                textBox6.Text = $"{table.Rows[start - 1][5]}";
                blacWait();
            }
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
                        textBox1.Text = $"{table.Rows[start - 1][1]}";
                        textBox2.Text = $"{table.Rows[start - 1][2]}";
                        textBox3.Text = $"{table.Rows[start - 1][3]}";
                        telefon();
                        maskedTextBox1.Text = $"{tel}";
                        textBox6.Text = $"{table.Rows[start - 1][5]}";
                        blacWait();
                        break;
                    }
                }
            }
            catch (Exception ex) { }
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
                        textBox1.Text = $"{table.Rows[start - 1][1]}";
                        textBox2.Text = $"{table.Rows[start - 1][2]}";
                        textBox3.Text = $"{table.Rows[start - 1][3]}";
                        telefon();
                        maskedTextBox1.Text = $"{tel}";
                        textBox6.Text = $"{table.Rows[start - 1][5]}";
                        blacWait();
                        break;
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            string add = $"UPDATE Client SET Famila = \"{textBox1.Text}\", Name = \"{textBox2.Text}\", Otchestvo = \"{textBox3.Text}\", Telefon = \"{maskedTextBox1.Text}\", Mail = \"{textBox6.Text}\", BlacList = \"{button10.Text}\"  WHERE ID = {table.Rows[start - 1][0]}";
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            MatchCollection matches = regex.Matches(textBox6.Text);
            if (matches.Count > 0 && maskedTextBox1.Text.Length == 18)
            {
                f2.conn.Open();
                MySqlCommand command = new MySqlCommand(add, f2.conn);
                command.ExecuteNonQuery();
                f2.conn.Close();
                this.Close();
            }
            if (maskedTextBox1.Text.Length < 18)
            {
                MessageBox.Show("Неправильно указан номер телефона");
            }
            if (matches.Count == 0)
            {
                MessageBox.Show("Неправильно указана почта");
            }
        }
    }
}
