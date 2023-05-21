namespace BackEnd.Modelos
{
    public class ReservaModel
    {
        public int IdReserva { get; set; } 
        public int CantDias { get; set; }
        public int CantidadPersonas { get; set; }
        public int PrecioTotal { get; set; }
        public int Cliente { get; set; }
        public int Cabina { get; set; }
        public int Actividad { get; set; }
    }
}
