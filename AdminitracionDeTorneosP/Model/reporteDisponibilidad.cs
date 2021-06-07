using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminitracionDeTorneosP.Model
{
  public  class reporteDisponibilidad
    {
        public DateTime fecha
        {  
            set;
            get;
           
        }

        public TimeSpan horaInicio
        {
            set;
            get;

        }

        public TimeSpan horaFin
        {
            set;
            get;

        }


    }
}
