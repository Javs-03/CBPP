using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FrontEnd.Models
{
    public class ClienteViewModel
    {
        [Display(Name = "Id Cliente")]
        public int IdCliente { get; set; } = 0;
        
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = null!;
        
        [Display(Name = "Apellidos")]
        public string Apellido { get; set; } = null!;

        [Display(Name = "Dirección")]
        public string Direccion { get; set; } = null!;

        [Display(Name = "Teléfono")]
        public int NumTelefono { get; set; } = 0;

        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Display(Name = "Id Usuario")]
        public int Usuario { get; set; } = 0;

        public List<ClienteViewModel> Cliente { get; set; }
    }
}
