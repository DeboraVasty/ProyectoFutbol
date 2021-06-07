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
    public partial class Reporte_Bitacora : Form
    {

        public bitacoraDB bitacoraContext = new bitacoraDB();
        public Reporte_Bitacora()
        {
            InitializeComponent();
        }

        public void mostrar()
        {
            dataGridView1.DataSource = bitacoraContext.getBitacora(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text),textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mostrar();
        }

        private void Reporte_Bitacora_Load(object sender, EventArgs e)
        {

        }
    }
}
