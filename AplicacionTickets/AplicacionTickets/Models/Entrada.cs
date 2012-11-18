using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionTickets.Models
{
    public class Entrada
    {
        public virtual int          EntradaId { get; set; }
        public virtual int          EspectaculoId { get; set; }
        public virtual string       UserName { get; set; }
        public virtual string       Estado { get; set; }
        public virtual decimal      Precio { get; set; }
        public virtual DateTime     FechaVenta { get; set; }
        public virtual int          NumFila { get; set; }
        public virtual int          NumAsiento { get; set; }

        public virtual Espectaculo  Espectaculo { get; set; }
    }
}