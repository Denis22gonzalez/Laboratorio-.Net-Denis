using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPOSPizzeria.DataAccess.Models
{
    public partial class TbPedido
    {
        public TbPedido()
        {
            TbPedidosDetalles = new HashSet<TbPedidosDetalle>();
        }

        public int PedidoId { get; set; }
        public int? ClienteId { get; set; }
        public DateTime? PedidoFecha { get; set; }
        public int? EstadoPedidoId { get; set; }
        public decimal? PedidoTotal { get; set; }

        public virtual TbCliente Cliente { get; set; }
        public virtual TbCatalogoEstadosPedido EstadoPedido { get; set; }
        public virtual ICollection<TbPedidosDetalle> TbPedidosDetalles { get; set; }
    }
}
