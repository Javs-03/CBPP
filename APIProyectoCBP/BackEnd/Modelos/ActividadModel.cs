namespace BackEnd.Modelos
{
    public class ActividadModel
    {
        public int IdActividad { get; set; }
        public string DescActividad { get; set; } = null!;
        public string HorarioDisponible { get; set; } = null!;
        public int CuposDisponible { get; set; }
    }
}
