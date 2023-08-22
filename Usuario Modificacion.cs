using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductoTesla
{
    public partial class Usuario_Modificacion : Form
    {
        public Usuario_Modificacion()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            Panel panel = new Panel();
            panel.Show();
        }
    }
}
