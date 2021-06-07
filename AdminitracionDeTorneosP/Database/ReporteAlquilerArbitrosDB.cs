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

    public class ReporteAlquilerArbitrosDB
    {
        //Conexion a Base de Datos
        private string connectionString = "Server=LAPTOP-PM9QCVMQ\\SQLEXPRESS;Database=PROYECTO_TORNEOS;User Id=capacitacion;Password=123456;";

        public List<reporteAlquilerArbitros> getalquiler(DateTime fechaInicio, DateTime fechaFin)
        {
            List<reporteAlquilerArbitros> listadoAlquiler = new List<reporteAlquilerArbitros>();
            //query para obtner daos 
            string query = "exec alquilerReporteArbitro @fechaInicio,@fechaFin ";
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
                        reporteAlquilerArbitros model = new reporteAlquilerArbitros();
                        model.Nombre_Arbitro = reader.GetString(1);
                        model.Apellido_Arbitro = reader.GetString(2);
                        model.Año = reader.GetInt32(3);
                        model.Mes = reader.GetInt32(4);
                        model.dia = reader.GetInt32(5);
                        model.Monto = reader.GetDecimal(6);
                        listadoAlquiler.Add(model);
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
            return listadoAlquiler;
        }

      
    }
}
