using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using AplicacionTickets.Models;

namespace AplicacionTickets.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class AdminController : Controller
    {

        private TicketsDB db = new TicketsDB();


        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }



        //
        // GET: /Admin/Concurrencia
        public ActionResult Concurrencia(int or = 0) //la "or" de Orden, para ver si es ascend o descen
        {
            var Econcurrencia = db.Espectaculos;

            if (or == 0)
            {
                ViewBag.Mensaje = "Ranking de espectaculos mas concurridos";
                return View(Econcurrencia.OrderByDescending(e => e.Entradas.Count()).ToList());
            }
            else
            {
                ViewBag.Mensaje = "Ranking de espectaculos menos concurridos";
                return View(Econcurrencia.OrderBy(e => e.Entradas.Count()).ToList());
            }
        }


        //
        // GET: /Admin/EOfrecidos
        public ActionResult EOfrecidos(int or = 0)
        {
            var Eofrecidos = db.Artistas;

            if (or == 0)
            {
                ViewBag.Mensaje = "Ranking de los artistas que mas espectaculos ofrecieron";
                return View(Eofrecidos.OrderByDescending(a => a.Espectaculos.Count()).ToList());
            }
            else
            {
                ViewBag.Mensaje = "Ranking de los artistas que menos espectaculos ofrecieron";
                return View(Eofrecidos.OrderBy(a => a.Espectaculos.Count()).ToList());
            }
        }


        //
        //Admin/ARecaudacion 
        //NO ORDENA, porque temporalmente estoy usando un string para almacenar los datos, pero el calculo respectivo esta perfecto!
        public ActionResult ARecaudacion (int or = 0)
        {
            List<Artista> artistas = db.Artistas.ToList();
            List<aRecaudacion> recaudaciones = new List<aRecaudacion>();


            foreach (var item in artistas)
            {
                aRecaudacion registro = new aRecaudacion();

                registro.a = item;
                registro.rec = 0;

                foreach (var espect in item.Espectaculos)
                {
                   registro.rec = registro.rec + espect.Entradas.Where(en => en.NumAsiento == 0).Count() * espect.PrecioEGen + espect.Entradas.Where(en => en.NumAsiento != 0).Count() * espect.PrecioENum;
                   //sumo lo que recaudo cada espectaculo del artista para obtener una var que me el total de recaudacion del artista
                }

                recaudaciones.Add(registro);
            }

            if (or == 0) //ordeno descencientemente
            {

                ViewBag.Mensaje = "Artistas que mas recaudaron";

                return View(recaudaciones.OrderByDescending(a => a.rec));

            }
            else
            {
                ViewBag.Mensaje = "Artistas que menos recaudaron";

                return View(recaudaciones.OrderBy(a => a.rec));
            }
        }


        //
        //Admin/Ocupacion

        public ActionResult Ocupacion(int or = 0) //no funciona correctamente, no ordena, u ordena pero sin discernir entre desc y asc!
        {
            List<Espectaculo> espects = db.Espectaculos.ToList();
            List<eOcupacion> espectaculos = new List<eOcupacion>();

            foreach (var item in espects)
            {
                eOcupacion registro = new eOcupacion();

                registro.e = item;
                registro.Ocup = item.Entradas.Count() * 100;
                registro.Ocup = registro.Ocup / ((item.Lugar.CantFilas * item.Lugar.AsientosFila) + item.Entradas.Where(es => es.NumFila == 0).Count() + item.CantGen);
                espectaculos.Add(registro);
                //el denominador es: /((cantidad de Enum totales)+(cantidad de Egen disponibles + cant Egen vendidas))
            }
            if (or == 0)
            {
                ViewBag.Mensaje = "Espectaculos con mayor porcentaje de ocupacion total";
                return View(espectaculos.OrderByDescending(e => e.Ocup));
            }
            else
            {
                ViewBag.Mensaje = "Espectaculos con menor porcentaje de ocupacion total";
                return View(espectaculos.OrderBy(e => e.Ocup));
            }
        }


        //
        // GET: /Admin/RecaudacionPR

        public ActionResult RecaudacionPR (int or = 0, int tr = 0) // tr == "Tipo de reaudacion" SI es 0 => recaudacion real , caso contrario , recaudacion potencial
        {  
            List<Espectaculo> espects = db.Espectaculos.ToList();
            List<eRecaudac> espectaculos = new List<eRecaudac>();

            foreach (var item in espects) 
            {
                eRecaudac registro = new eRecaudac();

                registro.rReal = item.Entradas.Where(en => en.NumAsiento == 0).Count() * item.PrecioEGen + item.Entradas.Where(en => en.NumAsiento != 0).Count() * item.PrecioENum;
                registro.rPotencial = item.Lugar.CantFilas * item.Lugar.AsientosFila * item.PrecioENum + (item.CantGen + item.Entradas.Where(e => e.NumAsiento == 0).Count()) * item.PrecioEGen;
                registro.e = item;
                espectaculos.Add(registro); 
            }

            if ( tr == 0) 
            {
                if (or == 0)
                { 
                    ViewBag.Mensaje = "Eventos con mayor recaudacion real";
                    return View(espectaculos.OrderByDescending(item => item.rReal));
                }
                else
                { 
                    ViewBag.Mensaje = "Eventos con menor recaudacion real";
                    return View(espectaculos.OrderBy(item => item.rReal));
                }
            } 
            else
            {
                if (or == 0)
                { 
                    ViewBag.Mensaje = "Eventos con mayor recaudacion potencial";
                    return View(espectaculos.OrderByDescending(item => item.rPotencial));
                }
                else
                { 
                    ViewBag.Mensaje = "Eventos con menor recaudacion potencial";
                    return View(espectaculos.OrderBy(item => item.rPotencial));
                }
            }

        }
    }
}
