using System;
using System.Windows.Forms;
namespace ProductoTesla
{
    public partial class Agregar_Articulo : Form
    {
        Conexion objeto = new Conexion();
        public Agregar_Articulo()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            GuardarProducto();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();

            Panel panel = new Panel();
            panel.Show();
        }


        private void GuardarProducto()
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text) && !string.IsNullOrEmpty(txtNombreArticuo.Text) && !string.IsNullOrEmpty(Cantidad.Text) && !string.IsNullOrEmpty(txtPrecio.Text))
            {
                objeto.guardarEnAlmacen(txtCodigo.Text, txtNombreArticuo.Text, txtDescripcion.Text, Cantidad.Text, txtPrecio.Text, "1");
            }
            else
            {
                MessageBox.Show("Favor de Revisar de que toda la informacion este completa antes de guardar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #region Validaciones TextBox
        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            double d = Convert.ToDouble(txtPrecio.Text);

            txtPrecio.Text = d.ToString("0000.00");
        }

        private void Cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }
        #endregion
    }
}
