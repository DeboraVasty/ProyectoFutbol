using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminitracionDeTorneosP.Model;
using System.Data.SqlClient;
using System.Windows.Forms;
using AdminitracionDeTorneosP.Database;

namespace AdminitracionDeTorneosP.Database
{
   public class bitacoraDB
    {
        //Conexion a Base de Datos
        private string connectionString = "Server=LAPTOP-PM9QCVMQ\\SQLEXPRESS;Database=PROYECTO_TORNEOS;User Id=capacitacion;Password=123456;";

        // metodo ingreso de Usuarios
        public void Insertar_bitacora(bitacora bitacoraI)
        {

            string query = "exec ingresar_bitacora @usuario,@accion";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@usuario", bitacoraI.usuario);
                sql.Parameters.AddWithValue("@accion", bitacoraI.accion);
                try
                {
                    conexion.Open();
                    sql.ExecuteNonQuery();
                    conexion.Close();
                  //  MessageBox.Show("Usuario ingresado " + " " + bitacoraI.usuario);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("error en el ingreso" + ex.Message);
                }

            }

        }


        //método para btener el tiempo de uso de la cancha por rango de fecha 
        public List<bitacora> getBitacora(DateTime fechaInicio, DateTime fechaFin,string usuario)
        {
            List<bitacora> listadobitacora = new List<bitacora>();
            //query para obtner daos 
            string query = "exec reporteBitacora @fechaInicio,@fechaFin,@usuario ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                sql.Parameters.AddWithValue("@fechaFin", fechaFin);
                sql.Parameters.AddWithValue("@usuario", usuario);

                try
                {
                    connection.Open();
                    //crear lector de datos 
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        //lectura de datos 
                        bitacora model = new bitacora();
                        model.usuario = reader.GetString(1);
                        model.accion = reader.GetString(2);
                        model.fecha = reader.GetDateTime(3);
                        listadobitacora.Add(model);
                    }
                    reader.Close();
                    connection.Close();
                }
                //informar de algún problema 
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos desde la base de datos. " + ex.Message);
                }
            }
            //retornar lista obtenida
            return listadobitacora;
        }




    
    }
}
