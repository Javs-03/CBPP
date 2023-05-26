using Entities;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Modelos
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public int Rol { get; set; }
        public bool Estado { get; set; }

    }
}
