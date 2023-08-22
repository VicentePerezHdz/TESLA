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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        Conexion objeto = new Conexion();
        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        public void AccederPanel()
        {
            int ID = 0,EstatusActivo=0;
            Panel obj = new Panel();

           
            //Hacemos negacion de que los valores  NO vengan vacios para que pueda
            //Acceder a la clase conexion 
            //ObtenerTodoStblusuario es un metodo sobrecargado lo que quiere decir
            // que un metodo se puede llamar igual sin embargo puede recibir parametros o no
            if (!String.IsNullOrEmpty(txtusuario.Text) && !String.IsNullOrEmpty(txtpassword.Text))
            {
                objeto.ObtenerTodoStblusuario(txtusuario.Text.Trim(), txtpassword.Text.Trim());
              //  UsuarioID Activo
                foreach (DataRow dataRow in objeto.ObtenerTodoStblusuario(txtusuario.Text.Trim(), txtpassword.Text.Trim()).Rows)
                {
                   ID=Convert.ToInt32(  dataRow["UsuarioID"].ToString());
                    EstatusActivo= Convert.ToInt32(dataRow["Activo"].ToString());
                }
                //SI todo sale Bien 
                //Es decir si  nos trae un ID y si ese Id Esta con EStatus Activo en la BD
                //Mostramos el Menu 
                //Y ocultamos el Formulario Login
                if (ID != 0 && EstatusActivo!=0) 
                {
                    //Mostramos el Panel
                    obj.Show();
                    this.Hide();
                }
            }
            //De lo contrario Mostramos un Mensaje
            else
            {
                MessageBox.Show("Favor de Verificar los datos Introducidos", "Advertencia");
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AccederPanel();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
