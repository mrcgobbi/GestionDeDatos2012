using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionTickets.Models
{
    public class Artista
    {
        public virtual int          ArtistaId { get; set; }
        public virtual string       Nombre { get; set; }
        public virtual string       Genero { get; set; }
        public virtual string       Tipo { get; set; }

        public virtual List<Espectaculo> Espectaculos { get; set; }

    }
}