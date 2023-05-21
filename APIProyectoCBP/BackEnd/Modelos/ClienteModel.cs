namespace BackEnd.Modelos
{
    public class ClienteModel
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public int NumTelefono { get; set; }
        public string Email { get; set; } = null!;
        public int Usuario { get; set; }
    }
}
