using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPOSPizzeria.DataAccess.Models
{
    public partial class TbCatalogoEstadosPedido
    {
        public TbCatalogoEstadosPedido()
        {
            TbPedidos = new HashSet<TbPedido>();
        }

        public int EstadoPedidoId { get; set; }
        public string EstadoPedidoDescripcion { get; set; }

        public virtual ICollection<TbPedido> TbPedidos { get; set; }
    }
}
