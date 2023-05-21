using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Cliente
    {
        public Cliente()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int IdCliente { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public int NumTelefono { get; set; }
        public string Email { get; set; } = null!;
        public int Usuario { get; set; }

        public virtual Usuario UsuarioNavigation { get; set; } = null!;
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
