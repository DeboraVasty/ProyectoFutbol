using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AdminitracionDeTorneosP.Model;
using AdminitracionDeTorneosP.Database;



namespace AdminitracionDeTorneosP.View
{
    public partial class Sesion : Form
    {

        public bitacoraDB bitacoraContext = new bitacoraDB();
        public Sesion()
        {
            InitializeComponent();
        }

        //Conexion a Base de Datos
        
        SqlConnection conexion = new SqlConnection ("Server=LAPTOP-PM9QCVMQ\\SQLEXPRESS;Database=PROYECTO_TORNEOS;User Id=capacitacion;Password=123456;");
        public void logear(string usuario, string contrasena)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("select Nombre, tipo_usuario,activo,usuario from Usuario where usuario=@usuario and contraseña=@contras  ", conexion);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contras", contrasena);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    
                   
                  if (dt.Rows[0][2].ToString() == "N") { MessageBox.Show("El usuario se encuentra inactivo"); }
                    else
                    {
                        txtUsuario.Text = "";
                        textBox2.Text = "";
                        this.Hide();

                        if (dt.Rows[0][1].ToString() == "Administrador")
                    {
                        string nombre = dt.Rows[0][3].ToString();
                        new Form1(nombre).Show();
                           

                            string accion = "inicio Sesion";
                            bitacora registro = new bitacora();
                            registro.usuario = nombre;
                            registro.accion = accion;
                            bitacoraContext.Insertar_bitacora(registro);


                        }
                    else if (dt.Rows[0][1].ToString() == "Operador")
                    {
                        new menu2(dt.Rows[0][3].ToString()).Show();
                            string accion = "inicio Sesion";
                            bitacora registro = new bitacora();
                            registro.usuario = dt.Rows[0][3].ToString();
                            registro.accion = accion;
                            bitacoraContext.Insertar_bitacora(registro);
                        }
                    else if (dt.Rows[0][1].ToString() == "Reportes")
                    {
                        new menu3(dt.Rows[0][3].ToString()).Show();
                            string accion = "inicio Sesion";
                            bitacora registro = new bitacora();
                            registro.usuario = dt.Rows[0][3].ToString();
                            registro.accion = accion;
                            bitacoraContext.Insertar_bitacora(registro);
                        }
                    else
                    {
                        MessageBox.Show("El usuario o  Contraseña son Incorrectas");
                    }
                }
                }

            } catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conexion.Close();
            }

        }
        
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text=="Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;

            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Contraseña";
                textBox2.ForeColor = Color.DimGray;
                //textBox2.UseSystemPasswordChar = false;
            }
        }

        private void textBox2_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Contraseña")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                //textBox2.UseSystemPasswordChar = true;

            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();     
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '*')
            {
                pictureBox1.BringToFront();
                textBox2.PasswordChar = '\0';
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '\0')
            {
                pictureBox2.BringToFront();
                textBox2.PasswordChar = '*';
            }
        }

        private void Sesion_Load(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            logear(this.txtUsuario.Text, this.textBox2.Text);
        }
    }
}
