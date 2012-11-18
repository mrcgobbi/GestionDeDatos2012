using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AplicacionTickets.Models
{
    public class Espectaculo
    {

        public virtual int          EspectaculoId { get; set; }
        public virtual int          ArtistaId { get; set; }
        public virtual int          LugarId { get; set; }
        public virtual string       Titulo { get; set; }
        public virtual string       Descripcion { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime     FechaHora { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime     FechaLimite { get; set; }
        public virtual string       Estado { get; set; }
        public virtual decimal      PrecioEGen { get; set; }
        public virtual decimal      PrecioENum { get; set; }
        public virtual int          CantGen { get; set; }
        public virtual string       EspectaculoImageUrl { get; set; }

        public virtual Lugar Lugar { get; set; }
        public virtual Artista Artista { get; set; }
        public virtual ICollection<Entrada> Entradas { get; set; }

    }
}