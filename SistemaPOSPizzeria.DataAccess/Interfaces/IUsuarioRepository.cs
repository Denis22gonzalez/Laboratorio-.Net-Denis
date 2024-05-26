using SistemaPOSPizzeria.DataAccess.Helper;
using SistemaPOSPizzeria.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOSPizzeria.DataAccess.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Método que nos permite crear un nuevo registro en la tabla usuarios.
        /// </summary>
        /// <param name="model">Datos correspondientes al cliente</param>
        /// <returns>
        /// En caso de exito:
        /// Retorna un entero con valor 0.
        /// Caso de error:
        /// Retorna un entero con valor de -1.
        /// </returns>
        public int Insert(Usuario model);


        /// <summary>
        /// Método que nos permite logearnos en el sistema.
        /// </summary>
        /// <param name="model">Datos correspondientes al user</param>
        /// <returns>
        /// En caso de exito:
        /// Retorna 1 si hay acceso.
        /// Caso de error:
        /// Retorna un entero con valor de -1.
        /// </returns>
        public UserResponseAuth Login(Usuario model);

    }
}
