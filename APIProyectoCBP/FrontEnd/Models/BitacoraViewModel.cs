using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class BitacoraViewModel
    {
        [Display(Name = "Número de registro")]
        public long ConsecutivoError { get; set; }
        
        [Display(Name = "Usuario")]
        public int IdUsuario { get; set; }

        [Display(Name = "Fecha y Hora")]
        public DateTime FechaHora { get; set; }

        [Display(Name = "Código")]
        public int CodigoError { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; } = null!;

        [Display(Name = "Origen")]
        public string Origen { get; set; } = null!;

        public List<BitacoraViewModel> Bitacora { get; set; }
    }
}
