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

namespace AdminitracionDeTorneosP.View
{
    public partial class ViewHorarios : Form
    {

        public horariosDB horariosContext = new horariosDB();
        public horarios horariosSeleccionado = new horarios();
        public ViewHorarios()
        {
            InitializeComponent();
            refereeList.AllowUserToAddRows = false;
            refereeList.AllowDrop = false;
            refereeList.AllowUserToDeleteRows = false;
            mostrar();

        }
        public void mostrar()
        {
            refereeList.DataSource = horariosContext.manejoHorarios();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int? Id_horario = buscar_id();
            horarios horario_actualizar = horariosContext.buscar(Id_horario);
          textBox5.Text=Convert.ToString(horario_actualizar.Lhora_inicio);
          textBox1.Text = Convert.ToString(horario_actualizar.Lhora_fin ) ;
            textBox2.Text = Convert.ToString(horario_actualizar.Mhora_inicio);
          textBox3.Text = Convert.ToString(horario_actualizar.Mhora_fin);
          textBox4.Text = Convert.ToString(horario_actualizar.Mihora_inicio ) ;
          textBox6.Text = Convert.ToString(horario_actualizar.Mihora_fin);
          textBox12.Text =Convert.ToString(horario_actualizar.Jhora_inicio );
          textBox11.Text = Convert.ToString(horario_actualizar.Jhora_fin ) ;
            textBox10.Text = Convert.ToString(horario_actualizar.Vhora_inicio);
          textBox9.Text = Convert.ToString(horario_actualizar.Vhora_fin) ;
          textBox8.Text = Convert.ToString(horario_actualizar.Shora_inicio);
           textBox7.Text = Convert.ToString(horario_actualizar.Shora_fin );
          textBox14.Text = Convert.ToString(horario_actualizar.Dhora_inicio) ;
          textBox13.Text = Convert.ToString(horario_actualizar.Dhora_fin );

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "" || textBox14.Text == "")
            {
                MessageBox.Show("Valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //guardar actualizacion

                int? Id_horario = buscar_id();




                TimeSpan Lhora_inicio = TimeSpan.Parse(textBox5.Text);
                TimeSpan Lhora_fin = TimeSpan.Parse(textBox1.Text);
                TimeSpan Mhora_inicio = TimeSpan.Parse(textBox2.Text);
                TimeSpan Mhora_fin = TimeSpan.Parse(textBox3.Text);
                TimeSpan Mihora_inicio = TimeSpan.Parse(textBox4.Text);
                TimeSpan Mihora_fin = TimeSpan.Parse(textBox6.Text);
                TimeSpan Jhora_inicio = TimeSpan.Parse(textBox12.Text);
                TimeSpan Jhora_fin = TimeSpan.Parse(textBox11.Text);
                TimeSpan Vhora_inicio = TimeSpan.Parse(textBox10.Text);
                TimeSpan Vhora_fin = TimeSpan.Parse(textBox9.Text);
                TimeSpan Shora_inicio = TimeSpan.Parse(textBox8.Text);
                TimeSpan Shora_fin = TimeSpan.Parse(textBox7.Text);
                TimeSpan Dhora_inicio = TimeSpan.Parse(textBox14.Text);
                TimeSpan Dhora_fin = TimeSpan.Parse(textBox13.Text);


                horariosContext.actualizar_Horarios(Id_horario,  Lhora_inicio,Lhora_fin,Mhora_inicio,Mhora_fin, Mihora_inicio, Mihora_fin, Jhora_inicio, Jhora_fin, Vhora_inicio, Vhora_fin,Shora_inicio,Shora_fin, Dhora_inicio,Dhora_fin);
                mostrar();


            }
        }


        private int? buscar_id()
        {
            try
            {
                return int.Parse(refereeList.Rows[refereeList.CurrentRow.Index].Cells[0].Value.ToString());
            }

            catch
            {
                return null;
            }

        }

        private void ViewHorarios_Load(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void refereeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}
