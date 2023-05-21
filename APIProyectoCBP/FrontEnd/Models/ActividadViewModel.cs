using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FrontEnd.Models
{
    public class ActividadViewModel
    {
        [Display(Name = "Id de la Actividad")]
        public int IdActividad { get; set; } = 0;
        [Display(Name = "Descripción de la actividad")]
        public string DescActividad { get; set; } = null!;

        [Display(Name = "Horario disponible")]
        public string HorarioDisponible { get; set; } = null!;

        [Display(Name = "Cupos de la actividad")]
        public int CuposDisponible { get; set; }

        public List<ActividadViewModel> Actividad { get; set; }
    }
}
