using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using AdminitracionDeTorneosP.Model;

namespace AdminitracionDeTorneosP.Database
{
   public class ReporteListaJugadoresDB
    {
        private string connectionString = "Server=LAPTOP-PM9QCVMQ\\SQLEXPRESS;Database=PROYECTO_TORNEOS;User Id=capacitacion;Password=123456;"; // Conectando a la base de datos SQL
      
        public List<ReporteListadoJugadores> getJugadores()
        {
            List<ReporteListadoJugadores> listado_jugadores = new List<ReporteListadoJugadores>();
            string query = "Select * from jugador ";
           
            using (SqlConnection connec = new SqlConnection(connectionString))
            {

                SqlCommand sql = new SqlCommand(query, connec);
                try
                {
                    connec.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        ReporteListadoJugadores jugador = new ReporteListadoJugadores();

                        jugador.DPI_Jugador = reader.GetInt64(0);
                        jugador.Nombres = reader.GetString(1);
                        jugador.Apellidos = reader.GetString(2);
                        jugador.Fecha_nac = reader.GetDateTime(3);
                        jugador.Direccion = reader.GetString(4);
                        jugador.Nacionalidad = reader.GetString(5);
                        jugador.Correo = reader.GetString(6);
                        jugador.Telefono = reader.GetString(7);
                        listado_jugadores.Add(jugador);
                    }
                    reader.Close();
                    connec.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al traer los datos en la base de datos" + ex.Message);
                }
            }
            return listado_jugadores;
        }
    }
}
