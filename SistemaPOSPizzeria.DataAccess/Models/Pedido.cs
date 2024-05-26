using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOSPizzeria.DataAccess.Models
{
    public class Pedido
    {
        public Pedido()
        {
            //PedidosDetalles = new HashSet<CabeceraDetalle>();
        }

        public int pedido_Id { get; set; }
        public int Cliente_Id { get; set; }
        //public int? ClienteId { get; set; }
        public string Cliente_Nombre { get; set; }
        public string Cliente_Apellido { get; set; }
        public DateTime? pedido_fecha { get; set; }
        public int Estado_Pedido_Id { get; set; }
        public string Estado_Pedido_Descripcion { get; set; }
        // public int? EstadoPedidoId { get; set; }
       
        public decimal? pedido_total { get; set; }

        //public virtual Cliente Cliente { get; set; }
        //public virtual TbCatalogoEstadosPedido EstadoPedido { get; set; }
        //public virtual ICollection<CabeceraDetalle> PedidosDetalles { get; set; }
    }
}
