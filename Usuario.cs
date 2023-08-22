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
    public partial class Usuario : Form
    {
        Conexion objeto = new Conexion();
        public Usuario()
        {
            InitializeComponent();
        }

        public void CargarDatos() 
        {
            
            dtgusuarios.DataSource= objeto.ObtenerTodoStblusuario();

            
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Panel panel = new Panel();
            panel.Show();
        }
    }
}
