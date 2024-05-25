using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPOSPizzeria.DataAccess.Models
{
    public partial class TbProducto
    {
        public TbProducto()
        {
            TbPedidosDetalles = new HashSet<TbPedidosDetalle>();
        }

        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public string ProductoDescripcion { get; set; }
        public decimal? ProductoPrecio { get; set; }
        public int? ProductoStok { get; set; }
        public string ProductoImagen { get; set; }

        public virtual ICollection<TbPedidosDetalle> TbPedidosDetalles { get; set; }
    }
}
