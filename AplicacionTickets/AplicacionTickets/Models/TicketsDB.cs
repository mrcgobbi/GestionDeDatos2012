using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AplicacionTickets.Models
{
    public class TicketsDB : DbContext
    {

        public TicketsDB()
            : base("DefaultConnection")
        {
        }

        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Espectaculo> Espectaculos { get; set; }
        public DbSet<Lugar> Lugares { get; set; }

    }
}