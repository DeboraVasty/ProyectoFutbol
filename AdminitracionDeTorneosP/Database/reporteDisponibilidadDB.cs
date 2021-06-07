using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using AdminitracionDeTorneosP.Model;

namespace AdminitracionDeTorneosP.Database
{
   public class reporteDisponibilidadDB
    {
        private string connectionString = "Server=LAPTOP-PM9QCVMQ\\SQLEXPRESS;Database=PROYECTO_TORNEOS;User Id=capacitacion;Password=123456;"; // Conectando a la base de datos SQL


        //metodo para traer los horarios de lunes a viernes, horarios de i9nicoi de jornada y fin de jornada
        public string[] captar_info_horas_jornadas()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand("select*from horarios", connection);
                //lee lo que esta en la base de datos
                SqlDataReader dr = sql.ExecuteReader();

                string[] resultado = null;
                while (dr.Read())
                {
                    string[] datos =
                    {
                        //Guarda lo que esta en la posicion 1 de la tabla
                        //nombre de torneo
                        dr[1].ToString(),
                        dr[2].ToString(),
                        dr[3].ToString(),
                        dr[4].ToString(),
                        dr[5].ToString(),
                        dr[6].ToString(),
                        dr[7].ToString(),
                        dr[8].ToString(),
                        dr[9].ToString(),
                        dr[10].ToString(),
                        dr[11].ToString(),
                        dr[12].ToString(),
                        dr[13].ToString(),
                         dr[14].ToString()

                    };
                    resultado = datos;
                }
                connection.Close();
                return resultado;

            }
        }
        public void GetCanchas(ComboBox cbx)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cbx.Items.Clear();
                connection.Open();
                //Query de consulta para obtener equipos
                SqlCommand sql = new SqlCommand("	SELECT * FROM CANCHA where Disponibilidad='Disponible'", connection);
                //Lectura de datos y agregar al combo box los datos
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    //Agregar registros al combo box
                    cbx.Items.Add($"{dr[1]}");
                }
                connection.Close();
            }
        }




        /*  public reporteDisponibilidad canchasHoras (DateTime fechaInicio,DateTime fechaFin,string nombreCancha)
          {
              reporteDisponibilidad horario = new reporteDisponibilidad();
              string query = "exec canchashoras  @fechaInicio, @fechaFin, @nombreCancha";
              using (SqlConnection conexion = new SqlConnection(connectionString))
              {
                  SqlCommand sql = new SqlCommand(query, conexion);
                  sql.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                  sql.Parameters.AddWithValue("@fechaFin", fechaFin);
                  sql.Parameters.AddWithValue("@nombreCancha", nombreCancha);


                  try
                  {
                      conexion.Open();
                      SqlDataReader reader = sql.ExecuteReader();
                      reader.Read(); //leer solo un registro (read)
                      horario. = reader.GetInt32(0);
                      horario.nombres = reader.GetString(1);
                      horario.apellidos = reader.GetString(2);
                      horario.nit = reader.GetString(3);
                      horario.telefonos = reader.GetString(4);
                      horario.activo = reader.GetString(5);

                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show("Error al obtener solo un registro de la base de datos " + ex.Message);
                  }
                  return clientee;
              }
          }*/


        public List<reporteDisponibilidad>horariosCanchas(DateTime fechaInicio, DateTime fechaFin, string nombre)
        {
            List<reporteDisponibilidad> disponibilidad = new List<reporteDisponibilidad>();
            string query = "exec  canchashoras  @fechaInicio, @fechaFin, @nombreCancha ";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {

                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                sql.Parameters.AddWithValue("@fechaFin", fechaFin);
                sql.Parameters.AddWithValue("@nombreCancha", nombre);

                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        reporteDisponibilidad dispo = new reporteDisponibilidad();
                        dispo.fecha = reader.GetDateTime(2);
                        dispo.horaInicio = reader.GetTimeSpan(3);
                        dispo.horaFin = reader.GetTimeSpan(4);
                        
                       
                       
                        disponibilidad.Add(dispo);
                    }
                    reader.Close();
                    conexion.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la base de datos" + ex.Message);
                }
            }
            return disponibilidad;
        }


        public List<reporteDisponibilidad> horariosCanchas2(DateTime fechaInicio, DateTime fechaFin, string nombre)
        {
            List<reporteDisponibilidad> disponibilidad = new List<reporteDisponibilidad>();
            string query = "exec  canchashoras2  @fechaInicio, @fechaFin, @nombreCancha ";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {

                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                sql.Parameters.AddWithValue("@fechaFin", fechaFin);
                sql.Parameters.AddWithValue("@nombreCancha", nombre);

                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        reporteDisponibilidad dispo = new reporteDisponibilidad();
                        dispo.fecha = reader.GetDateTime(2);
                        dispo.horaInicio = reader.GetTimeSpan(3);
                        dispo.horaFin = reader.GetTimeSpan(4);



                        disponibilidad.Add(dispo);
                    }
                    reader.Close();
                    conexion.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la base de datos" + ex.Message);
                }
            }
            return disponibilidad;
        }


        
    }
}
