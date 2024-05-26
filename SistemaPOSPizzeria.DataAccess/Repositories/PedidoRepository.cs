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
   public class PedidoRepository:IPedidoRepository
    {
        private readonly SistemaPOSPizzeriaContext _context;

        public PedidoRepository(SistemaPOSPizzeriaContext context)
        {
            _context = context;
        }

        public IEnumerable<Pedido> PedidosList()
        {
            try
            {
                IEnumerable<Pedido> pedidos = _context.Pedidos.FromSqlRaw(StoreProcedures.PedidosList).ToList();

                return pedidos;
            }
            catch (Exception e)
            {

                throw;
            }

        }
        public int Insert(Pedido model)
        {
            int result = 0;
            try
            {

                result = _context.Database.ExecuteSqlRaw(StoreProcedures.PedidosInsert,
                    new SqlParameter("@cliente_id", model.Cliente_Id),
                    new SqlParameter("@pedido_fecha", model.pedido_fecha),
                    new SqlParameter("@estado_pedido_id", model.Estado_Pedido_Id),
                    new SqlParameter("@pedido_total", model.pedido_total));

                return result;

            }
            catch (Exception e)
            {
                string error = e.Message;
                return -1;
            }
        }
        public int Update(Pedido model)
        {
            int result = 0;
            try
            {

                result = _context.Database.ExecuteSqlRaw(StoreProcedures.PedidosUpdate,
                    new SqlParameter("@pedido_id", model.pedido_Id),
                    new SqlParameter("@cliente_id", model.Cliente_Id),
                    new SqlParameter("@pedido_fecha", model.pedido_fecha),
                    new SqlParameter("@estado_pedido_id", model.Estado_Pedido_Id),
                    new SqlParameter("@pedido_total", model.pedido_total));

                return result;

            }
            catch (Exception e)
            {
                string error = e.Message;
                return -1;
            }
        }

        public int Delete(int pedido_Id)
        {
            int result = 0;
            try
            {

                result = _context.Database.ExecuteSqlRaw(StoreProcedures.PedidosDelete,
                     new SqlParameter("@pedido_id", pedido_Id));

                return result;

            }
            catch (Exception)
            {
                return -1;
            }
        }

    }
}
