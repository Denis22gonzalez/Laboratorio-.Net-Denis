using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOSPizzeria.DataAccess.Models
{
    public class CabeceraDetalle
    {
        public int pedido_detalle_id { get; set; }
        public int? pedido_id { get; set; }
        public int? Producto_Id { get; set; }
        public int? pedido_detalle_cantidad { get; set; }
        public decimal? pedido_detalle_subtotal { get; set; }
        public string Producto_Nombre { get; set; }
        //public virtual Pedido Pedido { get; set; }
        //public virtual TbProducto Producto { get; set; }



        //pedido_detalle_id Cliente_Nombre  Cliente_Apellido pedido_id   Producto_Nombre Producto_Descripcion    Producto_Imagen pedido_detalle_cantidad pedido_detalle_subtotal
    }
}
