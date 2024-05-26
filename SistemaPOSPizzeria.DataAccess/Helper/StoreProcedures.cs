using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOSPizzeria.DataAccess.Helper
{
  public static  class StoreProcedures
    {
        //Clientes
        public static string ClientesList = "sp_tbClientes_List";
        public static string ClientesInsert = "sp_tbClientes_Insert @cliente_nombre,@cliente_apellido,@cliente_correo,@cliente_telefono";
        public static string ClientesUpdate = "sp_tbClientes_Update @cliente_id,@cliente_nombre,@cliente_apellido,@cliente_correo,@cliente_telefono";
        public static string ClientesDelete = "sp_tbClientes_Delete @cliente_id";

        //Clientes Direcciones
        public static string ClientesDireccionesList = "sp_tbClientes_Direcciones_List @cliente_id";
        public static string ClientesDireccionesInsert = "sp_tbClientes_Direcciones_Insert @cliente_id,@cliente_direccion_descripcion";
        public static string ClientesDireccionesUpdate = "sp_tbClientes_Direcciones_Update @cliente_direccion_id,@cliente_direccion_descripcion";
        public static string ClientesDireccionesDelete = "sp_tbClientes_Direcciones_Delete @cliente_direccion_id";

        //Pedidos
        public static string PedidosList = "sp_tbPedidos_List";
        public static string PedidosInsert = "sp_tbpedidos_Insert @cliente_id,@pedido_fecha,@estado_pedido_id,@pedido_total";
        public static string PedidosUpdate = "sp_tbpedidos_Update @pedido_id,@cliente_id,@pedido_fecha,@estado_pedido_id,@pedido_total";
        public static string PedidosDelete = "sp_tbPedidos_Delete  @pedido_id";




        //Pedidos Detalles
        public static string PedidosDetalleList = "sp_tbPedidos_Detalle_select @pedido_id";
        public static string PedidosDetalleInsert = "sp_tbPedidos_Detalle_Insertar @pedido_id,@producto_id,@pedido_detalle_cantidad,@pedido_detalle_subtotal";
        public static string PedidosDetalleUpdate = "sp_tbPedidos_Detalle_Update @pedido_detalle_id,@producto_id,@pedido_detalle_cantidad,@pedido_detalle_subtotal";
        public static string PedidosDetalleDelete = "sp_tbPedidos_detalle_Delete @pedido_detalle_id";

        //Productos
        public static string ProductosList = "sp_tbProductos_List";
        public static string ProductosInsert = "sp_tbProductos_Insert @producto_nombre,@producto_descripcion,@producto_precio,@producto_stok,@producto_Imagen";
        public static string ProductosUpdate = "sp_tbProductos_Update @producto_id,@producto_nombre,@producto_descripcion,@producto_precio,@producto_stok,@producto_Imagen";
        public static string ProductosDelete = "sp_tbProductos_Delete @producto_id";


        //users

        public static string UsuarioInsert = "sp_tbUsuario_Insert @usuario_nombre,@usuario_password";
        public static string UsuarioLogin = "sp_tbUsuario_Login @usuario_nombre,@usuario_password";

    }
}

