using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminitracionDeTorneosP.Model
{
   public class AlquilarCanchas
    {
        public int id_alquiler{
            get;
            set;
        }

        public long DPI {
            get;
            set; 
        }
        public string Nombre {
            get;
            set;
        }
        public string Apellidos {
            get;
            set;
        }
        public string telefono { 
            get;
            set;
        }
        public string correo
        {
            get;
            set;
        }

        public DateTime fecha {
            get; 
            set;
        }

        public TimeSpan HoraInicio {
            get; 
            set;
        }
        public TimeSpan HoraFinal { 
            get;
            set; 
        }

        
        public int cod_cancha
        {
            get;
            set;
        }

        public decimal pago_cancha { 
            get; 
            set; 
        }

        public long cod_arbitro
        {
            get;
            set;
        }

        public decimal pago_arbitro
        {
            get;
            set;
        }



    }
}
