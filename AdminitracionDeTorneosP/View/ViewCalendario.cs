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
    public partial class ViewCalendario : Form
    {
        public ViewCalendario()
        {
            InitializeComponent();
        }

        private void ViewCalendario_Load(object sender, EventArgs e)
        {
            for(int f=1;f <= 60; f++)
            {
                dataGridView1.Rows.Add();

            }
        }
    }
}
