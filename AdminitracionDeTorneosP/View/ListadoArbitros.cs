using AdminitracionDeTorneosP.Database;
using AdminitracionDeTorneosP.Model;
using System;
using System.Windows.Forms;

namespace AdminitracionDeTorneosP.View
{
    public partial class ListadoArbitros : Form
    {
        refereeDB baseDatos = new refereeDB();

        public ListadoArbitros()
        {
            InitializeComponent();
            dataGridView1.DataSource = baseDatos.getRefereee();
        }
    }
}
