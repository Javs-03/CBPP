using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Actividad
    {
        public Actividad()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int IdActividad { get; set; }
        public string DescActividad { get; set; } = null!;
        public string HorarioDisponible { get; set; } = null!;
        public int CuposDisponible { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
