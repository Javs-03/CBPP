namespace BackEnd.Modelos
{
    public class CabinaModel
    {
        public int IdCabina { get; set; }
        public string DescCabina { get; set; } = null!;
        public int CamasDisponibles { get; set; }
        public int CantidadPersonas { get; set; }
        public int PrecioNoche { get; set; }
        public bool Disponible { get; set; }
    }
}
