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
    public partial class Add_Client : Form
    {
        Requests f2 = new Requests();
        public Add_Client()
        {
            InitializeComponent();
        }

        private void Add_Client_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            button10.BackColor = Color.White;
            f2.con();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = $"{textBox1.Text.Length}/255";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label7.Text = $"{textBox2.Text.Length}/255";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label8.Text = $"{textBox3.Text.Length}/255";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            label10.Text = $"{textBox6.Text.Length}/255";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (button10.BackColor == Color.White)
            {
                button10.BackColor = Color.Black;
                button10.Text = "да";
                button10.ForeColor = Color.White;
            }
            else 
            {
                button10.BackColor = Color.White;
                button10.Text = "нет";
                button10.ForeColor = Color.Black;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int q = 0;
            string dab = $"INSERT INTO  Client(Famila,Name,Otchestvo,Telefon,Mail,BlacList) VALUES (\"{textBox1.Text}\",\"{textBox2.Text}\",\" {textBox3.Text}\",\"{maskedTextBox1.Text}\",\"{textBox6.Text}\",\"{button10.Text}\")";
            Regex regex = new Regex(@"([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)");
            MatchCollection matches = regex.Matches(textBox6.Text);
            foreach (Match match in matches)
                q = match.Length;
            if (q > 0 && textBox1.TextLength > 0 && textBox2.TextLength > 0 && maskedTextBox1.TextLength > 0 && textBox6.TextLength > 0)
            {
                f2.conn.Open();
                MySqlCommand command = new MySqlCommand(dab, f2.conn);
                command.ExecuteNonQuery();
                f2.conn.Close();
                this.Close();
            }

            else if (q == 0)
            {
                MessageBox.Show("Неправильно ввели почту");
            }
            
            else
            {
                MessageBox.Show("Заполните все строчки");
            }
        }
    }
}
