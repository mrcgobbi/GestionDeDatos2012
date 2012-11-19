using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AplicacionTickets.Models
{
    public class eRecaudac
    {
        public Espectaculo e;
        public decimal rReal;
        public decimal rPotencial;
    }

    public class eOcupacion
    {
        public Espectaculo e;
        public decimal Ocup;
    }

    public class aRecaudacion
    {
        public Artista a;
        public decimal rec;
    }

    public class eCompra
    {
        public int eId {get;set;}
        public int cant { get; set; }
        public int fila { get; set; }
        public int asiento { get; set; }
        public string tipoEnt { get; set; }
        public string username { get; set; }
       
    }
}