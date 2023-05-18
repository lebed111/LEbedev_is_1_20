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

namespace LEbedev_is_1_20
{
    public partial class Menu : MetroFramework.Forms.MetroForm
    {
        public Menu()
        {
            InitializeComponent();
        }
        int  q = 1;

        private void Menu_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            label1.Text = Auth.auth_fio;
            label2.Text = Auth.auto_post;
            Bullet bullet = new Bullet() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            bullet.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(bullet);
            bullet.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void коэфициентыСкидокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            Precent precent = new Precent { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            precent.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(precent);
            precent.Show();
            q = 2;
            
        }

        private void биллетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            Bullet bullet = new Bullet() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            bullet.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(bullet);
            bullet.Show();
            q = 1;
        }

        private void metroButton1_Click(object sender, EventArgs e)//добавление
        {
            if(q == 1)
            {
                Add_Bullet add_Bullet = new Add_Bullet();
                add_Bullet.ShowDialog();
                this.panel1.Controls.Clear();
                Bullet bullet = new Bullet() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                bullet.FormBorderStyle = FormBorderStyle.None;
                this.panel1.Controls.Add(bullet);
                bullet.Show();
                q = 1;
            }
            if (q == 2)
            {
                Add_Precent precen = new Add_Precent();
                precen.ShowDialog();
                this.panel1.Controls.Clear();
                Precent precent = new Precent { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                precent.FormBorderStyle = FormBorderStyle.None;
                this.panel1.Controls.Add(precent);
                precent.Show();
                q = 2;
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)//изменить
        {
            if(q == 1)
            {
                Change_Bullet change_Bullet = new Change_Bullet();
                change_Bullet.ShowDialog();
                this.panel1.Controls.Clear();
                Bullet bullet = new Bullet() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                bullet.FormBorderStyle = FormBorderStyle.None;
                this.panel1.Controls.Add(bullet);
                bullet.Show();
                q = 1;
            }
            if (q==2)
            {
                Change_Precent change_Precent = new Change_Precent();
                change_Precent.ShowDialog();
                this.panel1.Controls.Clear();
                Precent precent = new Precent { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                precent.FormBorderStyle = FormBorderStyle.None;
                this.panel1.Controls.Add(precent);
                precent.Show();
                q = 2;
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)//удалить
        {
            if(q==2)
            {
                delet_Precent delet = new delet_Precent();
                delet.ShowDialog();
                this.panel1.Controls.Clear();
                Precent precent = new Precent { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                precent.FormBorderStyle = FormBorderStyle.None;
                this.panel1.Controls.Add(precent);
                precent.Show();
                q = 2;
            }
        }

        private void metroButton5_Click(object sender, EventArgs e)//сортировка
        {

        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
