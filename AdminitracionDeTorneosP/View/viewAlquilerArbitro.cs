using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;     
using System.Windows.Forms;
using AdminitracionDeTorneosP.Model;
using AdminitracionDeTorneosP.Database;

namespace AdminitracionDeTorneosP.View
{
    public partial class viewAlquilerArbitro : Form
    {
        public AlquilerCanchaDB alquilerContext = new AlquilerCanchaDB();
        public AlquilarCanchas alquilerSeleccionado = new AlquilarCanchas();
        public int accion = 1;
        public DateTime fechaaaaa;
        public string dias;
        public viewAlquilerArbitro()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowDrop = false;
            dataGridView1.AllowUserToDeleteRows = false;
          //  comboBox2.Enabled = false;

            string[] datos = alquilerContext.captar_info_horas_jornadas();
            if (datos == null)
            {
                MessageBox.Show("Error...\nNo se ha definido la hora de inicio de jornada\ny tampoco la hora de finalizacion de jornadas", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                textBox1.Text = datos[0];
               textBox2.Text = datos[1];
                textBox3.Text = datos[2];
               textBox4.Text = datos[3];
                textBox5.Text = datos[4];
                textBox6.Text = datos[5];
                textBox7.Text = datos[6];
                textBox8.Text = datos[7];
                textBox9.Text = datos[8];
                textBox10.Text = datos[9];
                textBox11.Text = datos[10];
                textBox12.Text = datos[11];
                textBox13.Text = datos[12];
                textBox14.Text = datos[13];


            }


            mostrar();
        }
        public void mostrar()
        {
            dataGridView1.DataSource = alquilerContext.manejoCanchas();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void viewAlquilerArbitro_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (accion==1)
            {
                TimeSpan validacion_hora_inicio;
                TimeSpan validacion_hora_final;


                TimeSpan hora_inicio_lunes;
                TimeSpan hora_final_lunes;
                TimeSpan hora_inicio_martes;
                TimeSpan hora_final_martes;
                TimeSpan hora_inicio_miercoles;
                TimeSpan hora_final_miercoles;
                TimeSpan hora_inicio_jueves;
                TimeSpan hora_final_jueves;
                TimeSpan hora_inicio_viernes;
                TimeSpan hora_final_viernes;
                TimeSpan hora_inicio_sabados;
                TimeSpan hora_final_sabados;
                TimeSpan hora_inicio_domingos;
                TimeSpan hora_fin_domingos;


                hora_inicio_domingos = TimeSpan.Parse(textBox13.Text);
                hora_fin_domingos = TimeSpan.Parse(textBox14.Text);
                hora_inicio_sabados = TimeSpan.Parse(textBox11.Text);
                hora_final_sabados = TimeSpan.Parse(textBox12.Text);
                hora_inicio_viernes = TimeSpan.Parse(textBox9.Text);
                hora_final_viernes = TimeSpan.Parse(textBox10.Text);
                hora_inicio_jueves = TimeSpan.Parse(textBox7.Text);
                hora_final_jueves= TimeSpan.Parse(textBox8.Text);
                hora_inicio_miercoles = TimeSpan.Parse(textBox5.Text);
                hora_final_miercoles = TimeSpan.Parse(textBox6.Text);
                hora_inicio_martes = TimeSpan.Parse(textBox3.Text);
                hora_final_martes = TimeSpan.Parse(textBox4.Text);
                hora_inicio_lunes = TimeSpan.Parse(textBox1.Text);
                hora_final_lunes = TimeSpan.Parse(textBox2.Text);

                if (textDPI.Text == ""|| textName.Text == "" || textLastName.Text == "" || textPhone.Text == "" || textMail.Text == "" || dateTimePicker1.Text == "" || textHoraInicio.Text == "" || textHoraFin.Text == "" || textCod_cancha.Text == "" || textPagoCancha.Text == "")
                {
                    MessageBox.Show("valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    validacion_hora_inicio = TimeSpan.Parse(textHoraInicio.Text);
                    validacion_hora_final = TimeSpan.Parse(textHoraFin.Text);

                     if (txt_dia_alquiler.Text == "Monday")
                    {


                        if (hora_inicio_lunes > validacion_hora_inicio || hora_final_lunes < validacion_hora_final)

                        {

                            MessageBox.Show("La cancha no está disponible ,\n Abrimos:  " + textBox1.Text + "   Cerramos: " + textBox2.Text, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {


                            //MessageBox.Show(dias);
                            //agregando infirmacion a la base de datos
                            AlquilarCanchas IngresandoAlquiler = new AlquilarCanchas();
                            IngresandoAlquiler.Nombre = textName.Text;
                            IngresandoAlquiler.Apellidos = textLastName.Text;
                            IngresandoAlquiler.DPI = Convert.ToInt64(textDPI.Text);
                            IngresandoAlquiler.telefono = textPhone.Text;
                            IngresandoAlquiler.correo = textMail.Text;
                            IngresandoAlquiler.fecha = dateTimePicker1.Value;
                            IngresandoAlquiler.HoraInicio = TimeSpan.Parse(textHoraInicio.Text);
                            IngresandoAlquiler.HoraFinal = TimeSpan.Parse(textHoraFin.Text);
                            IngresandoAlquiler.cod_cancha = Convert.ToInt32(textCod_cancha.Text);
                            IngresandoAlquiler.pago_cancha = Convert.ToDecimal(textPagoCancha.Text);
                          //  IngresandoAlquiler.cod_arbitro = Convert.ToInt32(textCod_arbitro.Text);
                           // IngresandoAlquiler.pago_arbitro = Convert.ToDecimal(textPagoArbitro.Text);


                            if (radioButton1.Checked == true)
                            {   comboBox2.Enabled = true;
                                IngresandoAlquiler.cod_arbitro = Convert.ToInt64(textCod_arbitro.Text);
                                IngresandoAlquiler.pago_arbitro = Convert.ToDecimal(textPagoArbitro.Text);
                                
                            }
                            else if (radioButton2.Checked == true)
                            {
                                comboBox2.Enabled = false;
                                textCod_arbitro.Text = "0";
                                textPagoArbitro.Text = "0";
                               

                                IngresandoAlquiler.cod_arbitro = Convert.ToInt64(textCod_arbitro.Text);
                                IngresandoAlquiler.pago_arbitro = Convert.ToDecimal(textPagoArbitro.Text);
                            }
                            alquilerContext.Insertar_alquilerCancha(IngresandoAlquiler);
                            mostrar(); 


                        }


                    }else
                    if (txt_dia_alquiler.Text == "Tuesday")
                    {


                        if (hora_inicio_martes > validacion_hora_inicio || hora_final_martes < validacion_hora_final)

                        {

                            MessageBox.Show("La cancha no está disponible ,\n Abrimos:  " + textBox3.Text + "   Cerramos: " + textBox4.Text, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {


                            //MessageBox.Show(dias);
                            //agregando infirmacion a la base de datos
                            AlquilarCanchas IngresandoAlquiler = new AlquilarCanchas();
                            IngresandoAlquiler.Nombre = textName.Text;
                            IngresandoAlquiler.Apellidos = textLastName.Text;
                            IngresandoAlquiler.DPI = Convert.ToInt64(textDPI.Text);
                            IngresandoAlquiler.telefono = textPhone.Text;
                            IngresandoAlquiler.correo = textMail.Text;
                            IngresandoAlquiler.fecha = dateTimePicker1.Value;
                            IngresandoAlquiler.HoraInicio = TimeSpan.Parse(textHoraInicio.Text);
                            IngresandoAlquiler.HoraFinal = TimeSpan.Parse(textHoraFin.Text);
                            IngresandoAlquiler.cod_cancha = Convert.ToInt32(textCod_cancha.Text);
                            IngresandoAlquiler.pago_cancha = Convert.ToDecimal(textPagoCancha.Text);
                            //  IngresandoAlquiler.cod_arbitro = Convert.ToInt32(textCod_arbitro.Text);
                            // IngresandoAlquiler.pago_arbitro = Convert.ToDecimal(textPagoArbitro.Text);


                            if (radioButton1.Checked == true)
                            {
                                comboBox2.Enabled = true;
                                IngresandoAlquiler.cod_arbitro = Convert.ToInt64(textCod_arbitro.Text);
                                IngresandoAlquiler.pago_arbitro = Convert.ToDecimal(textPagoArbitro.Text);

                            }
                            else if (radioButton2.Checked == true)
                            {
                                comboBox2.Enabled = false;
                                textCod_arbitro.Text = "0";
                                textPagoArbitro.Text = "0";


                                IngresandoAlquiler.cod_arbitro = Convert.ToInt64(textCod_arbitro.Text);
                                IngresandoAlquiler.pago_arbitro = Convert.ToDecimal(textPagoArbitro.Text);
                            }
                            alquilerContext.Insertar_alquilerCancha(IngresandoAlquiler);
                            mostrar();


                        }


                    }
                    else
                    if (txt_dia_alquiler.Text == "Wednesday")
                    {


                        if (hora_inicio_miercoles > validacion_hora_inicio || hora_final_miercoles < validacion_hora_final)

                        {

                            MessageBox.Show("La cancha no está disponible ,\n Abrimos:  " + textBox5.Text + "   Cerramos: " + textBox6.Text, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {


                            //MessageBox.Show(dias);
                            //agregando infirmacion a la base de datos
                            AlquilarCanchas IngresandoAlquiler = new AlquilarCanchas();
                            IngresandoAlquiler.Nombre = textName.Text;
                            IngresandoAlquiler.Apellidos = textLastName.Text;
                            IngresandoAlquiler.DPI = Convert.ToInt64(textDPI.Text);
                            IngresandoAlquiler.telefono = textPhone.Text;
                            IngresandoAlquiler.correo = textMail.Text;
                            IngresandoAlquiler.fecha = dateTimePicker1.Value;
                            IngresandoAlquiler.HoraInicio = TimeSpan.Parse(textHoraInicio.Text);
                            IngresandoAlquiler.HoraFinal = TimeSpan.Parse(textHoraFin.Text);
                            IngresandoAlquiler.cod_cancha = Convert.ToInt32(textCod_cancha.Text);
                            IngresandoAlquiler.pago_cancha = Convert.ToDecimal(textPagoCancha.Text);
                            //  IngresandoAlquiler.cod_arbitro = Convert.ToInt32(textCod_arbitro.Text);
                            // IngresandoAlquiler.pago_arbitro = Convert.ToDecimal(textPagoArbitro.Text);


                            if (radioButton1.Checked == true)
                            {
                                comboBox2.Enabled = true;
                                IngresandoAlquiler.cod_arbitro = Convert.ToInt64(textCod_arbitro.Text);
                                IngresandoAlquiler.pago_arbitro = Convert.ToDecimal(textPagoArbitro.Text);

                            }
                            else if (radioButton2.Checked == true)
                            {
                                comboBox2.Enabled = false;
                                textCod_arbitro.Text = "0";
                                textPagoArbitro.Text = "0";


                                IngresandoAlquiler.cod_arbitro = Convert.ToInt64(textCod_arbitro.Text);
                                IngresandoAlquiler.pago_arbitro = Convert.ToDecimal(textPagoArbitro.Text);
                            }
                            alquilerContext.Insertar_alquilerCancha(IngresandoAlquiler);
                            mostrar();


                        }


                    }
                    if (txt_dia_alquiler.Text == "Tursday")
                    {


                        if (hora_inicio_jueves > validacion_hora_inicio || hora_final_jueves < validacion_hora_final)

                        {

                            MessageBox.Show("La cancha no está disponible ,\n Abrimos:  " + textBox7.Text + "   Cerramos: " + textBox8.Text, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {


                            //MessageBox.Show(dias);
                            //agregando infirmacion a la base de datos
                            AlquilarCanchas IngresandoAlquiler = new AlquilarCanchas();
                            IngresandoAlquiler.Nombre = textName.Text;
                            IngresandoAlquiler.Apellidos = textLastName.Text;
                            IngresandoAlquiler.DPI = Convert.ToInt64(textDPI.Text);
                            IngresandoAlquiler.telefono = textPhone.Text;
                            IngresandoAlquiler.correo = textMail.Text;
                            IngresandoAlquiler.fecha = dateTimePicker1.Value;
                            IngresandoAlquiler.HoraInicio = TimeSpan.Parse(textHoraInicio.Text);
                            IngresandoAlquiler.HoraFinal = TimeSpan.Parse(textHoraFin.Text);
                            IngresandoAlquiler.cod_cancha = Convert.ToInt32(textCod_cancha.Text);
                            IngresandoAlquiler.pago_cancha = Convert.ToDecimal(textPagoCancha.Text);
                            //  IngresandoAlquiler.cod_arbitro = Convert.ToInt32(textCod_arbitro.Text);
                            // IngresandoAlquiler.pago_arbitro = Convert.ToDecimal(textPagoArbitro.Text);


                            if (radioButton1.Checked == true)
                            {
                                comboBox2.Enabled = true;
                                IngresandoAlquiler.cod_arbitro = Convert.ToInt64(textCod_arbitro.Text);
                                IngresandoAlquiler.pago_arbitro = Convert.ToDecimal(textPagoArbitro.Text);

                            }
                            else if (radioButton2.Checked == true)
                            {
                                comboBox2.Enabled = false;
                                textCod_arbitro.Text = "0";
                                textPagoArbitro.Text = "0";


                                IngresandoAlquiler.cod_arbitro = Convert.ToInt64(textCod_arbitro.Text);
                                IngresandoAlquiler.pago_arbitro = Convert.ToDecimal(textPagoArbitro.Text);
                            }
                            alquilerContext.Insertar_alquilerCancha(IngresandoAlquiler);
                            mostrar();



                        }


                    } else
                    if (txt_dia_alquiler.Text == "Friday")
                    {


                        if (hora_inicio_viernes > validacion_hora_inicio || hora_final_viernes < validacion_hora_final)

                        {

                            MessageBox.Show("La cancha no está disponible ,\n Abrimos:  " + textBox9.Text + "   Cerramos: " + textBox10.Text, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {


                            //MessageBox.Show(dias);
                            //agregando infirmacion a la base de datos
                            AlquilarCanchas IngresandoAlquiler = new AlquilarCanchas();
                            IngresandoAlquiler.Nombre = textName.Text;
                            IngresandoAlquiler.Apellidos = textLastName.Text;
                            IngresandoAlquiler.DPI = Convert.ToInt64(textDPI.Text);
                            IngresandoAlquiler.telefono = textPhone.Text;
                            IngresandoAlquiler.correo = textMail.Text;
                            IngresandoAlquiler.fecha = dateTimePicker1.Value;
                            IngresandoAlquiler.HoraInicio = TimeSpan.Parse(textHoraInicio.Text);
                            IngresandoAlquiler.HoraFinal = TimeSpan.Parse(textHoraFin.Text);
                            IngresandoAlquiler.cod_cancha = Convert.ToInt32(textCod_cancha.Text);
                            IngresandoAlquiler.pago_cancha = Convert.ToDecimal(textPagoCancha.Text);
                            //  IngresandoAlquiler.cod_arbitro = Convert.ToInt32(textCod_arbitro.Text);
                            // IngresandoAlquiler.pago_arbitro = Convert.ToDecimal(textPagoArbitro.Text);


                            if (radioButton1.Checked == true)
                            {
                                comboBox2.Enabled = true;
                                IngresandoAlquiler.cod_arbitro = Convert.ToInt64(textCod_arbitro.Text);
                                IngresandoAlquiler.pago_arbitro = Convert.ToDecimal(textPagoArbitro.Text);

                            }
                            else if (radioButton2.Checked == true)
                            {
                                comboBox2.Enabled = false;
                                textCod_arbitro.Text = "0";
                                textPagoArbitro.Text = "0";


                                IngresandoAlquiler.cod_arbitro = Convert.ToInt64(textCod_arbitro.Text);
                                IngresandoAlquiler.pago_arbitro = Convert.ToDecimal(textPagoArbitro.Text);
                            }
                            alquilerContext.Insertar_alquilerCancha(IngresandoAlquiler);
                            mostrar();



                        }


                    }
                    else
                    if (txt_dia_alquiler.Text == "Saturday")
                    {


                        if (hora_inicio_sabados > validacion_hora_inicio || hora_final_sabados < validacion_hora_final)

                        {

                            MessageBox.Show("La cancha no está disponible ,\n Abrimos:  " + textBox11.Text + "   Cerramos: " + textBox12.Text, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {


                            //MessageBox.Show(dias);
                            //agregando infirmacion a la base de datos
                            AlquilarCanchas IngresandoAlquiler = new AlquilarCanchas();
                            IngresandoAlquiler.Nombre = textName.Text;
                            IngresandoAlquiler.Apellidos = textLastName.Text;
                            IngresandoAlquiler.DPI = Convert.ToInt64(textDPI.Text);
                            IngresandoAlquiler.telefono = textPhone.Text;
                            IngresandoAlquiler.correo = textMail.Text;
                            IngresandoAlquiler.fecha = dateTimePicker1.Value;
                            IngresandoAlquiler.HoraInicio = TimeSpan.Parse(textHoraInicio.Text);
                            IngresandoAlquiler.HoraFinal = TimeSpan.Parse(textHoraFin.Text);
                            IngresandoAlquiler.cod_cancha = Convert.ToInt32(textCod_cancha.Text);
                            IngresandoAlquiler.pago_cancha = Convert.ToDecimal(textPagoCancha.Text);
                            //  IngresandoAlquiler.cod_arbitro = Convert.ToInt32(textCod_arbitro.Text);
                            // IngresandoAlquiler.pago_arbitro = Convert.ToDecimal(textPagoArbitro.Text);


                            if (radioButton1.Checked == true)
                            {
                                comboBox2.Enabled = true;
                                IngresandoAlquiler.cod_arbitro = Convert.ToInt64(textCod_arbitro.Text);
                                IngresandoAlquiler.pago_arbitro = Convert.ToDecimal(textPagoArbitro.Text);

                            }
                            else if (radioButton2.Checked == true)
                            {
                                comboBox2.Enabled = false;
                                textCod_arbitro.Text = "0";
                                textPagoArbitro.Text = "0";


                                IngresandoAlquiler.cod_arbitro = Convert.ToInt64(textCod_arbitro.Text);
                                IngresandoAlquiler.pago_arbitro = Convert.ToDecimal(textPagoArbitro.Text);
                            }
                            alquilerContext.Insertar_alquilerCancha(IngresandoAlquiler);
                            mostrar();




                        }


                    }
                    if (txt_dia_alquiler.Text == "Sunday")
                    {


                        if (hora_inicio_domingos > validacion_hora_inicio || hora_fin_domingos  < validacion_hora_final)

                        {

                            MessageBox.Show("La cancha no está disponible ,\n Abrimos:  " + textBox13.Text + "   Cerramos: " + textBox14.Text, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {


                            //MessageBox.Show(dias);
                            //agregando infirmacion a la base de datos
                            AlquilarCanchas IngresandoAlquiler = new AlquilarCanchas();
                            IngresandoAlquiler.Nombre = textName.Text;
                            IngresandoAlquiler.Apellidos = textLastName.Text;
                            IngresandoAlquiler.DPI = Convert.ToInt64(textDPI.Text);
                            IngresandoAlquiler.telefono = textPhone.Text;
                            IngresandoAlquiler.correo = textMail.Text;
                            IngresandoAlquiler.fecha = dateTimePicker1.Value;
                            IngresandoAlquiler.HoraInicio = TimeSpan.Parse(textHoraInicio.Text);
                            IngresandoAlquiler.HoraFinal = TimeSpan.Parse(textHoraFin.Text);
                            IngresandoAlquiler.cod_cancha = Convert.ToInt32(textCod_cancha.Text);
                            IngresandoAlquiler.pago_cancha = Convert.ToDecimal(textPagoCancha.Text);
                            //  IngresandoAlquiler.cod_arbitro = Convert.ToInt32(textCod_arbitro.Text);
                            // IngresandoAlquiler.pago_arbitro = Convert.ToDecimal(textPagoArbitro.Text);


                            if (radioButton1.Checked == true)
                            {
                                comboBox2.Enabled = true;
                                IngresandoAlquiler.cod_arbitro = Convert.ToInt64(textCod_arbitro.Text);
                                IngresandoAlquiler.pago_arbitro = Convert.ToDecimal(textPagoArbitro.Text);

                            }
                            else if (radioButton2.Checked == true)
                            {
                                comboBox2.Enabled = false;
                                textCod_arbitro.Text = "0";
                                textPagoArbitro.Text = "0";


                                IngresandoAlquiler.cod_arbitro = Convert.ToInt64(textCod_arbitro.Text);
                                IngresandoAlquiler.pago_arbitro = Convert.ToDecimal(textPagoArbitro.Text);
                            }
                            alquilerContext.Insertar_alquilerCancha(IngresandoAlquiler);
                            mostrar();

  
                        }


                    }
                    
                }

            }

                   


            
        
        }
        private int? buscar_id()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }

            catch
            {
                return null;
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? id_alqui = buscar_id();
            alquilerContext.eliminar_alquiler(id_alqui);
            mostrar();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (textHoraInicio.Text == ""&& textHoraFin.Text=="")
            {

            }
            else
            {
                DateTime fecha1;

                fecha1 = DateTime.Parse(dateTimePicker1.Text);
                alquilerContext.Buscar_canchas_disponibles(comboBox1, fecha1, TimeSpan.Parse(textHoraInicio.Text), TimeSpan.Parse(textHoraFin.Text));
                //  combo2.Buscar_arbitros_disponibles(comboBox4, fecha, TimeSpan.Parse(comboBox2.Text), TimeSpan.Parse(comboBox3.Text));
            }

            DateTime fecha;
            fecha = DateTime.Parse(dateTimePicker1.Text);
            fechaaaaa = fecha;
            //txt_dia_alquiler.Text=fecha.DayOfWeek.ToString();
            dias = fecha.DayOfWeek.ToString();
            txt_dia_alquiler.Text = dias;
        }

        private void textHoraInicio_TextChanged(object sender, EventArgs e)
        {
            if (textHoraFin.Text == "")
            {

            }
            else
            {
                DateTime fecha;

                fecha = DateTime.Parse(dateTimePicker1.Text);
                alquilerContext.Buscar_canchas_disponibles(comboBox1, fecha, TimeSpan.Parse(textHoraInicio.Text), TimeSpan.Parse(textHoraFin.Text));
                alquilerContext.Buscar_arbitros_disponibles(comboBox2, fecha, TimeSpan.Parse(textHoraInicio.Text), TimeSpan.Parse(textHoraFin.Text));
                decimal dif_inicio;
                dif_inicio = Convert.ToDecimal(TimeSpan.Parse(textHoraFin.Text).TotalHours) - Convert.ToDecimal(TimeSpan.Parse(textHoraInicio.Text).TotalHours);
                txtCantHoras.Text = dif_inicio.ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex>=0)
            {
                string[] datos = alquilerContext.captar_info_id_canchas(comboBox1.Text);
                textCod_cancha.Text = datos[0];
                string[] datoss = alquilerContext.captar_info_id_canchas(comboBox1.Text);
                textBox15.Text = datoss[4];

                decimal horas_a_pagar;
                decimal precio_canchas;
                decimal tatal_pagar;

                if (txtCantHoras.Text == "" || textBox15.Text == "")
                {


                }
                else
                {
                    horas_a_pagar = Convert.ToDecimal(txtCantHoras.Text);
                    precio_canchas = Convert.ToDecimal(textBox15.Text);
                    tatal_pagar = horas_a_pagar * precio_canchas;
                    textPagoCancha.Text = tatal_pagar.ToString();
                }
            }
        }

        private void textHoraFin_TextChanged(object sender, EventArgs e)
        {
            if (textHoraInicio.Text == "")
            {

            }
            else
            {
                DateTime fecha;

                fecha = DateTime.Parse(dateTimePicker1.Text);
                alquilerContext.Buscar_canchas_disponibles(comboBox1, fecha, TimeSpan.Parse(textHoraInicio.Text), TimeSpan.Parse(textHoraFin.Text));
                alquilerContext.Buscar_arbitros_disponibles(comboBox2, fecha, TimeSpan.Parse(textHoraFin.Text), TimeSpan.Parse(textHoraFin.Text));
                decimal dif_inicio;
                dif_inicio = Convert.ToDecimal(TimeSpan.Parse(textHoraFin.Text).TotalHours) - Convert.ToDecimal(TimeSpan.Parse(textHoraInicio.Text).TotalHours);
                txtCantHoras.Text = dif_inicio.ToString();
            }

        }

        private void comboHoraInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboHoraInicio.SelectedIndex >= 0)
            {
                textHoraInicio.Text = comboHoraInicio.Text;

            }
        }

        private void comboHoraFin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboHoraFin.SelectedIndex >= 0)
            {
                textHoraFin.Text = comboHoraFin.Text;

            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                string[] datos3 = alquilerContext.captar_info_id_arbitros(comboBox2.Text);
                textCod_arbitro.Text = datos3[0];


                string[] datoss4 = alquilerContext.captar_info_id_arbitros(comboBox2.Text);
                textPagoArbitro.Text = datoss4[9];


                decimal horas_a_pagar;
                decimal precio_arbitro;
                decimal tatoal_pagar;
                if (txtCantHoras.Text == "" || textPagoArbitro.Text == "")
                {


                }
                else
                {
                    horas_a_pagar = Convert.ToDecimal(txtCantHoras.Text);
                    precio_arbitro = Convert.ToDecimal(textPagoArbitro.Text);
                    tatoal_pagar = horas_a_pagar * precio_arbitro;
                    textPagoArbitro.Text = tatoal_pagar.ToString();
                }
            }
        }

        private void textPhone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
