using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Inventario
    {
        public int IdProducto { get; set; }
        public string DescProducto { get; set; } = null!;
        public int CantidadDisponible { get; set; }
    }
}
