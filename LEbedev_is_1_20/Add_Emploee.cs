using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEbedev_is_1_20
{
    public partial class Add_Emploee : Form
    {
        public Add_Emploee()
        {
            InitializeComponent();
        }

        private void Add_Emploee_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = $"{textBox1.Text.Length}/255";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
