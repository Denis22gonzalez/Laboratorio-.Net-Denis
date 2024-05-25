using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPOSPizzeria.DataAccess.Models
{
    public partial class TbCliente
    {
        public TbCliente()
        {
            TbClientesDirecciones = new HashSet<TbClientesDireccione>();
            TbPedidos = new HashSet<TbPedido>();
        }

        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteApellido { get; set; }
        public string ClienteCorreo { get; set; }
        public string ClienteTelefono { get; set; }

        public virtual ICollection<TbClientesDireccione> TbClientesDirecciones { get; set; }
        public virtual ICollection<TbPedido> TbPedidos { get; set; }
    }
}
