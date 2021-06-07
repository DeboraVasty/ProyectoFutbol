﻿using System;
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
   
    public partial class menu3 : Form

    { 
        public bitacoraDB bitacoraContext = new bitacoraDB();

        public menu3(string nombre)
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.Torneo2());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.MenuIncripcionEquipo());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.MenuIncripcionJugador());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.CRUD_AMONESTACION());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.JornadasPartido());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.ComenzarPartido());
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.CRUD_ENTRENADOR());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.CRUD_EQUIPO());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.refereeView());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.CRUD_JUGADORES());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.vISTA_ENCUENTROS_WIN());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //control bitacora
            string accion = "Ingreso Reportes";
            bitacora registro = new bitacora();
            registro.usuario = label1.Text;
            registro.accion = accion;
            bitacoraContext.Insertar_bitacora(registro);
            AbrirFormInPanel(new View.Bienvenida());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.disponibilidad_Cancha());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.Agregar_Cancha());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.VISTA_REPORTE_LOCAL());
        }

        private void button16_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.VISTA_PORTERO_MENOS_VENCIDO());
        }

        private void button17_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.Reporte_Tabla_Visitante());
        }

        private void button18_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.GOLEADOR());

        }

        private void button22_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.reporteJuegosAfectados());
        }

        private void button19_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.TARJETAS());
        }

        private void button20_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.reportePlanillaArbitro());
        }

        private void button21_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.tiempoUsoCanchas());

        }

        private void button23_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.ReporteEstadisticasDelEquipo());

        }

        private void button24_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.Reporte_Utilidades());
        }

        private void button25_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.Reporte_punteo_general());

        }

        private void button26_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.Bienvenida());
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
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
            Sesion salir = new Sesion();
            salir.Show();

        }
    }
}
