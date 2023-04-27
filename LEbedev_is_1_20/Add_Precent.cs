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
    public partial class Add_Precent : Form
    {
        Requests f2 = new Requests();
        public Add_Precent()
        {
            InitializeComponent();
        }


        private void Add_Precent_Load(object sender, EventArgs e)
        {
            f2.con();
            this.ControlBox = false;
        }
        //перекраска в зеленый цвет
        #region
        private void button3_Click(object sender, EventArgs e)
        {
            if(button3.BackColor == Color.White)
            {
                button3.BackColor = Color.Green;
            }
            else
            {
                button3.BackColor = Color.White;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.White)
            {
                button4.BackColor = Color.Green;
            }
            else
            {
                button4.BackColor = Color.White;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.White)
            {
                button5.BackColor = Color.Green;
            }
            else
            {
                button5.BackColor = Color.White;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.BackColor == Color.White)
            {
                button6.BackColor = Color.Green;
            }
            else
            {
                button6.BackColor = Color.White;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.BackColor == Color.White)
            {
                button7.BackColor = Color.Green;
            }
            else
            {
                button7.BackColor = Color.White;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.BackColor == Color.White)
            {
                button8.BackColor = Color.Green;
            }
            else
            {
                button8.BackColor = Color.White;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.BackColor == Color.White)
            {
                button9.BackColor = Color.Green;
            }
            else
            {
                button9.BackColor = Color.White;
            }
        }
        #endregion// перекраска в зеленый цвет

        private void button1_Click(object sender, EventArgs e)
        {         
            string cof = textBox1.Text;
            string opi = textBox2.Text;
            var Moon = Convert.ToDateTime(dateTimePicker2.Value.ToShortDateString());
            var ysd = DateTime.Today;
            string wensday = "";
            //Определение дней недели
            #region
            if (button3.BackColor == Color.Green)
            {
                wensday += button3.Text;
            }
            if (button4.BackColor == Color.Green)
            {
                wensday += button4.Text;
            }
            if (button5.BackColor == Color.Green)
            {
                wensday += button5.Text;
            }
            if (button6.BackColor == Color.Green)
            {
                wensday += button6.Text;
            }
            if (button7.BackColor == Color.Green)
            {
                wensday += button7.Text;
            }
            if (button8.BackColor == Color.Green)
            {
                wensday += button8.Text;
            }
            if (button9.BackColor == Color.Green)
            {
                wensday += button9.Text;
            }
            #endregion
            if (Moon == ysd)
            {
                f2.conn.Open();
                string com = $"INSERT INTO  Percent (Percent,PeriodWeek,Yslovia) VALUES ({cof},\"{wensday}\",\"{opi}\")";
                MySqlCommand command = new MySqlCommand(com, f2.conn);
                command.ExecuteNonQuery();
                f2.conn.Close();
            }
            else
            {
                f2.conn.Open();
                string com = $"INSERT INTO  Percent (Percent,PeriodWeek,ReriodMon,ReriodMoon,Yslovia) VALUES ({cof},\"{wensday}\",\"{ysd.ToString("yyyy-MM-dd")}\",\"{Moon.ToString("yyyy-MM-dd")}\",\"{opi}\")";
                MySqlCommand command = new MySqlCommand(com, f2.conn);
                command.ExecuteNonQuery();
                f2.conn.Close();
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
    }
}
