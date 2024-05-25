using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOSPizzeria.DataAccess.Models
{
    class Cliente
    {
        public Cliente()
        {
            Direcciones = new HashSet<Direccion>();
            TbPedidos = new HashSet<TbPedido>();
        }

        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteApellido { get; set; }
        public string ClienteCorreo { get; set; }
        public string ClienteTelefono { get; set; }

        public virtual ICollection<Direccion> Direcciones { get; set; }
        public virtual ICollection<TbPedido> TbPedidos { get; set; }
    }
}
