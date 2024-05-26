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
   public class ClienteDireccionRepository:IClienteDireccionRepository
    {
        private readonly SistemaPOSPizzeriaContext _context;
        public ClienteDireccionRepository(SistemaPOSPizzeriaContext context)
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
        public IEnumerable<Direccion> DireccionesList(int idCliente)
        {
            try
            {
                IEnumerable<Direccion> clientesDirecciones = _context.Direcciones.FromSqlRaw(StoreProcedures.ClientesDireccionesList, 
                    new SqlParameter("@cliente_id", idCliente)).ToList();

                return clientesDirecciones;
            }
            catch (Exception e)
            {

                throw;
            }

        }
        public int Insert(Direccion model)
        {
            int result = 0;
            try
            {

                result = _context.Database.ExecuteSqlRaw(StoreProcedures.ClientesDireccionesInsert,
                    new SqlParameter("@cliente_id", model.Cliente_Id),
                    new SqlParameter("@cliente_direccion_descripcion", model.Cliente_Direccion_Descripcion));

                return result;

            }
            catch (Exception e)
            {
                string error = e.Message;
                return -1;
            }
        }

        public int Update(Direccion model)
        {
            int result = 0;
            try
            {

                result = _context.Database.ExecuteSqlRaw(StoreProcedures.ClientesDireccionesUpdate,
                     new SqlParameter("@cliente_direccion_id", model.Cliente_Direccion_Id),
                    new SqlParameter("@cliente_direccion_descripcion", model.Cliente_Direccion_Descripcion));

                return result;

            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int Delete(int clienteDireccion_Id)
        {
            int result = 0;
            try
            {

                result = _context.Database.ExecuteSqlRaw(StoreProcedures.ClientesDireccionesDelete,
                     new SqlParameter("@cliente_direccion_id", clienteDireccion_Id));

                return result;

            }
            catch (Exception)
            {
                return -1;
            }
        }

    }
}
