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
    public partial class Change_Client : Form
    {
        public Change_Client()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Change_Client_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }
    }
}
