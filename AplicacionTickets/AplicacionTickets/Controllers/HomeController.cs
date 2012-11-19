using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using AplicacionTickets.Models;


namespace MvcTickets.Web.Controllers
{
    public class HomeController : Controller
    {
        private TicketsDB db = new TicketsDB();

        //
        // GET: /Home/
        // GET: /?t=Concierto

        public ActionResult Index(string t = "")
        {
            var eSig = db.Espectaculos;


            var retornatipo = eSig.Where(e => e.Artista.Tipo == t).ToList();

            if (t != "" && retornatipo != null)
            {
                
                return View(eSig.Where(e => e.Artista.Tipo == t).OrderBy(e => e.FechaHora).Take(10).ToList());

            }
            else
                return View(eSig.OrderBy(e => e.FechaHora).Take(10).ToList());
        }


        //
        //GET: /Home/Destacados?t=Concierto

        public ActionResult Destacados(string t = "")
        {

            var espect = db.Espectaculos;

            var retornatipo = espect.Where(e => e.Artista.Tipo == t).ToList();

            if (t != "" && retornatipo != null)
            {
                return View(espect.Where(e => e.Artista.Tipo == t).OrderByDescending(e => e.Entradas.Count()).Take(10).ToList());

            }
            else
                return View(espect.OrderByDescending(e => e.Entradas.Count()).Take(10).ToList());
        }



        //
        // GET: /Home/Detalles/5

        public ActionResult Detalles(int id)
        {
            Espectaculo espectaculo = db.Espectaculos.Find(id);
            
            return View(espectaculo);
        }



        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

        [Authorize]
        public ActionResult Comprar(string tipoEnt, int id)
        {
            Espectaculo e = db.Espectaculos.Find(id);
            eCompra esp = new eCompra();
            esp.eId = e.EspectaculoId;
            if (tipoEnt == "G")
            {
                esp.tipoEnt = "G";
                return View(esp);
            }
            else
            {
                esp.tipoEnt = "N";
                return View(esp);
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult Comprar(eCompra compra)
        {
            if (ModelState.IsValid)
            {
                Espectaculo eOrig = db.Espectaculos.Find(compra.eId);

                if (compra.tipoEnt == "G")
                {
                    for (int i = 1; i <= compra.cant; i++)
                    {
                        db.Entradas.Add(
                            new Entrada
                            {
                                Espectaculo = eOrig,
                                Estado = "Comprada",
                                FechaVenta = DateTime.Now,
                                NumAsiento = compra.asiento,
                                NumFila = compra.fila,
                                Precio = eOrig.PrecioEGen,
                                UserName = compra.username
                            });
                    }

                    eOrig.CantGen = eOrig.CantGen - compra.cant; //a la cantidad original de entradas generales, le resto las que vendi
                    db.Entry(eOrig).State = EntityState.Modified;
                }
                else //si es una entrada numerada
                {
                    Entrada entrada = eOrig.Entradas.SingleOrDefault(e => e.NumFila == compra.fila && e.NumAsiento == compra.asiento);

                    if (entrada != null)    // si la entrada ya existe, le muestro la misma view para que cargue otra, todavia no se implemento una validacion js en la misma vista para evitar este paso
                    {
                        return View(compra);
                    }
                    else // si la entrada esta disponible
                    {
                        db.Entradas.Add(
                        new Entrada
                        {
                            Espectaculo = eOrig,
                            Estado = "Comprada",
                            FechaVenta = DateTime.Now,
                            NumAsiento = compra.asiento,
                            NumFila = compra.fila,
                            Precio = eOrig.PrecioENum,
                            UserName = compra.username
                        });

                        db.Entry(eOrig).State = EntityState.Modified;
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(compra);
        }

    }
}
