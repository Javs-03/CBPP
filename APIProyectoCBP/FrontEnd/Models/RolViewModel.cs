using System.ComponentModel.DataAnnotations;


namespace FrontEnd.Models
{
    public class RolViewModel
    {
        [Display(Name = "Id del Rol")]
        public int IdRol { get; set; } = 0;
        
        [Display(Name ="Descripción del Rol")]
        public string DescRol { get; set; } = "";

        public List<RolViewModel> Rol { get;set; }
    }
}
