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
    public class AlquilerCanchaDB
    {
        //Conexion a Base de Datos
        private string connectionString = "Server=LAPTOP-PM9QCVMQ\\SQLEXPRESS;Database=PROYECTO_TORNEOS;User Id=capacitacion;Password=123456;";
        //mostrar todos los datos de la trabla
        public List<AlquilarCanchas> manejoCanchas()
        {
            List<AlquilarCanchas> alquilar = new List<AlquilarCanchas>();
            string query = "exec getAlquiler ";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {

                SqlCommand sql = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        AlquilarCanchas alquiler = new AlquilarCanchas();
                        alquiler.id_alquiler = reader.GetInt32(0);
                        alquiler.DPI = reader.GetInt64(1);
                        alquiler.Nombre = reader.GetString(2);
                        alquiler.Apellidos = reader.GetString(3);
                        alquiler.telefono = reader.GetString(4);
                        alquiler.correo = reader.GetString(5);
                        alquiler.fecha = reader.GetDateTime(6);
                        alquiler.HoraInicio = reader.GetTimeSpan(7);
                        alquiler.HoraFinal = reader.GetTimeSpan(8);
                        alquiler.cod_cancha = reader.GetInt32(9);
                        alquiler.pago_cancha= reader.GetDecimal(10);
                        alquiler.cod_arbitro = reader.GetInt64(11);
                        alquiler.pago_arbitro = reader.GetDecimal(12);
                        alquilar.Add(alquiler);
                    }
                    reader.Close();
                    conexion.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la base de datos" + ex.Message);
                }
            }
            return alquilar;
        }


        // metodo ingreso de alquiler
        public void Insertar_alquilerCancha(AlquilarCanchas alquilarC)
        {
            
            string query = "exec insertar_Alquileres @dpi, @nombre,@apellidos,@telefono ,@correo,@fecha,@HoraInicio,@HoraFinal,@cod_cancha,@pago_cancha,@cod_arbitro,@pago_arbitro";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@dpi", alquilarC.DPI);
                sql.Parameters.AddWithValue("@nombre", alquilarC.Nombre);
                sql.Parameters.AddWithValue("@apellidos", alquilarC.Apellidos);
                sql.Parameters.AddWithValue("@telefono", alquilarC.telefono);
                sql.Parameters.AddWithValue("@correo", alquilarC.correo);
                sql.Parameters.AddWithValue("@fecha", alquilarC.fecha);
                sql.Parameters.AddWithValue("@HoraInicio", alquilarC.HoraInicio);
                sql.Parameters.AddWithValue("@HoraFinal", alquilarC.HoraFinal);
                sql.Parameters.AddWithValue("@cod_cancha", alquilarC.cod_cancha);
                sql.Parameters.AddWithValue("@pago_cancha", alquilarC.pago_cancha);
                sql.Parameters.AddWithValue("@cod_arbitro", alquilarC.cod_arbitro);
                sql.Parameters.AddWithValue("@pago_arbitro", alquilarC.pago_arbitro);

                try
                {
                    conexion.Open();
                    sql.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Cliente ingresado: " + " " + alquilarC.Nombre);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("error en el ingreso" + ex.Message);
                }

            }

        }


        public void eliminar_alquiler(int? id)
        {
            // delete from cliente where TIPO_PRODUCTO=@id
            string query = "exec eliminarAlquiler  @id";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Se a eliminado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error en eliminar " + ex.Message);
                }

            }
        }



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

        public void Buscar_canchas_disponibles(ComboBox cb, DateTime fecha_reservacion, TimeSpan hora_inicio, TimeSpan horafinal)
        {
            string query = "exec canchas_disponibles @fecha_reservaciones,@hora_inicio_reservacion,@hora_fin_reservacion";
            using (SqlConnection connec = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@fecha_reservaciones", fecha_reservacion);
                sql.Parameters.AddWithValue("@hora_inicio_reservacion", hora_inicio);
                sql.Parameters.AddWithValue("@hora_fin_reservacion", horafinal);
                cb.Items.Clear();
                connec.Open();
                SqlDataReader reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    cb.Items.Add(reader[1].ToString());
                }


                connec.Close();

            }
        }


       //metodo para traer los id_de las canchas selecionadas
        public string[] captar_info_id_canchas(string nombre_canchas)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand("select*from CANCHA where Nombre='" + nombre_canchas + "'", connection);
                //lee lo que esta en la base de datos
                SqlDataReader dr = sql.ExecuteReader();

                string[] resultado = null;
                while (dr.Read())
                {
                    string[] datos =
                    {
                        //Guarda lo que esta en la posicion 1 de la tabla
                        //nombre de torneo
                        dr[0].ToString(),
                        dr[1].ToString(),
                        dr[2].ToString(),
                        dr[3].ToString(),
                        dr[4].ToString()



                    };
                    resultado = datos;
                }
                connection.Close();
                return resultado;

            }
        }

        public string[] captar_info_id_arbitros(string nombre_arbitro)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand("select*from ARBITRO where nombres='" + nombre_arbitro + "'", connection);
                //lee lo que esta en la base de datos
                SqlDataReader dr = sql.ExecuteReader();

                string[] resultado = null;
                while (dr.Read())
                {
                    string[] datos =
                    {
                        //Guarda lo que esta en la posicion 1 de la tabla
                        //nombre de torneo
                        dr[0].ToString(),
                        dr[1].ToString(),
                        dr[2].ToString(),
                        dr[3].ToString(),
                        dr[4].ToString(),
                        dr[5].ToString(),
                        dr[6].ToString(),
                        dr[7].ToString(),
                        dr[8].ToString(),
                        dr[9].ToString()



                    };
                    resultado = datos;
                }
                connection.Close();
                return resultado;

            }
        }

        public void Buscar_arbitros_disponibles(ComboBox cb, DateTime fecha_reservacion, TimeSpan hora_inicio, TimeSpan horafinal)
        {
            string query = "exec vista_arbitros_disponibles @fecha,@Horainicio,@Horafinal";
            using (SqlConnection connec = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@fecha", fecha_reservacion);
                sql.Parameters.AddWithValue("@Horainicio", hora_inicio);
                sql.Parameters.AddWithValue("@Horafinal", horafinal);
                cb.Items.Clear();
                connec.Open();
                SqlDataReader reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    cb.Items.Add(reader[1].ToString());
                }


                connec.Close();

            }
        }
    }
}
