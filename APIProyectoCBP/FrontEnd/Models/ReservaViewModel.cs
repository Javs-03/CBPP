using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FrontEnd.Models
{
    public class ReservaViewModel
    {
        [Display(Name = "Id de Reserva")]
        public int IdReserva { get; set; } = 0;

        [Display(Name = "Cantidad de días")]
        public int CantDias { get; set; } = 0;

        [Display(Name = "Personas")]
        public int CantidadPersonas { get; set; } = 0;

        [Display(Name = "Precio total")]
        public int PrecioTotal { get; set; } = 0;
        public int Cliente { get; set; } = 0;
        public int Cabina { get; set; } = 0;
        public int Actividad { get; set; } = 0;

        public List<ReservaViewModel> Reserva { get; set; }
    }

}
