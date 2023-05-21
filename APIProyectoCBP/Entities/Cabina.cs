using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Cabina
    {
        public Cabina()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int IdCabina { get; set; }
        public string DescCabina { get; set; } = null!;
        public int CamasDisponibles { get; set; }
        public int CantidadPersonas { get; set; }
        public int PrecioNoche { get; set; }
        public bool Disponible { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
