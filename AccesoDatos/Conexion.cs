using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace ProductoTesla
{
    class Conexion
    {
        public SqlConnection con;
        public DataView vista;

        private static string astrCadenaConexion = ConfigurationSettings.AppSettings["SistemaConnectionString"].ToString();
        public Conexion()
        {
            Iniciar();

            //vista = lista().DefaultView;
        }

        public void Iniciar()
        {
            con = new SqlConnection();
            con = new SqlConnection(astrCadenaConexion);


        }
        public SqlConnection getcon
        {
            get
            {
                return con;
            }
        }

        public DataTable ObtenerTodoSEmpleado()
        {
            SqlDataAdapter ds = new SqlDataAdapter("select Nombre,Apellidos,Salario,IdAlmacen from Empleado", getcon);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            return dt;
        }


        public DataTable ObtenerTodoSAlmacen()
        {
            SqlDataAdapter ds = new SqlDataAdapter("SELECT  IdAlmacen FROM  Almacen where activo=1", getcon);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            return dt;
        }

        public DataTable ObtenerTodoAlmacen()
        {
            SqlDataAdapter ds = new SqlDataAdapter("SELECT   *FROM  Almacen ", getcon);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            return dt;
        }
        public DataTable ObtenerTodoStblusuario(string txtusuario, string txtpassword)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter ds = new SqlDataAdapter("SELECT *FROM  tblusuario WHERE Usuario='" + txtusuario + "'AND Contrasenia='" + txtpassword + "'AND ACTIVO=1", getcon);

                ds.Fill(dt);
            }
            catch (Exception e)
            {
            }
            return dt;
        }

        public DataTable ObtenerTodoStblusuario()
        {
            SqlDataAdapter ds = new SqlDataAdapter("SELECT Usu.Usuario,Usu.Correo,Usu.Activo FROM  tblusuario  Usu  INNER JOIN tblusuariorol  ROL ON Usu.UsuarioRolID=ROL.UsuarioRolID", getcon);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            return dt;
        }




        public DataView filtrar(string RFC)
        {
            vista.RowFilter = "RFC'" + RFC + "%'";
            return vista;
        }


        public void guardarEmpleado(string  Nombre,string Apellidos,string Salario,string IdAlmacen,ref int Resultado)
        {
            int IntIdAlmacen = 0;
            //operador Ternario parecido if, else el cual valida si  IdAlmacen viene null o vacio la 
            //variable IntIdAlmacen es igual a 0 IntIdAlmacen=0
            IntIdAlmacen = string.IsNullOrEmpty(IdAlmacen) ? Convert.ToInt32(IdAlmacen) : 0;
            if (con.State != ConnectionState.Open)
            {

       
                con.Open();
                SqlCommand comando = new SqlCommand("insert into  Empleado (Nombre,Apellidos,Edad,Domicilio,Colonia,Sexo,Telefono,Email,Salario,IdAlmacen)  VALUES (@Nombre,@Apellidos,@Edad,@Domicilio,@Colonia,@Sexo,@Telefono,@Email,@Salario,@IdAlmacen)", con);
                //SqlCommand comando1 = new SqlCommand("insert into  (UsuarioRolID,Usuario,Contrasenia ,Correo,Activo) tblusuarioVALUES(@UsuarioRolID,@Usuario,@Contrasenia ,@Correo,@Activo)", con);
                //SqlCommand comando2 = new SqlCommand("insert into Datos2_Empleado (Nombre, Apellidos, Fecha_Ingreso, Fecha_Vacaciones, Hora_Entrada, Hora_Salida, Ocupacion, Departamento) values(@nombre, @apellidos, @fecha_ingreso, @fecha_vacaciones, @hora_entrada, @hora_salida, @ocupacion, @departamento)", con);

                //string fecha = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString();

                comando.Parameters.AddWithValue("nombre", Nombre);
                comando.Parameters.AddWithValue("Apellidos", Apellidos);
                comando.Parameters.AddWithValue("Edad", "");
                comando.Parameters.AddWithValue("Domicilio", "");
                comando.Parameters.AddWithValue("colonia", "");
                comando.Parameters.AddWithValue("Sexo", "");
                comando.Parameters.AddWithValue("Telefono", "");
                comando.Parameters.AddWithValue("Email", "");
                comando.Parameters.AddWithValue("Salario",float.Parse(Salario));
                comando.Parameters.AddWithValue("IdAlmacen", Convert.ToInt32(IntIdAlmacen) );






                Resultado= comando.ExecuteNonQuery();
            }
            else
            {
                SqlCommand comando = new SqlCommand("insert into  Empleado (Nombre,Apellidos,Edad,Domicilio,Colonia,Sexo,Telefono,Email,Salario,IdAlmacen)  VALUES (@Nombre,@Apellidos,@Edad,@Domicilio,@Colonia,@Sexo,@Telefono,@Email,@Salario,@IdAlmacen)", con);

                comando.Parameters.AddWithValue("nombre", Nombre);
                comando.Parameters.AddWithValue("Apellidos", Apellidos);
                comando.Parameters.AddWithValue("Edad", "");
                comando.Parameters.AddWithValue("Domicilio", "");
                comando.Parameters.AddWithValue("colonia", "");
                comando.Parameters.AddWithValue("Sexo", "");
                comando.Parameters.AddWithValue("Telefono", "");
                comando.Parameters.AddWithValue("Email", "");
                comando.Parameters.AddWithValue("Salario", float.Parse(Salario));
                comando.Parameters.AddWithValue("IdAlmacen", Convert.ToInt32(IntIdAlmacen));



                Resultado = comando.ExecuteNonQuery();
            }
            
        }


        public void GuardarUsuario(string Usuario, string Contrasenia, string Correo, string IdAlmacen, ref int Resultado)
        {

            int resultado = 0;
            if (con.State != ConnectionState.Open)
            {
                this.con = new SqlConnection(astrCadenaConexion);
                con.Open();
                SqlCommand comando = new SqlCommand("insert into tblusuario (UsuarioRolID,Usuario,Contrasenia ,Correo,Activo) VALUES(@UsuarioRolID,@Usuario,@Contrasenia ,@Correo,@Activo)", con);

                //string fecha = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString();
                comando.Parameters.AddWithValue("UsuarioRolID", 1);

                comando.Parameters.AddWithValue("Usuario", Usuario);
                comando.Parameters.AddWithValue("Contrasenia", Contrasenia);

                comando.Parameters.AddWithValue("Correo", Correo);
                comando.Parameters.AddWithValue("Activo", 1);


                Resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand comando = new SqlCommand("insert into tblusuario  (UsuarioRolID,Usuario,Contrasenia ,Correo,Activo) VALUES(@UsuarioRolID,@Usuario,@Contrasenia ,@Correo,@Activo)", con);

                //string fecha = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString();
                comando.Parameters.AddWithValue("UsuarioRolID", 1);

                comando.Parameters.AddWithValue("nombre", Usuario);
                comando.Parameters.AddWithValue("Contrasenia", Contrasenia);

                comando.Parameters.AddWithValue("Correo", Correo);
                comando.Parameters.AddWithValue("Activo", 1);



                Resultado  = comando.ExecuteNonQuery();
                con.Close();

            }
        }

        public void guardarEnAlmacen(string Codigo, string Nombre, string Descripcion, string Cantidad, string PrecioUnidad, string Activo)
        {
            if (con.State != ConnectionState.Open)
            {
                this.con = new SqlConnection(astrCadenaConexion);
                con.Open();
                SqlCommand comando = new SqlCommand("insert into  Almacen  (Codigo ,Fecha_Ingreso ,Nombre ,Descripcion,Cantidad,PrecioUnidad,Activo) Values(@Codigo, @Fecha_Ingreso, @Nombre, @Descripcion, @Cantidad, @PrecioUnidad,@Activo)", con);

                //string fecha = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString();

                comando.Parameters.AddWithValue("Codigo", Codigo);
                comando.Parameters.AddWithValue("Fecha_Ingreso", DateTime.Now.ToString("MM-dd-yyyy"));
                comando.Parameters.AddWithValue("Nombre", Nombre);
                comando.Parameters.AddWithValue("Cantidad", Convert.ToInt32(Cantidad));
                comando.Parameters.AddWithValue("PrecioUnidad", float.Parse(PrecioUnidad));
                comando.Parameters.AddWithValue("Activo", 1);


                comando.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand comando = new SqlCommand("insert into  Almacen (Codigo ,Fecha_Ingreso ,Nombre ,Descripcion,Cantidad,PrecioUnidad,Activo) Values(@Codigo, @Fecha_Ingreso, @Nombre, @Descripcion, @Cantidad, @PrecioUnidad,@Activo)", con);

                //string fecha = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString();

                comando.Parameters.AddWithValue("Codigo", Codigo);
                comando.Parameters.AddWithValue("Fecha_Ingreso", DateTime.Now.ToString("MM-dd-yyyy"));
                comando.Parameters.AddWithValue("Nombre", Nombre);
                comando.Parameters.AddWithValue("Cantidad", Convert.ToInt32(Cantidad));
                comando.Parameters.AddWithValue("PrecioUnidad", float.Parse(PrecioUnidad));
                comando.Parameters.AddWithValue("Activo", 1);


                comando.ExecuteNonQuery();
                con.Close();
            }
        }


        public string ActualizarEnAlmacen(string TextBoxProducto, string astrCantidad)
        {
            int Result = 0;
            int Existencia = 0, Cantidad = 0, Precio = 0;
            SqlDataReader reader;
            SqlDataReader readerProducto;
            string Producto = TextBoxProducto;
            string Consulta = string.Empty;
            SqlCommand EjecutaExistencia = null;
            Cantidad = Convert.ToInt32(astrCantidad);//Aqui va la cantidad
            string Concepto = "Salida";
            string Mensaje = string.Empty;
            if (con.State != ConnectionState.Open)
            {
                this.con = new SqlConnection(astrCadenaConexion);
                this.con.Open();
                Consulta = string.Empty;
                EjecutaExistencia = null;
                Consulta = "select *from ALMACEN where Nombre='" + Producto + "'";
                EjecutaExistencia = new SqlCommand(Consulta, con);

                reader = EjecutaExistencia.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    Existencia = reader.GetInt32(5);




                    if (Existencia >= Cantidad)
                    {   //Aqui se hace la diferencia de lo que se tiene en la base de datos
                        //contra lo que estamos comprando
                        Existencia -= Cantidad;

                        EjecutaExistencia = new SqlCommand("UPDATE Almacen SET  ACTIVO=0 Existencia='" + Existencia + "' WHERE Nombre='" + Producto + "'", con);
                        reader = EjecutaExistencia.ExecuteReader();
                        if (reader.HasRows)
                        {
                            EjecutaExistencia = new SqlCommand("insert into  (Codigo ,Fecha_Ingreso ,Nombre ,Descripcion,Cantidad,PrecioUnidad,Activo)Almacen Values(@Codigo, @Fecha_Ingreso, @Nombre, @Descripcion, @Cantidad, @PrecioUnidad,1)", con);
                            Result = EjecutaExistencia.ExecuteNonQuery();
                        }

                        Mensaje = "Se  ha realizado el proceso de compra ";
                    }
                    else
                    {
                        Mensaje = "No hay producto suficiente, solo hay en existencia: " + Existencia + "";
                        con.Close();
                    }

                }
            }
            else
            {
                con.Open();

                Consulta = string.Empty;
                EjecutaExistencia = null;
                Consulta = "select *from ALMACEN where Nombre='" + Producto + "'";
                EjecutaExistencia = new SqlCommand(Consulta, con);

                reader = EjecutaExistencia.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    Existencia = reader.GetInt32(5);




                    if (Existencia >= Cantidad)
                    {   //Aqui se hace la diferencia de lo que se tiene en la base de datos
                        //contra lo que estamos comprando
                        Existencia -= Cantidad;

                        EjecutaExistencia = new SqlCommand("UPDATE Almacen SET  ACTIVO=0 Existencia='" + Existencia + "' WHERE Nombre='" + Producto + "'", con);
                        reader = EjecutaExistencia.ExecuteReader();
                        if (reader.HasRows)
                        {
                            EjecutaExistencia = new SqlCommand("insert into  Almacen  (Codigo ,Fecha_Ingreso ,Nombre ,Descripcion,Cantidad,PrecioUnidad,Activo) Values(@Codigo, @Fecha_Ingreso, @Nombre, @Descripcion, @Cantidad, @PrecioUnidad,1)", con);
                            Result = EjecutaExistencia.ExecuteNonQuery();
                        }

                        Mensaje = "Se  ha realizado el proceso de compra ";
                    }
                    else
                    {
                        Mensaje = "No hay producto suficiente, solo hay en existencia: " + Existencia + "";
                        con.Close();
                    }


                }
                else
                {
                    Mensaje = "No existe el Producto.";
                    con.Close();
                }
                Existencia = Cantidad = 0;


            }
            return Mensaje;

        }




        public DataTable llenardatos()
        {
            DataTable tb = new DataTable();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Almacen", con);
            da.Fill(tb);
            con.Close();

            return tb;
        }


    }
}
