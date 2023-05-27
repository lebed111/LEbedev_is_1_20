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
    public partial class delet_Bullet : Form
    {
        //не начато
        public delet_Bullet()
        {
            InitializeComponent();
        }

        private void delet_Bullet_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
