using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminitracionDeTorneosP.Database;
using AdminitracionDeTorneosP.Model;
using System.Data.SqlClient;

namespace AdminitracionDeTorneosP.View
{
    public partial class viewReporteDisponibilidad : Form
    {

        public reporteDisponibilidadDB disponibilidadContext = new reporteDisponibilidadDB();

        public viewReporteDisponibilidad()
        {
            InitializeComponent();
            disponibilidadContext.GetCanchas(comboBox1);
            string[] datos = disponibilidadContext.captar_info_horas_jornadas();
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int max = 0;
            int min = 100;
            dataGridView1.Columns.Clear();
            int dias = dateTimePicker2.Value.Day - dateTimePicker1.Value.Day;

         /*   for (int i = 0; i <= dias; i++) {
                dataGridView1.Columns.Add("", Convert.ToString(i + 1));
            }*/
            
            for ( DateTime inicio=dateTimePicker1.Value.Date;inicio<=dateTimePicker2.Value.Date;inicio=inicio.AddDays(1))
            {
              //  Convert.ToString(inicio.Day + "/" + inicio.Month + "/" + inicio.Year)
                dataGridView1.Columns.Add("Disponibilidad", inicio.ToShortDateString()) ;

                switch(inicio.DayOfWeek.ToString()){
                    case "Monday":
                        if (max < Convert.ToInt32(textBox2.Text.Substring( 0,2 )))
                        {
                            max = Convert.ToInt32(textBox2.Text.Substring(0, 2));
                        }
                        if(min> Convert.ToInt32(textBox1.Text.Substring(0, 2))){
                            min = Convert.ToInt32(textBox1.Text.Substring(0, 2));

                        }
                        break;
                    case "Tuesday":
                        if (max < Convert.ToInt32(textBox4.Text.Substring(0, 2)))
                        {
                            max = Convert.ToInt32(textBox4.Text.Substring(0, 2));
                        }
                        if (min > Convert.ToInt32(textBox3.Text.Substring(0, 2)))
                        {
                            min = Convert.ToInt32(textBox3.Text.Substring(0, 2));

                        }
                        break;
                    case "Wednesday":
                        if (max < Convert.ToInt32(textBox6.Text.Substring(0, 2)))
                        {
                            max = Convert.ToInt32(textBox6.Text.Substring(0, 2));
                        }
                        if (min > Convert.ToInt32(textBox5.Text.Substring(0, 2)))
                        {
                            min = Convert.ToInt32(textBox5.Text.Substring(0, 2));

                        }
                        break;

                    case "Thursday":
                        if (max < Convert.ToInt32(textBox8.Text.Substring(0, 2)))
                        {
                            max = Convert.ToInt32(textBox8.Text.Substring(0, 2));
                        }
                        if (min > Convert.ToInt32(textBox7.Text.Substring(0, 2)))
                        {
                            min = Convert.ToInt32(textBox7.Text.Substring(0, 2));

                        }
                        break;

                    case "Friday":
                        if (max < Convert.ToInt32(textBox10.Text.Substring(0, 2)))
                        {
                            max = Convert.ToInt32(textBox10.Text.Substring(0, 2));
                        }
                        if (min > Convert.ToInt32(textBox9.Text.Substring(0, 2)))
                        {
                            min = Convert.ToInt32(textBox9.Text.Substring(0, 2));

                        }
                        break;

                    case "Saturday":
                        if (max < Convert.ToInt32(textBox12.Text.Substring(0, 2)))
                        {
                            max = Convert.ToInt32(textBox12.Text.Substring(0, 2));
                        }
                        if (min > Convert.ToInt32(textBox11.Text.Substring(0, 2)))
                        {
                            min = Convert.ToInt32(textBox11.Text.Substring(0, 2));

                        }
                        break;

                    case "Sunday":
                        if (max < Convert.ToInt32(textBox14.Text.Substring(0, 2)))
                        {
                            max = Convert.ToInt32(textBox14.Text.Substring(0, 2));
                        }
                        if (min > Convert.ToInt32(textBox13.Text.Substring(0, 2)))
                        {
                            min = Convert.ToInt32(textBox13.Text.Substring(0, 2));

                        }
                        break;
                }

            }


            int columnas = dataGridView1.Columns.Count;
            int x = 0;
            
            

            List<reporteDisponibilidad> listaDisponibilidad = disponibilidadContext.horariosCanchas(dateTimePicker1.Value,dateTimePicker2.Value,comboBox1.SelectedItem.ToString());

           List<reporteDisponibilidad> listaDisponibilidad2 = disponibilidadContext.horariosCanchas2(dateTimePicker1.Value, dateTimePicker2.Value, comboBox1.SelectedItem.ToString());

            listaDisponibilidad.AddRange(listaDisponibilidad2.ToArray());



            for (int i = min; i < max; i++)
            {

                dataGridView1.Rows.Add("");
                dataGridView1.Rows[x].HeaderCell.Value = Convert.ToString(i) + "-" + Convert.ToString(i + 1);
              
              

                x = x + 1;
            }
            //int count = 0;
            for (int i = 0; i < columnas; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                {
                    dataGridView1.Rows[j].Cells[i].Value = "Disponible";
                }
            }


           foreach (var element in listaDisponibilidad)
            {
                string fecha = element.fecha.ToShortDateString();
               for (int i = 0; i < columnas; i++)
                {
                    for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                    {
                        if (dataGridView1.Columns[i].HeaderCell.Value.ToString() == fecha)
                        {
                            string[] subs = dataGridView1.Rows[j].HeaderCell.Value.ToString().Split('-');
                                            if (subs[0] == element.horaInicio.Hours.ToString())
                                            {
                                                if (subs[1] == element.horaFin.Hours.ToString())
                                                {


                                                    dataGridView1.Rows[j].Cells[i].Value = "No disponible";
                                                }
                                                else
                                                {
                                                    dataGridView1.Rows[j].Cells[i].Value = "No disponible";
                                                }
                                            }
                                            else if (subs[1] == element.horaFin.Hours.ToString())
                                            {
                                                dataGridView1.Rows[j].Cells[i].Value = " No disponible";
                                            }
                          
                         
                        }/* else
                        {
                            dataGridView1.Rows[j].Cells[i].Value = "Disponible";
                        }*/
                    }
                }
            }
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void viewReporteDisponibilidad_Load(object sender, EventArgs e)
        {

        }
    }
}
