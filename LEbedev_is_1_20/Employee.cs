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
    public partial class Employee : Form
    {
        public BindingSource bSource = new BindingSource();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        public DataTable table = new DataTable();
        Requests f2 = new Requests();

        int start = 1;
        public Employee()
        {
            InitializeComponent();
        }
        void dolg(string i)
        {
            string s = table.Rows[start - 1][5].ToString();
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;
            button6.BackColor = Color.White;
            button7.BackColor = Color.White;

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
            if (button5.Text == i)
            {
                button5.BackColor = Color.Green;
            }

            regex = new Regex(@"2");
            matches = regex.Matches(s);
            foreach (Match match in matches)
                i = match.Value;
            if (button6.Text == i)
            {
                button6.BackColor = Color.Green;
            }

            regex = new Regex(@"1");
            matches = regex.Matches(s);
            foreach (Match match in matches)
                i = match.Value;
            if (button7.Text == i)
            {
                button7.BackColor = Color.Green;
            }
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            f2.con();
            f2.conn.Open();
            string emploee = "SELECT * FROM Emploee";
            MyDA.SelectCommand = new MySqlCommand(emploee, f2.conn);
            bSource.DataSource = table;
            MyDA.Fill(table);
            f2.conn.Close();
            label1.Text = $"ID: {table.Rows[start - 1][0]}";
            label4.Text = $"Фамилия: {table.Rows[start - 1][1]}";
            label5.Text = $"Имя: {table.Rows[start - 1][2]}";
            label6.Text = $"Отчетсво: {table.Rows[start - 1][3]}";
            label8.Text = $"Телефон: {table.Rows[start - 1][6]}";
            dolg(table.Rows[start - 1][5].ToString());
            label13.Text = $"Должность: {table.Rows[start - 1][4]}";
            label10.Text = $"Адрес проживания: {table.Rows[start - 1][7]}";
            label11.Text = $"Логин: {table.Rows[start - 1][8]}";
            for (int i = 1; i <= table.Rows.Count; i++)
            {
                comboBox1.Items.Add(table.Rows[i - 1][0]);
            }
            for (int i = 1; i <= table.Rows.Count; i++)
            {
                comboBox2.Items.Add(table.Rows[i - 1][1]);
            }
            label14.Text = $"{start}/{table.Rows.Count}";
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
