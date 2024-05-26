using SistemaPOSPizzeria.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOSPizzeria.DataAccess.Interfaces
{
    interface IPedidoDetalleRepository
    {
        /// <summary>
        /// Método que devuelve una lista de todos los registros de la tabla pedido detalle.
        /// </summary>
        /// <returns>
        /// En caso de exito:
        /// Retorna el listado con los registros.
        /// Caso de error:
        /// Retorna un listado vacío.
        /// </returns>
        public IEnumerable<CabeceraDetalle> PedidosDetallesList();

        /// <summary>
        /// Método que nos permite crear un nuevo registro en la tabla pedido detalle.
        /// </summary>
        /// <param name="model">Datos correspondientes al pedido</param>
        /// <returns>
        /// En caso de exito:
        /// Retorna un entero con valor 0.
        /// Caso de error:
        /// Retorna un entero con valor de -1.
        /// </returns>
        public int Insert(CabeceraDetalle model);

        /// <summary>
        /// Método que nos permite actualizar un registro en la tabla pedido detalle.
        /// </summary>
        /// /// <param name="model">Datos correspondientes al pedido detalle</param>
        /// <returns>
        /// En caso de exito:
        /// Retorna un entero con valor 0.
        /// Caso de error:
        /// Retorna un entero con valor de -1.
        /// </returns>
        public int Update(CabeceraDetalle model);


        /// <summary>
        /// Método que nos permite eliminar un registro en la tabla pedido.
        /// </summary>
        /// <param name="pedido_Detalle_Id">Identificador único del pedido detalle</param>
        /// <returns>
        /// En caso de exito:
        /// Retorna un entero con valor -2.
        /// Caso de error:
        /// Retorna un entero con valor de -1.
        /// </returns>
        public int Delete(int pedido_Detalle_Id);
    }
}
