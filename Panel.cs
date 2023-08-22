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
    public partial class Panel : Form
    {
        /// <summary>
        /// TODO: EL METODO HIDE() SE USA PARA OCULTAR EL FORMULARIO 
        /// DESPUES DE LLAMAR AL OTRO FORMULARIO
        /// </summary>
        public Panel()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void controlDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empleado Objeto = new Empleado();
            Objeto.Show();
            this.Hide();
        }

        private void agregarUnNuevoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuario_Alta Alta = new Usuario_Alta();
            Alta.Show();
            this.Hide();
        }

        private void modificarDatosUnUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuario_Modificacion modificacion = new Usuario_Modificacion();
             modificacion.Show();
            this.Hide();
        }

        private void consultarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuario consulta = new Usuario();
            consulta.Show();
            this.Hide();

        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta consultaTeEsta = new Consulta();
            consultaTeEsta.Show();
            this.Hide();
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compras compras = new Compras();
            compras.Show();
            this.Hide();
        }

        private void registrarAUnNuevoEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alta_Empleado alta_Empleado = new Alta_Empleado();
            alta_Empleado.Show();
            this.Hide();
        }
    }
}
