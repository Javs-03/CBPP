using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FrontEnd.Models
{
    public class UsuarioViewModel
    {
        public int IdUsuario { get; set; } = 0;
        [Display(Name = "Usuario")]
        public string NombreUsuario { get; set; } = string.Empty;
        
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }= string.Empty;
        
        [Display(Name = "Rol")]
        public int IdRol { get; set; } = 1;
        public string Estado { get; set; } = string.Empty;

        public List<UsuarioViewModel> Usuario { get; set; }
    }
}
