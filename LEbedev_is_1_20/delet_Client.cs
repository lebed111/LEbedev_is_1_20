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
    public partial class delet_Client : Form
    {
        public BindingSource bSource = new BindingSource();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        public DataTable table = new DataTable();
        Requests f2 = new Requests();
        public delet_Client()
        {
            InitializeComponent();
        }

        private void delet_Client_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            f2.con();
            f2.conn.Open();
            string client = "SELECT * FROM Client";
            MyDA.SelectCommand = new MySqlCommand(client, f2.conn);
            bSource.DataSource = table;
            MyDA.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                comboBox1.Items.Add(table.Rows[i][0].ToString());
            }
            f2.conn.Close();
            f2.conn.Open();
            string buy = "SELECT * FROM Buy";
            MyDA.SelectCommand = new MySqlCommand(buy, f2.conn);
            bSource.DataSource = table;
            MyDA.Fill(table);
            f2.conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int p = Convert.ToInt32(comboBox1.SelectedItem);
                try
                {
                    for (int i = 0; p < 9999999; i++)
                    {
                        if (p == Convert.ToInt32(table.Rows[i][2]))
                        {
                            MessageBox.Show($"В ID {Convert.ToInt32(table.Rows[i][0])} по данному клиенту найденно совпадение по биллету, поэтому его нельзя удалитью");
                            break;
                        }
                    }
                }
                catch
                {
                    DialogResult dialogResult = MessageBox.Show($"Вы точно хотите удалить клиента с {p} ID", "Удаление", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.conn.Open();
                        string del = $"DELETE FROM Client WHERE ID = {p}";
                        MySqlCommand command = new MySqlCommand(del, f2.conn);
                        command.ExecuteNonQuery();
                        f2.conn.Close();
                        this.Close();

                    }
                    else if (dialogResult == DialogResult.No)
                    {

                    }
                }
            }
            catch { MessageBox.Show("Ведите цифырку которую можно выбрать"); }
        }
    }
}
