using SistemaPOSPizzeria.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOSPizzeria.DataAccess.Interfaces
{
   public interface IClienteDireccionRepository
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
        public IEnumerable<Direccion> DireccionesList(int idCliente);

        /// <summary>
        /// Método que nos permite crear un nuevo registro en la tabla direccion.
        /// </summary>
        /// <param name="model">Datos correspondientes al cliente</param>
        /// <returns>
        /// En caso de exito:
        /// Retorna un entero con valor 0.
        /// Caso de error:
        /// Retorna un entero con valor de -1.
        /// </returns>
        public int Insert(Direccion model);

        /// <summary>
        /// Método que nos permite actualizar un registro en la tabla direccion.
        /// </summary>
        /// /// <param name="model">Datos correspondientes a la direccion</param>
        /// <returns>
        /// En caso de exito:
        /// Retorna un entero con valor 0.
        /// Caso de error:
        /// Retorna un entero con valor de -1.
        /// </returns>
        public int Update(Direccion model);


        /// <summary>
        /// Método que nos permite eliminar un registro en la tabla direccion.
        /// </summary>
        /// <param name="direccion_Id">Identificador único de la direccion</param>
        /// <returns>
        /// En caso de exito:
        /// Retorna un entero con valor -2.
        /// Caso de error:
        /// Retorna un entero con valor de -1.
        /// </returns>
        public int Delete(int direccion_Id);
    }
}
