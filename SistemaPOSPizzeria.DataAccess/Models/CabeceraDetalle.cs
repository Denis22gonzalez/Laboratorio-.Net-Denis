using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOSPizzeria.DataAccess.Models
{
   public class CabeceraDetalle
    {
        public int PedidoDetalleId { get; set; }
        public int? PedidoId { get; set; }
        public int? ProductoId { get; set; }
        public int? PedidoDetalleCantidad { get; set; }
        public decimal? PedidoDetalleSubtotal { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual TbProducto Producto { get; set; }
    }
}
