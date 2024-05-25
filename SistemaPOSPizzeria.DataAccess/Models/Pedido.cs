using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOSPizzeria.DataAccess.Models
{
    class Pedido
    {
        public Pedido()
        {
            PedidosDetalles = new HashSet<CabeceraDetalle>();
        }

        public int PedidoId { get; set; }
        public int? ClienteId { get; set; }
        public DateTime? PedidoFecha { get; set; }
        public int? EstadoPedidoId { get; set; }
        public decimal? PedidoTotal { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual TbCatalogoEstadosPedido EstadoPedido { get; set; }
        public virtual ICollection<CabeceraDetalle> PedidosDetalles { get; set; }
    }
}
