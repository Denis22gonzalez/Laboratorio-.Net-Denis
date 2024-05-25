using SistemaPOSPizzeria.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOSPizzeria.DataAccess.Interfaces
{
    interface IClienteRepository
    {
        /// <summary>
        /// Método que devuelve una lista de todos los registros de la tabla cliente.
        /// </summary>
        /// <returns>
        /// En caso de exito:
        /// Retorna el listado con los registros.
        /// Caso de error:
        /// Retorna un listado vacío.
        /// </returns>
        public IEnumerable<TbCliente> ClientesList();

        /// <summary>
        /// Método que nos permite crear un nuevo registro en la tabla productos.
        /// </summary>
        /// <param name="model">Datos correspondientes al cliente</param>
        /// <returns>
        /// En caso de exito:
        /// Retorna un entero con valor 0.
        /// Caso de error:
        /// Retorna un entero con valor de -1.
        /// </returns>
        public int Insert(TbCliente model);

        /// <summary>
        /// Método que nos permite actualizar un registro en la tabla cliente.
        /// </summary>
        /// /// <param name="model">Datos correspondientes al cliente</param>
        /// <returns>
        /// En caso de exito:
        /// Retorna un entero con valor 0.
        /// Caso de error:
        /// Retorna un entero con valor de -1.
        /// </returns>
        public int Update(TbCliente model);


        /// <summary>
        /// Método que nos permite eliminar un registro en la tabla cliente.
        /// </summary>
        /// <param name="cliente_Id">Identificador único del cliente</param>
        /// <returns>
        /// En caso de exito:
        /// Retorna un entero con valor -2.
        /// Caso de error:
        /// Retorna un entero con valor de -1.
        /// </returns>
        public int Delete(int cliente_Id);

    }
}
