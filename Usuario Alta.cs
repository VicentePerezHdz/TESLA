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
    public partial class Usuario_Alta : Form
    {
        Conexion objeto = new Conexion();
        int resultado = 0;
        public Usuario_Alta()
        {
            InitializeComponent();
        }

        private void Usuario_Alta_Load(object sender, EventArgs e)
        {

        }
        public void CargarDatos()
        { 
            if (!string.IsNullOrEmpty(txtnombre.Text) && !string.IsNullOrEmpty(txtusuario.Text) && !string.IsNullOrEmpty(txtpassword1.Text) && !string.IsNullOrEmpty(txtpassword2.Text))
            {
                if (txtpassword1.Text != txtpassword2.Text)
                {
                    MessageBox.Show("La Contraseña no coincide", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    objeto.GuardarUsuario(txtnombre.Text, txtpassword1.Text, txtusuario.Text, "1", ref resultado);

                    MessageBox.Show("Se agrego el usuario ", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (resultado==1) {
                        this.Close();
                    
                    }
                }
            }
            else
            {
                MessageBox.Show("Favor de revisar los datos antes de guardar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            Panel panel = new Panel();
            panel.Show();
        }
    }
}
