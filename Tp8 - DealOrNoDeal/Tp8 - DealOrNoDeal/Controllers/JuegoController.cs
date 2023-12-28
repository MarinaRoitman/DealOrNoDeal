using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tp8___DealOrNoDeal.Models;

namespace Tp8___DealOrNoDeal.Controllers
{
    public class JuegoController : Controller
    {
        // GET: Juego
        public ActionResult Index()
        {
            ViewBag.DevolverValoresPosiblesMaletines = (int[])DealOrNoDeal.DevolverValoresPosiblesMaletines();
            return View();
        }

        public ActionResult Juego()
        {
            ViewBag.Maletines = DealOrNoDeal.Maletines;
            ViewBag.DevolverValoresPosiblesMaletines = (int[])DealOrNoDeal.DevolverValoresPosiblesMaletines();
            return View();
        }

        public ActionResult Decision()
        {
            return View();
        }

        public ActionResult Final()
        {
            return View();
        }

        public ActionResult elegirPrimerMaletin(int maletin)
        {
           Maletin maletinSeleccionado;
           Maletin[] maletinesNoSeleccionado;
           maletinSeleccionado = DealOrNoDeal.IniciarJuego(maletin); //Doy valor a maletinSeleccionado
           maletinesNoSeleccionado = DealOrNoDeal.ArmarArrayMaletinesNoSelec(maletin); //Doy valor a maletinesNoSeleccionado
           //Session.Add("maletinSeleccionado", maletinSeleccionado);
           ViewBag.MaletinesNoElegido = maletinesNoSeleccionado;
           ViewBag.DevolverValoresPosiblesMaletines = (int[])DealOrNoDeal.DevolverValoresPosiblesMaletines();
           ViewBag.Maletines = DealOrNoDeal.Maletines;
            return View("Juego"); //Devuelvo la view correspondiente
        }

        public ActionResult eleccionMaletin(int maletin)
        {
            ViewBag.DevolverValoresPosiblesMaletines = (int[])DealOrNoDeal.DevolverValoresPosiblesMaletines();
            string aDondeVoy;
            int importeMaletin, jugadasRestantes, cantMaletinesAbiertos;
            cantMaletinesAbiertos = 0;
            importeMaletin = DealOrNoDeal.AbrirMaletin(maletin);
            //declaro y doy valor a las variables
            for (int i = 0; i < 26; i++)
            {
                if (DealOrNoDeal.Maletines[i].estaAbierto) //Pregunto el el maletin que estoy viendo se encuentra o no abierto
                {
                    cantMaletinesAbiertos++; //Sumo la cantidad de maletines que ya se encuentran abiertos
                }
                else
                {
                    ViewBag.plataFinal = ViewBag.DevolverValoresPosiblesMaletines[DealOrNoDeal.Maletines[i].Importe]; //Guardo la plata del maletin en el viewbag
                }
            }
            if(cantMaletinesAbiertos == 25) //Pregunto si todos los maletines (excepto el primer maletin) estan abietos.
            {
                aDondeVoy = "Final"; //Iré a la View Final
            }
            else if (importeMaletin == -1) //Pregunto si el maletin ya estaba abierto
            {
                ViewBag.Maletines = DealOrNoDeal.Maletines;
                aDondeVoy = "Juego";//si lo estaba iré a la View Juego
            }
            else
            {
                ViewBag.Maletines = DealOrNoDeal.Maletines;
                jugadasRestantes = DealOrNoDeal.JugadasRestantes(); //Le doy valor a JugadasRestantes usando el metodo jugadas restantes 
                if (jugadasRestantes > 0)//Si aun me quedan jugadas...
                {
                    aDondeVoy = "Juego";//Iré a la View Juego
                }
                else
                {
                    ViewBag.ofertaARealizar = DealOrNoDeal.OfertaBanca(); //Guardo la oferta a realizar en el viewbag
                    aDondeVoy = "Decision"; //Iré a la View Decision
                }
            }
            return View(aDondeVoy); //Voy a la view correspondiente
        }

        public ActionResult aceptoONo(bool decision)
        {
            string aDondeVoy;
            float importe;
            importe = DealOrNoDeal.DecisionOferta(decision);
            if (importe == -1) //Pregunto si se aceptó o no la oferta
            {
                ViewBag.Maletines = DealOrNoDeal.Maletines;
                ViewBag.DevolverValoresPosiblesMaletines = (int[])DealOrNoDeal.DevolverValoresPosiblesMaletines();
                aDondeVoy = "Juego"; //En cuyo caso iré a Juego
            }
            else
            {
                ViewBag.plataFinal = importe; //Guardo el valor de la oferta aceptada en el viewbag
                aDondeVoy = "Final"; //E iré a Final
            }
            return View(aDondeVoy); //Devuelvo la view correspondiente
        }
    }
}