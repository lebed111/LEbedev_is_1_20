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
    public partial class delet_Bullet : Form
    {
        public BindingSource bSource = new BindingSource();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        public DataTable table = new DataTable();
        Requests f2 = new Requests();
        //не начато
        public delet_Bullet()
        {
            InitializeComponent();
        }

        private void delet_Bullet_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            f2.con();
            string dfr = "SELECT ID FROM Bullet";
            f2.conn.Open();
            MySqlCommand command = new MySqlCommand(dfr, f2.conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0]);
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
                        if (p == Convert.ToInt32(table.Rows[i][1]))
                        {
                            MessageBox.Show($"В ID {Convert.ToInt32(table.Rows[i][0])} данной покупке найденно совпадение по биллету, поэтому его нельзя удалитью");
                            break;
                        }
                    }
                }
                catch
                {
                    DialogResult dialogResult = MessageBox.Show($"Вы точно хотите удалить Биллет с {p} ID", "Удаление", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.conn.Open();
                        string del = $"DELETE FROM Bullet WHERE ID = {p}";
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
