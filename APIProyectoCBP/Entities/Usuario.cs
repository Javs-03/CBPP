using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Bitacoras = new HashSet<Bitacora>();
            Clientes = new HashSet<Cliente>();
        }

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public int Rol { get; set; }
        public bool Estado { get; set; }

        public virtual Rol RolNavigation { get; set; } = null!;
        public virtual ICollection<Bitacora> Bitacoras { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
