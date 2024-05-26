using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOSTPizzeria.Presentation.Models
{
    public class generic_ViewModels
    {
       
    }

    public class usuario_ViewModel
    {
        
        public string UsuarioNombre { get; set; }
        public string UsuarioPassword { get; set; }
    }

    public class response_ViewModel
    {
        public string Token { get; set; }
    }

    public class productos_ViewModel
    {
        public int Producto_Id { get; set; }
        public string Producto_Nombre { get; set; }
        public string Producto_Descripcion { get; set; }
        public decimal? Producto_Precio { get; set; }
        public int? Producto_Stok { get; set; }
        public string Producto_Imagen { get; set; }
    }

    public class pedidos_viewModel
    {

        public int pedido_Id { get; set; }
        public int Cliente_Id { get; set; }
        //public int? ClienteId { get; set; }
        public string Cliente_Nombre { get; set; }
        public string Cliente_Apellido { get; set; }
        public DateTime? pedido_fecha { get; set; }
        public int Estado_Pedido_Id { get; set; }
        public string Estado_Pedido_Descripcion { get; set; }
    }

    public class pedidos_Detalle_viewModel
    {
        public int pedido_detalle_id { get; set; }
        public int? pedido_id { get; set; }
        public int? Producto_Id { get; set; }
        public int? pedido_detalle_cantidad { get; set; }
        public decimal? pedido_detalle_subtotal { get; set; }
        public string Producto_Nombre { get; set; }
    }

    public static class TokenManager
    {
        public static string JwtToken { get; set; }
    }
}

