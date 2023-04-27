﻿using System;
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
    public partial class Precent : Form
    {
        public BindingSource bSource = new BindingSource();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        public DataTable table = new DataTable();
        Requests f2 = new Requests();
        int cout = 0;
        int start = 1;

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
        public Precent()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Precent_Load(object sender, EventArgs e)
        {
            f2.con();
            f2.conn.Open();
            string stroc = "SELECT ID FROM Percent";
            MySqlCommand command = new MySqlCommand(stroc, f2.conn);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
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
            label4.Text = $"Коэфициент скидки {table.Rows[start - 1][1]}%";
            label3.Text = $"{table.Rows[0][0]}";
            Week();
            Moon();
            textBox1.Text = table.Rows[start - 1][5].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (start < cout)
            {
                start += 1;
                label4.Text = $"Коэфициент скидки {table.Rows[start - 1][1]}%";
                label3.Text = $"{table.Rows[start - 1][0]}";
                label1.Text = $"{start}/{cout}";
                Week();
                Moon();
                textBox1.Clear();
                textBox1.Text = table.Rows[start - 1][5].ToString();
            }           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (start > 1)
            {
                start -= 1;
                label4.Text = $"Коэфициент скидки {table.Rows[start - 1][1]}%";
                label3.Text = $"{table.Rows[start - 1][0]}";
                label1.Text = $"{start}/{cout}";
                Week();
                Moon();
                textBox1.Clear();
                textBox1.Text = table.Rows[start - 1][5].ToString();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
