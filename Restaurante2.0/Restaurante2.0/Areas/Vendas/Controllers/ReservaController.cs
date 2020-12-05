using RestauranteMexicano.Areas.Vendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestauranteMexicano.Areas.Vendas.Controllers
{
    public class ReservaController : Controller
    {
        // GET: Vendas/Reserva
        public ActionResult Index()
        {
            var objReserva = new Reserva();
            var ListaReserva = objReserva.SelectReserva();
            return View(ListaReserva);
        }

        public ActionResult Details(int id)
        {
            Reserva reserva = new Reserva() { id = id };
            var objReserva = new Reserva();
            reserva = objReserva.SelectIdReserva(reserva);
            return View(reserva);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                var objReserva = new Reserva();
                objReserva.InsertReserva(reserva);
                return RedirectToAction("Index");
            }
            return View(reserva);
        }

        public ActionResult Edit(int id)
        {
            var reserva = new Reserva() { id = id };
            var objReserva = new Reserva();
            reserva = objReserva.SelectIdReserva(reserva);
            return View(reserva);
        }

        [HttpPost]
        public ActionResult Edit(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                var objReserva = new Reserva();
                objReserva.UpdateReserva(reserva);
                return RedirectToAction("Index");
            }
            return View(reserva);
        }

        public ActionResult Delete(int id)
        {
            var reserva = new Reserva() { id = id };
            var objReserva = new Reserva();
            reserva = objReserva.SelectIdReserva(reserva);
            return View(reserva);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirma(int id)
        {
            var reserva = new Reserva() { id = id };
            var objReserva = new Reserva();
            objReserva.DeleteReserva(reserva);
            return RedirectToAction("index");
        }
    }
}