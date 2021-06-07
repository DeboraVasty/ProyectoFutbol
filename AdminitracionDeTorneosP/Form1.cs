using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using AdminitracionDeTorneosP.Model;
using AdminitracionDeTorneosP.Database;
using AdminitracionDeTorneosP.View;

namespace AdminitracionDeTorneosP
{
    public partial class Form1 : Form
    {
        public  bitacoraDB bitacoraContext = new bitacoraDB();
        public Form1(string nombre)
        {
            InitializeComponent();
            label1.Text = nombre;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(MenuVertical.Width == 250)
            {
                MenuVertical.Width = 70;
            }
            else
            {
                MenuVertical.Width = 250;
            }
        }

        private void iconoCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconoMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 70;
            }
            else
            {
                MenuVertical.Width = 250;
            }
        }

        private void AbrirFormInPanel(object Formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.Bienvenida());
            string accion = "ingreso Reportes";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.Torneo2());
            string accion = "ingreso a Torneo";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.MenuIncripcionEquipo());
            string accion = "ingreso a inscripcion equipo";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.MenuIncripcionJugador());
            string accion = "ingreso a Inscripcion juegador";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.CRUD_AMONESTACION());
            string accion = "ingreso a Amonestaciones";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.JornadasPartido());
            string accion = "ingreso a Jornadas";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.ComenzarPartido());
            string accion = "ingreso a Comenzar  Torneo";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.CRUD_ENTRENADOR());
            string accion = "ingreso a Entrenador";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.CRUD_EQUIPO());
            string accion = "ingreso a Equipo";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.refereeView());
            string accion = "ingreso a arbitro";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.CRUD_JUGADORES());
            string accion = "ingreso a Jugadores";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.vISTA_ENCUENTROS_WIN());
            string accion = "ingreso a Encuentros";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.VISTA_PAGOS_TARGETAS());
            string accion = "ingreso a pago Tarjetas";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.disponibilidad_Cancha());
            string accion = "ingreso a Disponibilidad";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.Agregar_Cancha());
            string accion = "ingreso  Cancha";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.VISTA_REPORTE_LOCAL());
            string accion = "ingreso Reporte Local";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.VISTA_PORTERO_MENOS_VENCIDO());
            string accion = "ingreso Portero Menos Vencido";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.Reporte_Tabla_Visitante());
            string accion = "ingreso Reporte Visitante";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.GOLEADOR());
            string accion = "ingreso a Goleador";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);

        }

        private void button22_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.reporteJuegosAfectados());
            string accion = "ingresa reporte Juegos Afectados";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.TARJETAS());
            string accion = "ingreso a Tarjetas";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.reportePlanillaArbitro());

            string accion = "ingreso Planilla Arbitro";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.tiempoUsoCanchas());
            string accion = "ingreso tiempo Canchas";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);

        }

        private void button23_Click(object sender, EventArgs e)
        {AbrirFormInPanel(new View.ReporteEstadisticasDelEquipo());
            string accion = "ingreso a Reporte Estadisticas Equipo";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
         }

        private void button24_Click(object sender, EventArgs e)
        {AbrirFormInPanel(new View.Reporte_Utilidades());
            string accion = "ingreso a Usuario utilidades";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void button25_Click(object sender, EventArgs e)
        {AbrirFormInPanel(new View.Reporte_punteo_general());
            string accion = "ingreso a punteo General";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
         }

        private void button26_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.Bienvenida());
            string accion = "ingreso a Reportes";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //control bitacora
            string accion = "Finalisa sesión";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
            this.Close();
            Sesion salir =new Sesion();
            salir.Show();

      }

        private void button14_Click_1(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.viewUsuario());
            //control bitacora
            string accion = "ingreso a Usuario";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.viewAlquilerArbitro());
            string accion = "ingreso a Alquiler Canchas";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
             AbrirFormInPanel(new View.ViewHorarios());
            string accion = "ingreso Horarios";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro); 
        }
    }
}
