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

namespace LEbedev_is_1_20
{
    public partial class Seans : Form
    {
        public BindingSource bSource = new BindingSource();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        public DataTable table = new DataTable();
        Requests f2 = new Requests();
        public Seans()
        {
            InitializeComponent();
        }
        void reold()
        {
            dataGridView1.Columns.Clear();
            table.Rows.Clear();
            table.Columns.Clear();
            f2.conn.Open();
            string cl = "SELECT * FROM time_seans;";
            MyDA.SelectCommand = new MySqlCommand(cl, f2.conn);
            dataGridView1.DataSource = bSource;
            bSource.DataSource = table;
            MyDA.Fill(table);
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Время сеанса";
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            f2.conn.Close();
        }

        private void Seans_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            f2.con();
            reold();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f2.conn.Open();
            string f = $"INSERT time_seans VALUES ( {Convert.ToInt32(table.Rows[table.Rows.Count-1][0])+1},\"{maskedTextBox1.Text}\")";
            MySqlCommand command = new MySqlCommand(f, f2.conn);
            command.ExecuteNonQuery();
            f2.conn.Close();
            reold();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            f2.conn.Open();
            string del = $" delete FROM time_seans WHERE ID = {Convert.ToInt32(textBox1.Text)}";
            MySqlCommand command = new MySqlCommand(del, f2.conn);
            command.ExecuteNonQuery();
            f2.conn.Close();
            reold();
        }
    }
}
