using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOSPizzeria.DataAccess.Models
{
   public class Cliente
    {
        public Cliente()
        {
            //Direcciones = new HashSet<Direccion>();
            //Pedidos = new HashSet<Pedido>();
        }

        public int Cliente_Id { get; set; }
        public string Cliente_Nombre { get; set; }
        public string Cliente_Apellido { get; set; }
        public string Cliente_Correo { get; set; }
        public string Cliente_Telefono { get; set; }

        //public virtual ICollection<Direccion> Direcciones { get; set; }
        //public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
