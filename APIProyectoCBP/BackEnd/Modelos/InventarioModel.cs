namespace BackEnd.Modelos
{
    public class InventarioModel
    {
        public int IdProducto { get; set; }
        public string DescProducto { get; set; } = null!;
        public int CantidadDisponible { get; set; }
    }
}
