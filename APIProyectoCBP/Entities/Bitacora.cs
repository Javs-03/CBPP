using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Bitacora
    {
        public long ConsecutivoError { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaHora { get; set; }
        public int CodigoError { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Origen { get; set; } = null!;

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
