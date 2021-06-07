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
   public class horariosDB
    {
        //Conexion a Base de Datos
        private string connectionString = "Server=LAPTOP-PM9QCVMQ\\SQLEXPRESS;Database=PROYECTO_TORNEOS;User Id=capacitacion;Password=123456;";

        public List<horarios> manejoHorarios()
        {
            List<horarios> horariio = new List<horarios>();
            string query = "exec getHorario ";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {

                SqlCommand sql = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        horarios horarioo = new horarios();

                        horarioo.Id_horario = reader.GetInt32(0);
                        horarioo.Lhora_inicio =reader.GetTimeSpan(1);
                        horarioo.Lhora_fin = reader.GetTimeSpan(2);
                        horarioo.Mhora_inicio = reader.GetTimeSpan(3);
                        horarioo.Mhora_fin = reader.GetTimeSpan(4);
                        horarioo.Mihora_inicio = reader.GetTimeSpan(5);
                        horarioo.Mihora_fin = reader.GetTimeSpan(6);
                        horarioo.Jhora_inicio = reader.GetTimeSpan(7);
                        horarioo.Jhora_fin = reader.GetTimeSpan(8);
                        horarioo.Vhora_inicio = reader.GetTimeSpan(9);
                        horarioo.Vhora_fin = reader.GetTimeSpan(10);
                        horarioo.Shora_inicio = reader.GetTimeSpan(11);
                        horarioo.Shora_fin = reader.GetTimeSpan(12);
                        horarioo.Dhora_inicio = reader.GetTimeSpan(13);
                        horarioo.Dhora_fin = reader.GetTimeSpan(14);


                        horariio.Add(horarioo);
                    }
                    reader.Close();
                    conexion.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la base de datos" + ex.Message);
                }
            }
            return horariio;
        }


        //Buscar informacion
        public horarios buscar(int? Id_horario)
        {
            horarios horarioo = new horarios();
            string query = "select*from horarios where Id_horario=@Id_horario";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@Id_horario", Id_horario);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read(); //leer solo un registro (read)

                    horarioo.Id_horario = reader.GetInt32(0);
                    horarioo.Lhora_inicio = reader.GetTimeSpan(1);
                    horarioo.Lhora_fin = reader.GetTimeSpan(2);
                    horarioo.Mhora_inicio = reader.GetTimeSpan(3);
                    horarioo.Mhora_fin = reader.GetTimeSpan(4);
                    horarioo.Mihora_inicio = reader.GetTimeSpan(5);
                    horarioo.Mihora_fin = reader.GetTimeSpan(6);
                    horarioo.Jhora_inicio = reader.GetTimeSpan(7);
                    horarioo.Jhora_fin = reader.GetTimeSpan(8);
                    horarioo.Vhora_inicio = reader.GetTimeSpan(9);
                    horarioo.Vhora_fin = reader.GetTimeSpan(10);
                    horarioo.Shora_inicio = reader.GetTimeSpan(11);
                    horarioo.Shora_fin = reader.GetTimeSpan(12);
                    horarioo.Dhora_inicio = reader.GetTimeSpan(13);
                    horarioo.Dhora_fin = reader.GetTimeSpan(14);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener solo un registro de la base de datos " + ex.Message);
                }
                return horarioo;
            }
        }

        public void actualizar_Horarios(int? Id_horario , TimeSpan Lhora_inicio, TimeSpan Lhora_fin,TimeSpan Mhora_inicio,TimeSpan Mhora_fin , TimeSpan Mihora_inicio, TimeSpan Mihora_fin, TimeSpan Jhora_inicio, TimeSpan Jhora_fin, TimeSpan Vhora_inicio, TimeSpan Vhora_fin, TimeSpan Shora_inicio, TimeSpan Shora_fin, TimeSpan Dhora_inicio, TimeSpan Dhora_fin)
        {
            

            string query = "exec  acutalizar_horario @Id_horario,@Lhora_inicio ,@Lhora_fin , @Mhora_inicio, " +
                "@Mhora_fin, @Mihora_inicio , @Mihora_fin, @Jhora_inicio , @Jhora_fin , @Vhora_inicio," +
                " @Vhora_fin , @Shora_inicio , @Shora_fin , @Dhora_inicio , @Dhora_fin ";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@Id_horario", Id_horario);
                command.Parameters.AddWithValue("@Lhora_inicio", Lhora_inicio);
                command.Parameters.AddWithValue("@Lhora_fin ", Lhora_fin);
                command.Parameters.AddWithValue("@Mhora_inicio", Mhora_inicio);
                command.Parameters.AddWithValue("@Mhora_fin", Mhora_fin);
                command.Parameters.AddWithValue("@Mihora_inicio ",Mihora_inicio);
                command.Parameters.AddWithValue("@Mihora_fin", Mihora_fin);
                command.Parameters.AddWithValue("@Jhora_inicio",Jhora_inicio);
                command.Parameters.AddWithValue("@Jhora_fin", Jhora_fin);
                command.Parameters.AddWithValue("@Vhora_inicio", Vhora_inicio);
                command.Parameters.AddWithValue("@Vhora_fin", Vhora_fin);
                command.Parameters.AddWithValue("@Shora_inicio", Shora_inicio);
                command.Parameters.AddWithValue("@Shora_fin", Shora_fin);
                command.Parameters.AddWithValue("@Dhora_inicio", Dhora_inicio);
                command.Parameters.AddWithValue("@Dhora_fin", Dhora_fin);

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
