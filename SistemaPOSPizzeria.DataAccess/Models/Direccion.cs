using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOSPizzeria.DataAccess.Models
{
   public class Direccion
    {
        public int Cliente_Direccion_Id { get; set; }
        public int? Cliente_Id { get; set; }
        public string Cliente_Direccion_Descripcion { get; set; }

        //public virtual Cliente Cliente { get; set; }
    }
}
