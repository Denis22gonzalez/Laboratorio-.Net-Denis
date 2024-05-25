using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPOSPizzeria.DataAccess.Models
{
    public partial class TbClientesDireccione
    {
        public int ClienteDireccionId { get; set; }
        public int? ClienteId { get; set; }
        public string ClienteDireccionDescripcion { get; set; }

        public virtual TbCliente Cliente { get; set; }
    }
}
