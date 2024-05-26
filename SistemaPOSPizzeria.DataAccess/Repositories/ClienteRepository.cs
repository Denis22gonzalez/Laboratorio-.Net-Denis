using Microsoft.Extensions.Logging;
using SistemaPOSPizzeria.DataAccess.Interfaces;
using SistemaPOSPizzeria.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaPOSPizzeria.DataAccess.Helper;
using Microsoft.Data.SqlClient;

namespace SistemaPOSPizzeria.DataAccess.Repositories
{
   public class ClienteRepository:IClienteRepository
    {
        private readonly SistemaPOSPizzeriaContext _context;
        public ClienteRepository(SistemaPOSPizzeriaContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Método que devuelve una lista de todos los registros de la tabla activos.
        /// </summary>
        /// <returns>
        /// En caso de exito:
        /// Retorna el listado con los registros.
        /// Caso de error:
        /// Retorna un listado vacío.
        /// </returns>
        public IEnumerable<Cliente> ClientesList()
        {
            try
            {
                IEnumerable<Cliente> clientes = _context.Clientes.FromSqlRaw(StoreProcedures.ClientesList).ToList();

                return clientes;
            }
            catch (Exception e)
            {

                throw;
            }
          
        }

        public int Insert(Cliente model)
        {
            int result = 0;
            try
            {

                result = _context.Database.ExecuteSqlRaw(StoreProcedures.ClientesInsert,
                    new SqlParameter("@cliente_nombre", model.Cliente_Nombre),
                    new SqlParameter("@cliente_apellido", model.Cliente_Apellido),
                    new SqlParameter("@cliente_correo", model.Cliente_Correo),
                    new SqlParameter("@cliente_telefono ", model.Cliente_Telefono));
                
                return result;

            }
            catch (Exception e)
            {
                string error=e.Message;
                return -1;
            }
        }

        public int Update(Cliente model)
        {
            int result = 0;
            try
            {

                result = _context.Database.ExecuteSqlRaw(StoreProcedures.ClientesUpdate,
                     new SqlParameter("@cliente_id", model.Cliente_Id),
                    new SqlParameter("@cliente_nombre", model.Cliente_Nombre),
                    new SqlParameter("@cliente_apellido", model.Cliente_Apellido),
                    new SqlParameter("@cliente_correo ", model.Cliente_Correo),
                    new SqlParameter("@cliente_telefono ", model.Cliente_Telefono));

                return result;

            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int Delete(int cliente_Id)
        {
            int result = 0;
            try
            {

                result = _context.Database.ExecuteSqlRaw(StoreProcedures.ClientesDelete,
                     new SqlParameter("@cliente_id", cliente_Id));

                return result;

            }
            catch (Exception)
            {
                return -1;
            }
        }


    }
}
