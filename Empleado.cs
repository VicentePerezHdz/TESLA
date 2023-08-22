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
    public partial class Empleado : Form
    {
        public Empleado()
        {
            InitializeComponent();
        }
        Conexion objeto = new Conexion();

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Panel panel = new Panel();
            panel.Show();
        }

        private void Empleado_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            objeto.ObtenerTodoSEmpleado();

            foreach (DataRow dataRow in objeto.ObtenerTodoSEmpleado().Rows)
            {
                //dtgusuarios.Rows.Add(dataRow);

                int renglon = dtgusuarios.Rows.Add();

                //dataRow["UsuarioID"].ToString();

                dtgusuarios.Rows[renglon].Cells["nombre"].Value = dataRow["Nombre"].ToString();
                dtgusuarios.Rows[renglon].Cells["apellidos"].Value = dataRow["Nombre"].ToString();
                dtgusuarios.Rows[renglon].Cells["Salario"].Value = dataRow["Nombre"].ToString();
                dtgusuarios.Rows[renglon].Cells["Almacen"].Value = dataRow["Nombre"].ToString();


            }

            //dtgusuarios.Rows[renglon].Cells["nombre"].Value = leer.GetString(leer.GetOrdinal("nombre"));
            //dtgusuarios.Rows[renglon].Cells["apellidos"].Value = leer.GetString(leer.GetOrdinal("apellidos"));
            ////              dtgusuarios.Rows[renglon].Cells["edad"].Value = leer.GetInt32(leer.GetOrdinal("edad"));
            ////  dtgusuarios.Rows[renglon].Cells["sexo"].Value = leer.GetString(leer.GetOrdinal("sexo"));
            //dtgusuarios.Rows[renglon].Cells["puesto"].Value = leer.GetString(leer.GetOrdinal("puesto"));
            //dtgusuarios.DataSource = objeto.ObtenerTodoSEmpleado();
        }
    }
}
