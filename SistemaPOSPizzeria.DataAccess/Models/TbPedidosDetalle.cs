using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPOSPizzeria.DataAccess.Models
{
    public partial class TbPedidosDetalle
    {
        public int PedidoDetalleId { get; set; }
        public int? PedidoId { get; set; }
        public int? ProductoId { get; set; }
        public int? PedidoDetalleCantidad { get; set; }
        public decimal? PedidoDetalleSubtotal { get; set; }

        public virtual TbPedido Pedido { get; set; }
        public virtual TbProducto Producto { get; set; }
    }
}
