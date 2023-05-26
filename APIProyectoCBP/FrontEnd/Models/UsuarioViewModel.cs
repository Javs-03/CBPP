using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FrontEnd.Models
{
    public class UsuarioViewModel
    {
        [Key]
        public int IdUsuario { get; set; } = 0;
        [Required(ErrorMessage = "Please Enter Username")]
        [Display(Name = "Please Enter Username")]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Please Enter Password")]
        public string Contrasena { get; set; }= string.Empty;
        
        [Display(Name = "Rol")]
        public int IdRol { get; set; } = 1;
        public string Estado { get; set; } = string.Empty;

        public List<UsuarioViewModel> Usuario { get; set; }
    }
}
