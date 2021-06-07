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
   public class IngresosCanchasDB
    {
        //Conexion a Base de Datos
        private string connectionString = "Server=LAPTOP-PM9QCVMQ\\SQLEXPRESS;Database=PROYECTO_TORNEOS;User Id=capacitacion;Password=123456;";


        public List<IngresosCanchas> getingresosCanchas(DateTime fechaInicio, DateTime fechaFin)
        {
            List<IngresosCanchas> listadoIngresos = new List<IngresosCanchas>();
            //query para obtner daos 
            string query = "exec reporteCanchasAlquileres @fechaInicio,@fechaFin ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                sql.Parameters.AddWithValue("@fechaFin", fechaFin);
               

                try
                {
                    connection.Open();
                    //crear lector de datos 
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        //lectura de datos 
                        IngresosCanchas model = new IngresosCanchas();
                        model.Nombre_Cancha = reader.GetString(1);
                        model.Año = reader.GetInt32(2);
                        model.Mes = reader.GetInt32(3);
                        model.Dia = reader.GetInt32(4);
                        model.Monto = reader.GetDecimal(5);

                        listadoIngresos.Add(model);
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
            return listadoIngresos;
        }

    }
}
