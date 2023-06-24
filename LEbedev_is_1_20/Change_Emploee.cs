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
    public partial class Change_Emploee : Form
    {
        public BindingSource bSource = new BindingSource();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        public DataTable table = new DataTable();
        Requests f2 = new Requests();

        int start = 1;
        public Change_Emploee()
        {
            InitializeComponent();
        }
        void dolg(string i)
        {
            string s = table.Rows[start - 1][5].ToString();
            button4.BackColor = Color.White;
            button3.BackColor = Color.White;
            button2.BackColor = Color.White;
            button1.BackColor = Color.White;

            Regex regex = new Regex(@"0");
            MatchCollection matches = regex.Matches(s);
            foreach (Match match in matches)
                i = match.Value;
            if (button4.Text == i)
            {
                button4.BackColor = Color.Green;
            }

            regex = new Regex(@"3");
            matches = regex.Matches(s);
            foreach (Match match in matches)
                i = match.Value;
            if (button3.Text == i)
            {
                button3.BackColor = Color.Green;
            }

            regex = new Regex(@"2");
            matches = regex.Matches(s);
            foreach (Match match in matches)
                i = match.Value;
            if (button2.Text == i)
            {
                button2.BackColor = Color.Green;
            }

            regex = new Regex(@"1");
            matches = regex.Matches(s);
            foreach (Match match in matches)
                i = match.Value;
            if (button1.Text == i)
            {
                button1.BackColor = Color.Green;
            }
        }
        private void Change_Emploee_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            f2.con();
            f2.conn.Open();
            string emploee = "SELECT * FROM Emploee";
            MyDA.SelectCommand = new MySqlCommand(emploee, f2.conn);
            bSource.DataSource = table;
            MyDA.Fill(table);
            f2.conn.Close();
            label15.Text = $"ID: {table.Rows[start - 1][0]}";
            textBox1.Text = $"{table.Rows[start - 1][1]}";
            textBox2.Text = $"{table.Rows[start - 1][2]}";
            textBox3.Text = $"{table.Rows[start - 1][3]}";
            textBox4.Text = $"{table.Rows[start - 1][6]}";
            dolg(table.Rows[start - 1][5].ToString());
            textBox6.Text = $"{table.Rows[start - 1][4]}";
            textBox7.Text = $"{table.Rows[start - 1][7]}";
            textBox8.Text = $"{table.Rows[start - 1][8]}";
            for (int i = 1; i <= table.Rows.Count; i++)
            {
                comboBox1.Items.Add(table.Rows[i - 1][0]);
            }
            for (int i = 1; i <= table.Rows.Count; i++)
            {
                comboBox2.Items.Add(table.Rows[i - 1][1]);
            }
            label22.Text = $"{start}/{table.Rows.Count}";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = $"{textBox1.Text.Length}/255";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label3.Text = $"{textBox2.Text.Length}/255";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label14.Text = $"{textBox3.Text.Length}/255";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            label16.Text = $"{textBox6.Text.Length}/255";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            label17.Text = $"{textBox7.Text.Length}/255";
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            label19.Text = $"{textBox8.Text.Length}/255";
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            label18.Text = $"{textBox9.Text.Length}/255";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
