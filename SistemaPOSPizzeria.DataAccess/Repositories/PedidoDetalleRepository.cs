using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemaPOSPizzeria.DataAccess.Helper;
using SistemaPOSPizzeria.DataAccess.Interfaces;
using SistemaPOSPizzeria.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOSPizzeria.DataAccess.Repositories
{
   public class PedidoDetalleRepository: IPedidoDetalleRepository
    {
        private readonly SistemaPOSPizzeriaContext _context;
        public PedidoDetalleRepository(SistemaPOSPizzeriaContext context)
        {
            _context = context;
        }
        public IEnumerable<CabeceraDetalle> PedidosDetallesList(int pedido)
        {
            try
            {
                IEnumerable<CabeceraDetalle> pedidos = _context.CabeceraDetalles.FromSqlRaw(StoreProcedures.PedidosDetalleList, new SqlParameter("@pedido_id", pedido)).ToList();

                return pedidos;
            }
            catch (Exception e)
            {

                throw;
            }

        }
        public int Insert(CabeceraDetalle model)
        {
            int result = 0;
            try
            {

                result = _context.Database.ExecuteSqlRaw(StoreProcedures.PedidosDetalleInsert,
                    new SqlParameter("@pedido_id", model.pedido_id),
                    new SqlParameter("@producto_id", model.Producto_Id),
                    new SqlParameter("@pedido_detalle_cantidad", model.pedido_detalle_cantidad),
                    new SqlParameter("@pedido_detalle_subtotal", model.pedido_detalle_subtotal));

                return result;

            }
            catch (Exception e)
            {
                string error = e.Message;
                return -1;
            }
        }
        public int Update(CabeceraDetalle model)
        {
            int result = 0;
            try
            {

                result = _context.Database.ExecuteSqlRaw(StoreProcedures.PedidosDetalleUpdate,
                     new SqlParameter("@pedido_detalle_id", model.pedido_detalle_id),                 
                    new SqlParameter("@producto_id", model.Producto_Id),
                    new SqlParameter("@pedido_detalle_cantidad", model.pedido_detalle_cantidad),
                    new SqlParameter("@pedido_detalle_subtotal", model.pedido_detalle_subtotal));

                return result;

            }
            catch (Exception e)
            {
                string error = e.Message;
                return -1;
            }
        }

        public int Delete(int pedidoDetalle_Id)
        {
            int result = 0;
            try
            {

                result = _context.Database.ExecuteSqlRaw(StoreProcedures.PedidosDetalleDelete,
                     new SqlParameter("@pedido_detalle_id", pedidoDetalle_Id));

                return result;

            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
