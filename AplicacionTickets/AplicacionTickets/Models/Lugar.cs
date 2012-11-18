using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionTickets.Models
{

    public class Lugar
    {
        public virtual int      LugarId { get; set; }
        public virtual string   Nombre { get; set; }
        public virtual string   Ciudad { get; set; }
        public virtual string   Provincia { get; set; }
        public virtual string   Direccion { get; set; }
        public virtual int      CantFilas { get; set; }
        public virtual int      AsientosFila { get; set; }

        public virtual ICollection<Espectaculo> Espectaculos { get; set; }


    }
}