using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FrontEnd.Models
{
    public class InventarioViewModel
    {
        [Display(Name = "Id del Producto")]
        public int IdProducto { get; set; } = 0;
        
        [Display(Name = "Producto")]
        public string DescProducto { get; set; } = "";

        [Display(Name = "Cantidad disponible")]
        public int CantidadDisponible { get; set; } 

        public List<InventarioViewModel> Producto { get; set; }
    }
}
