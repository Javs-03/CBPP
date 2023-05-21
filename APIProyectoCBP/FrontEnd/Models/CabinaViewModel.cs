using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FrontEnd.Models
{
    public class CabinaViewModel
    {
        public int IdCabina { get; set; } = 0;
        [Display(Name = "Tipo Cabina")]
        public string DescCabina { get; set; } = null!;

        [Display(Name = "Camas disponibles")]
        public int CamasDisponibles { get; set; } = 0;

        [Display(Name = "Personas")]
        public int CantidadPersonas { get; set; } = 0;

        [Display(Name = "Precio por noche")]
        public int PrecioNoche { get; set; } = 0;

        [Display(Name = "Disponibilidad")]
        public bool Disponible { get; set; } = false;

        public List<CabinaViewModel> Cabina { get; set; }
    }
}
