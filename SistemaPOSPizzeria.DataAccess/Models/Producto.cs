using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOSPizzeria.DataAccess.Models
{
   public class Producto
    {
        public int Producto_Id { get; set; }
        public string Producto_Nombre { get; set; }
        public string Producto_Descripcion { get; set; }
        public decimal? Producto_Precio { get; set; }
        public int? Producto_Stok { get; set; }
        public string Producto_Imagen { get; set; }
    }
}
