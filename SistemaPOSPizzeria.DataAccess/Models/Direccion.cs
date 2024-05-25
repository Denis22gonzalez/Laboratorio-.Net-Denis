using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOSPizzeria.DataAccess.Models
{
    class Direccion
    {
        public int ClienteDireccionId { get; set; }
        public int? ClienteId { get; set; }
        public string ClienteDireccionDescripcion { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
