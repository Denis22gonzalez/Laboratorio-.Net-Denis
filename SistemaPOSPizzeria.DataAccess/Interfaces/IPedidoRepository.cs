using SistemaPOSPizzeria.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOSPizzeria.DataAccess.Interfaces
{
    interface IPedidoRepository
    {
        /// <summary>
        /// Método que devuelve una lista de todos los registros de la tabla pedido.
        /// </summary>
        /// <returns>
        /// En caso de exito:
        /// Retorna el listado con los registros.
        /// Caso de error:
        /// Retorna un listado vacío.
        /// </returns>
        public IEnumerable<TbPedido> PedidosList();

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
        public int Insert(TbPedido model);

        /// <summary>
        /// Método que nos permite actualizar un registro en la tabla pedido.
        /// </summary>
        /// /// <param name="model">Datos correspondientes al pedido</param>
        /// <returns>
        /// En caso de exito:
        /// Retorna un entero con valor 0.
        /// Caso de error:
        /// Retorna un entero con valor de -1.
        /// </returns>
        public int Update(TbPedido model);


        /// <summary>
        /// Método que nos permite eliminar un registro en la tabla pedido.
        /// </summary>
        /// <param name="pedido_Id">Identificador único del pedido</param>
        /// <returns>
        /// En caso de exito:
        /// Retorna un entero con valor -2.
        /// Caso de error:
        /// Retorna un entero con valor de -1.
        /// </returns>
        public int Delete(int pedido_Id);
    }
}
