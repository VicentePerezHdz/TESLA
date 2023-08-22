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
    public partial class Alta_Empleado : Form
    {
        Conexion objeto = new Conexion();
        int resultado=0;
        public Alta_Empleado()
        {
            InitializeComponent();
        }

        private void Alta_Empleado_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'productoTeslaDataSet2.Almacen' Puede moverla o quitarla según sea necesario.
            this.almacenTableAdapter.Fill(this.productoTeslaDataSet2.Almacen);
            llenarCombo();
        }

        public void llenarCombo()
        {
            cmbBox.DisplayMember = "IdAlmacen";

            cmbBox.ValueMember = "IdAlmacen";
            cmbBox.DataSource = objeto.llenardatos();
        }


        public void GuardarDatosEmpleado()
        {
            if (!string.IsNullOrEmpty(txtusuario.Text) && !string.IsNullOrEmpty(txtApellido.Text) && !string.IsNullOrEmpty(txtSalario.Text) && !string.IsNullOrEmpty(cmbBox.Text))
            {
                objeto.guardarEmpleado(txtusuario.Text, txtApellido.Text, txtSalario.Text, cmbBox.Text,ref resultado);
                MessageBox.Show("Se agrego el usuario ", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (resultado == 1)
                {
                    this.Close();

                }
            }
            else
            {
                MessageBox.Show("Favor de Revisar de que toda la informacion este completa antes de guardar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
        private void GuardarRegistro_Click(object sender, EventArgs e)
        {
            GuardarDatosEmpleado();

        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            Panel panel = new Panel();
            panel.Show();
        }
    }
}
