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
    public partial class viewUsuario : Form
    {
        //Declaración de switch para hacer cambio de actualización a guardado y viceversa
        public int action = 1;
        public UsuariosDB usuariosContext = new UsuariosDB();
        public Usuarios usuariosSeleccionado = new Usuarios();
        String activ;
        public viewUsuario()
        {
            InitializeComponent();
            refereeList.AllowUserToAddRows = false;
            refereeList.AllowDrop = false;
            refereeList.AllowUserToDeleteRows = false;
            mostrar();

        }

        public void mostrar()
        {
            refereeList.DataSource = usuariosContext.manejousuarios();
        }



        private void textNacionality_TextChanged(object sender, EventArgs e)
        {

        }

        private void viewUsuario_Load(object sender, EventArgs e)
        {
                   
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {

            //Si el action esta en 1 se procede a guardar el objeto obtenido
            if (action == 1)
            {
                if (textName.Text == "" || textName.Text == "" || textLastName.Text == "" || textPhone.Text == "" || textMail.Text == "" || textAddress.Text == "" || textPuesto.Text == "" || textUsuario.Text == "" || textContrasena.Text == "" || cmbTipo_usuario.Text == "")
                {
                    MessageBox.Show("Valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (rbS.Checked == true)
                    {
                        activ = "S";
                    }

                    else if (rbN.Checked == true)
                    {
                        activ = "N";
                    }
                    mostrar();
                    Usuarios ingreso_usuario = new Usuarios();

                    ingreso_usuario.DPI = Convert.ToInt64(textDPI.Text);
                    ingreso_usuario.Nombre = textName.Text;
                    ingreso_usuario.Apellidos = textLastName.Text;
                    ingreso_usuario.telefono = textPhone.Text;
                    ingreso_usuario.correo = textMail.Text;
                    ingreso_usuario.direccion = textAddress.Text;
                    ingreso_usuario.puesto = textPuesto.Text;
                    ingreso_usuario.usuario = textUsuario.Text;
                    ingreso_usuario.contraseña = textContrasena.Text;
                    ingreso_usuario.activo = activ;
                    ingreso_usuario.tipo_usuario = cmbTipo_usuario.Text;
                    usuariosContext.Insertar_Usuarios(ingreso_usuario);

                    mostrar();
                    textName.Text = "";
                    textName.Text = "";
                    textLastName.Text = "";
                    textPhone.Text = ""; 
                    textMail.Text = "";
                    textAddress.Text = "";
                    textPuesto.Text = "";
                    textUsuario.Text = "";
                    textContrasena.Text = "";
                    cmbTipo_usuario.Text = "";
                }
            }
            //Caso contrario el action tenga valor 0 indica que se guardaran los cambios 
            else if (action == 0)
            {
                if (textName.Text == "" || textName.Text == "" || textLastName.Text == "" || textPhone.Text == "" || textMail.Text == "" || textAddress.Text == ""|| textPuesto.Text==""|| textUsuario.Text == ""|| textContrasena.Text == ""|| cmbTipo_usuario.Text=="")
                {
                    MessageBox.Show("Valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //guardar actualizacion

                    long? DPI_usuario = buscar_id();

                    if (rbS.Checked == true)
                    {
                        activ = "S";
                    }

                    else if (rbN.Checked == true)
                    {
                        activ = "N";
                    }


                    string Nombre = textName.Text;
                    string Apellidos = textLastName.Text;
                    string telefono = textPhone.Text;
                    string correo = textMail.Text;
                    string direccion = textAddress.Text;
                    string puesto = textPuesto.Text;
                    string usuario = textUsuario.Text;
                    string contraseña = textContrasena.Text;
                    string activo = activ;
                    string tipo_usuario = cmbTipo_usuario.Text;

                    usuariosContext.actualizar_usuario(DPI_usuario, Nombre, Apellidos, telefono, correo, direccion, puesto, usuario, contraseña, activo, tipo_usuario);
                    mostrar();
                    action = 1;
                    textName.Text = "";
                    textName.Text = "";
                    textLastName.Text = "";
                    textPhone.Text = "";
                    textMail.Text = "";
                    textAddress.Text = "";
                    textPuesto.Text = "";
                    textUsuario.Text = "";
                    textContrasena.Text = "";
                    cmbTipo_usuario.Text = "";
                }
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

                private void btnModificar_Click(object sender, EventArgs e)
                {
                    //El swicth cambia de 1 a 0 para indicar que se realizara una actualización. 
                    action = 0;
                    long? DPI_usuario = buscar_id();
                    Usuarios usuario_actualizar = usuariosContext.buscar(DPI_usuario);
                    textName.Text = usuario_actualizar.Nombre;
                    textLastName.Text = usuario_actualizar.Apellidos;
                    textPhone.Text = usuario_actualizar.telefono;
                    textMail.Text = usuario_actualizar.correo;
                    textAddress.Text = usuario_actualizar.direccion;
                    textPuesto.Text = usuario_actualizar.puesto;
                    textUsuario.Text = usuario_actualizar.usuario;
                    textContrasena.Text = usuario_actualizar.contraseña;
                    activ = usuario_actualizar.activo;
                    cmbTipo_usuario.Text = usuario_actualizar.tipo_usuario;

                    if (activ == "S")
                    {

                        rbS.Checked = true;
                    }

                    else if (activ == "N")
                    {
                        rbN.Checked = true;
                    }



                }
    }
}
