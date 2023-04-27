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
    public partial class delet_Precent : Form
    {
        Requests f2 = new Requests();
        public delet_Precent()
        {
            InitializeComponent();
        }

        private void delet_Precent_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            f2.con();
            string dfr = "SELECT ID FROM Percent";
            f2.conn.Open();
            MySqlCommand command = new MySqlCommand(dfr, f2.conn);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                comboBox1.Items.Add(reader[0]);
            }
            f2.conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int p = Convert.ToInt32(comboBox1.SelectedItem);
            DialogResult dialogResult = MessageBox.Show($"Вы точно хотите удалить скидку с {p} ID", "Удаление", MessageBoxButtons.YesNo) ;
            if (dialogResult == DialogResult.Yes)
            {
                f2.conn.Open();
                string del = $"DELETE FROM Percent WHERE ID = {p}";
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
}
