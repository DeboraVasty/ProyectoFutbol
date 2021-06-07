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
    public partial class ReporteAlquilerArbitros : Form
    {
        public ReporteAlquilerArbitrosDB alquilerContext = new ReporteAlquilerArbitrosDB();
        public ReporteAlquilerArbitros()
        {
            InitializeComponent();
        }
        public void mostrar()
        {
            dataGridView1.DataSource = alquilerContext.getalquiler(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            mostrar();
        }
    }
}
