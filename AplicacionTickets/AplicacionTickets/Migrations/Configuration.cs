namespace AplicacionTickets.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AplicacionTickets.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AplicacionTickets.Models.TicketsDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AplicacionTickets.Models.TicketsDB context)
        {
            //  This method will be called after migrating to the latest version.

            context.Artistas.AddOrUpdate(a => a.Nombre,
                new Artista { Nombre = "Molotov", Genero = "Rock alternativo", Tipo = "Concierto" },
                new Artista { Nombre = "The CureHeads", Genero = "Rock", Tipo = "Concierto" },
                new Artista { Nombre = "Creed", Genero = "Hard Rock", Tipo = "Concierto" },
                new Artista { Nombre = "Argentina vs. Brasil", Genero = "Futbol", Tipo = "Deporte" },
                new Artista { Nombre = "Les Luthiers", Genero = "Comedia", Tipo = "Teatro" },
                new Artista { Nombre = "Estopa", Genero = "Rumba", Tipo = "Concierto" },
                new Artista { Nombre = "Nonpalidece", Genero = "Reggae", Tipo = "Concierto" },
                new Artista { Nombre = "Kapanga", Genero = "Ska", Tipo = "Concierto" },
                new Artista { Nombre = "Mancha de Rolando", Genero = "Rock Barrial", Tipo = "Concierto" }
            );

            context.Lugares.AddOrUpdate(l => l.Nombre,
                new Lugar { Nombre = "La Trastienda Club (LP)", Ciudad = "La Plata", Provincia = "Buenos Aires", Direccion = "Calle 001 n140", CantFilas = 10, AsientosFila = 15 },
                new Lugar { Nombre = "GROOVE", Ciudad = "Palermo, CABA", Provincia = "Buenos Aires", Direccion = "Av. Santa Fé 4389", CantFilas = 16, AsientosFila = 22 },
                new Lugar { Nombre = "Estadio Malvinas Argentinas", Ciudad = "Mendoza", Provincia = "Mendoza", Direccion = "Parque General San Martin", CantFilas = 36, AsientosFila = 335 },
                new Lugar { Nombre = "La Bombonera", Ciudad = "La Boca, CABA", Provincia = "Buenos Aires", Direccion = "Calle Amarilla n2406", CantFilas = 34, AsientosFila = 355 },
                new Lugar { Nombre = "Teatro Gran Rex", Ciudad = "CABA", Provincia = "Buenos Aires", Direccion = "Av. Corrientes n857", CantFilas = 60, AsientosFila = 50 },
                new Lugar { Nombre = "Teatro El Circulo", Ciudad = "Rosario", Provincia = "Rosario", Direccion = "Laprida 1223", CantFilas = 40, AsientosFila = 45 },
                new Lugar { Nombre = "Teatro Vorterix", Ciudad = "Colegiales, CABA", Provincia = "Buenos Aires", Direccion = "Av. Federico Lacroze 3455", CantFilas = 35, AsientosFila = 55 }
            );

            context.Espectaculos.AddOrUpdate(e => new { e.Titulo, e.FechaHora },
                new Espectaculo { Titulo = "Molotov (La Plata)", Descripcion = "MOLOTOV se presenta el sábado 2 de Diciembre en La Trastienda Club de La Plata.", FechaHora = DateTime.Parse("02/12/2012"), FechaLimite = DateTime.Parse("01/12/2012"), Estado = "Abierto", Artista = context.Artistas.Single(a => a.Nombre == "Molotov"), Lugar = context.Lugares.Single(l => l.Nombre == "La Trastienda Club (LP)"), CantGen = 120, PrecioEGen = 150, PrecioENum = 220, EspectaculoImageUrl = "/Content/Images/placeholder.gif" },
                new Espectaculo { Titulo = "The CureHeads: Tributo a The Cure", Descripcion = "Celebrando 25 años de los legendarios conciertos de The Cure en Argentina.", FechaHora = DateTime.Parse("30/11/2012"), FechaLimite = DateTime.Parse("28/11/2012"), Estado = "Abierto", Artista = context.Artistas.Single(a => a.Nombre == "The CureHeads"), Lugar = context.Lugares.Single(l => l.Nombre == "GROOVE"), CantGen = 500, PrecioEGen = 200, PrecioENum = 380, EspectaculoImageUrl = "/Content/Images/placeholder.gif" },
                new Espectaculo { Titulo = "Creed", Descripcion = "CREED, por primera vez en Sudamérica.", FechaHora = DateTime.Parse("29/11/2012"), FechaLimite = DateTime.Parse("28/11/2012"), Estado = "Abierto", Artista = context.Artistas.Single(a => a.Nombre == "Creed"), Lugar = context.Lugares.Single(l => l.Nombre == "Estadio Malvinas Argentinas"), CantGen = 660, PrecioEGen = 350, PrecioENum = 400, EspectaculoImageUrl = "/Content/Images/placeholder.gif" },
                new Espectaculo { Titulo = "Superclasico de las Américas", Descripcion = "La selección de Argentina recibirá el próximo 21 de noviembre a su similar de Brasil, en el Estadio 'La Bombonera', en la revancha del Superclásico de las Américas. ", FechaHora = DateTime.Parse("21/11/2012"), FechaLimite = DateTime.Parse("20/11/2012"), Estado = "Abierto", Artista = context.Artistas.Single(a => a.Nombre == "Argentina vs. Brasil"), Lugar = context.Lugares.Single(l => l.Nombre == "La Bombonera"), CantGen = 105, PrecioEGen = 110, PrecioENum = 250, EspectaculoImageUrl = "/Content/Images/placeholder.gif" },
                new Espectaculo { Titulo = "Estopa", Descripcion = "-- -- -- -- -- --", FechaHora = DateTime.Parse("29/11/2012"), FechaLimite = DateTime.Parse("28/11/2012"), Estado = "Abierto", Artista = context.Artistas.Single(a => a.Nombre == "Estopa"), Lugar = context.Lugares.Single(l => l.Nombre == "Teatro El Circulo"), CantGen = 0, PrecioEGen = 0, PrecioENum = 140, EspectaculoImageUrl = "/Content/Images/placeholder.gif" },
                new Espectaculo { Titulo = "Les Luthiers: Lutherapia", Descripcion = "¡Vuelve por unos días el mejor espectáculo de Les Luthiers! Luego del éxito obtenido en Madrid y a pedido del público. ", FechaHora = DateTime.Parse("11/01/2013"), FechaLimite = DateTime.Parse("10/01/2013"), Estado = "Abierto", Artista = context.Artistas.Single(a => a.Nombre == "Les Luthiers"), Lugar = context.Lugares.Single(l => l.Nombre == "Teatro Gran Rex"), CantGen = 0, PrecioEGen = 0, PrecioENum = 120, EspectaculoImageUrl = "/Content/Images/placeholder.gif" },
                new Espectaculo { Titulo = "Kapanga!", Descripcion = "-- -- -- -- -- --", FechaHora = DateTime.Parse("01/12/2012"), FechaLimite = DateTime.Parse("29/11/2012"), Estado = "Abierto", Artista = context.Artistas.Single(a => a.Nombre == "Kapanga"), Lugar = context.Lugares.Single(l => l.Nombre == "GROOVE"), CantGen = 230, PrecioEGen = 100, PrecioENum = 150, EspectaculoImageUrl = "/Content/Images/placeholder.gif" },
                new Espectaculo { Titulo = "Kapanga!", Descripcion = "-- -- -- -- -- --", FechaHora = DateTime.Parse("09/12/2012"), FechaLimite = DateTime.Parse("07/12/2012"), Estado = "Abierto", Artista = context.Artistas.Single(a => a.Nombre == "Kapanga"), Lugar = context.Lugares.Single(l => l.Nombre == "Teatro Vorterix"), CantGen = 140, PrecioEGen = 110, PrecioENum = 160, EspectaculoImageUrl = "/Content/Images/placeholder.gif" },
                new Espectaculo { Titulo = "Mancha de Rolando", Descripcion = "-- -- -- -- -- --", FechaHora = DateTime.Parse("09/12/2012"), FechaLimite = DateTime.Parse("08/12/2012"), Estado = "Abierto", Artista = context.Artistas.Single(a => a.Nombre == "Mancha de Rolando"), Lugar = context.Lugares.Single(l => l.Nombre == "Teatro Vorterix"), CantGen = 120, PrecioEGen = 100, PrecioENum = 145, EspectaculoImageUrl = "/Content/Images/placeholder.gif" },
                new Espectaculo { Titulo = "Nonpalidece", Descripcion = "-- -- -- -- -- --", FechaHora = DateTime.Parse("06/12/2012"), FechaLimite = DateTime.Parse("05/12/2012"), Estado = "Abierto", Artista = context.Artistas.Single(a => a.Nombre == "Nonpalidece"), Lugar = context.Lugares.Single(l => l.Nombre == "Teatro Vorterix"), CantGen = 140, PrecioEGen = 80, PrecioENum = 120, EspectaculoImageUrl = "/Content/Images/placeholder.gif" }
                );
        }
    }
}
