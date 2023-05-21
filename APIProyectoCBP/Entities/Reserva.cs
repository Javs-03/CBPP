using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Reserva
    {
        public int IdReserva { get; set; }
        public int CantDias { get; set; } 
        public int CantidadPersonas { get; set; } 
        public int PrecioTotal { get; set; } 
        public int Cliente { get; set; } 
        public int Cabina { get; set; } 
        public int Actividad { get; set; } 

        public virtual Actividad ActividadNavigation { get; set; } = null!;
        public virtual Cabina CabinaNavigation { get; set; } = null!;
        public virtual Cliente ClienteNavigation { get; set; } = null!;
    }
}
