using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminitracionDeTorneosP.View
{
    public partial class Bienvenida : Form
    {
        public Bienvenida()
        {
            InitializeComponent();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Reporte_Tabla_Visitante abrirForm = new Reporte_Tabla_Visitante();

            abrirForm.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            VISTA_PORTERO_MENOS_VENCIDO abrirForm = new VISTA_PORTERO_MENOS_VENCIDO();

            abrirForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VISTA_REPORTE_LOCAL abrirForm = new VISTA_REPORTE_LOCAL();

            abrirForm.ShowDialog();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            GOLEADOR abrirForm = new GOLEADOR();

            abrirForm.ShowDialog();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            TARJETAS abrirForm = new TARJETAS();

            abrirForm.ShowDialog();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            reportePlanillaArbitro abrirForm = new reportePlanillaArbitro();

            abrirForm.ShowDialog();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            tiempoUsoCanchas abrirForm = new tiempoUsoCanchas();

            abrirForm.ShowDialog();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            reporteJuegosAfectados abrirForm = new reporteJuegosAfectados();

            abrirForm.ShowDialog();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            ReporteEstadisticasDelEquipo abrirForm = new ReporteEstadisticasDelEquipo();

            abrirForm.ShowDialog();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Reporte_Utilidades abrirForm = new Reporte_Utilidades();

            abrirForm.ShowDialog();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Reporte_punteo_general abrirForm = new Reporte_punteo_general();

            abrirForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            disponibilidad_Cancha abrirForm = new disponibilidad_Cancha();

            abrirForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reporte_Bitacora abrirForm = new Reporte_Bitacora();
            abrirForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IngresosAlquilerCanchas abrirForm = new IngresosAlquilerCanchas();
            abrirForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           ReporteAlquilerArbitros abrirForm = new ReporteAlquilerArbitros();
            abrirForm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            viewReporteDisponibilidad abrirForm = new viewReporteDisponibilidad();
            abrirForm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
          ReporteListadoJugadores abrirForm = new ReporteListadoJugadores();
            abrirForm.ShowDialog();
        }
    }
}
