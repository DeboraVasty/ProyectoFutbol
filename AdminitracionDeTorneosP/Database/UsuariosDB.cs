using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminitracionDeTorneosP.Database;
using AdminitracionDeTorneosP.Model;
using System.Data.SqlClient;

namespace AdminitracionDeTorneosP.Database
{
    public class UsuariosDB
    {

        //Conexion a Base de Datos
        private string connectionString = "Server=LAPTOP-PM9QCVMQ\\SQLEXPRESS;Database=PROYECTO_TORNEOS;User Id=capacitacion;Password=123456;";



        public List<Usuarios> manejousuarios()
        {
            List<Usuarios> usuario = new List<Usuarios>();
            string query = "exec getUsuario ";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {

                SqlCommand sql = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        Usuarios usuarioo = new Usuarios();

                        usuarioo.DPI = reader.GetInt64(0);
                        usuarioo.Nombre = reader.GetString(1);
                        usuarioo.Apellidos = reader.GetString(2);
                        usuarioo.telefono = reader.GetString(3);
                        usuarioo.correo = reader.GetString(4);
                        usuarioo.direccion = reader.GetString(5);
                        usuarioo.puesto = reader.GetString(6);
                        usuarioo.usuario = reader.GetString(7);
                        usuarioo.contraseña = reader.GetString(8);
                        usuarioo.activo = reader.GetString(9);
                        usuarioo.tipo_usuario = reader.GetString(10);



                        usuario.Add(usuarioo);
                    }
                    reader.Close();
                    conexion.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la base de datos" + ex.Message);
                }
            }
            return usuario;
        }


        // metodo ingreso de Usuarios
        public void Insertar_Usuarios(Usuarios nUsuarios)
        {

            string query = "exec insertar_usuarios @dpi,@nombre,@apellidos,@telefono ,@correo,@direccion,@puesto,@usuario,@contraseña,@activo,@tipo_usuario";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@dpi", nUsuarios.DPI);
                sql.Parameters.AddWithValue("@nombre", nUsuarios.Nombre);
                sql.Parameters.AddWithValue("@apellidos", nUsuarios.Apellidos);
                sql.Parameters.AddWithValue("@telefono", nUsuarios.telefono);
                sql.Parameters.AddWithValue("@correo", nUsuarios.correo);
                sql.Parameters.AddWithValue("@direccion", nUsuarios.direccion);
                sql.Parameters.AddWithValue("@puesto", nUsuarios.puesto);
                sql.Parameters.AddWithValue("@usuario", nUsuarios.usuario);
                sql.Parameters.AddWithValue("@contraseña", nUsuarios.contraseña);
                sql.Parameters.AddWithValue("@activo", nUsuarios.activo);
                sql.Parameters.AddWithValue("@tipo_usuario", nUsuarios.tipo_usuario);

                try
                {
                    conexion.Open();
                    sql.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Usuario ingresado " + " " + nUsuarios.Nombre);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("error en el ingreso" + ex.Message);
                }

            }








        }


        //Buscar informacion
        public Usuarios buscar(long? dpi)
        {
            Usuarios usuarioo = new Usuarios();
            string query = "select*from usuario where DPI_usuario=@dpi";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@dpi", dpi);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read(); //leer solo un registro (read)
                    usuarioo.DPI = reader.GetInt64(0);
                    usuarioo.Nombre = reader.GetString(1);
                    usuarioo.Apellidos = reader.GetString(2);
                    usuarioo.telefono = reader.GetString(3);
                    usuarioo.correo = reader.GetString(4);
                    usuarioo.direccion = reader.GetString(5);
                    usuarioo.puesto = reader.GetString(6);
                    usuarioo.usuario = reader.GetString(7);
                    usuarioo.contraseña = reader.GetString(8);
                    usuarioo.activo = reader.GetString(9);
                    usuarioo.tipo_usuario = reader.GetString(10);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener solo un registro de la base de datos " + ex.Message);
                }
                return usuarioo;
            }
        }


        public void actualizar_usuario(long? DPI_usuario,string Nombre, string Apellidos, string telefono, string correo, string direccion, string puesto, string usuario, string contraseña, string activo, string tipo_usuario)
        {
            //update TIPO_PRODUCTO  set nombre =@nombre where TIPO_PRODUCTO=@id

            string query = "exec  actualizar_usuario @dpi, @nombre,@apellidos,@telefono,@correo,@direccion,@puesto,@usuario,@contraseña,@activo,@tipo_usuario";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@dpi", DPI_usuario);
                command.Parameters.AddWithValue("@nombre", Nombre);
                command.Parameters.AddWithValue("@apellidos", Apellidos);
                command.Parameters.AddWithValue("@telefono", telefono);
                command.Parameters.AddWithValue("@correo", correo);
                command.Parameters.AddWithValue("@direccion", direccion);
                command.Parameters.AddWithValue("@puesto", puesto);
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@contraseña", contraseña);
                command.Parameters.AddWithValue("@activo", activo);
                command.Parameters.AddWithValue("@tipo_usuario", tipo_usuario);


                try
                {
                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Actualizacion Realizada ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en actualizacion" + ex.Message);
                }

            }
        }



    }
}
