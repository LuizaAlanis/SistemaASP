using RestauranteMexicano.Areas.Vendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestauranteMexicano.Areas.Vendas.Controllers
{
    public class ComandaController : Controller
    {
        // GET: Vendas/Comanda
        public ActionResult Index()
        {
            var objviewComanda = new viewComanda();
            var ListaviewComanda = objviewComanda.SelectViewComanda();
            return View(ListaviewComanda);
        }

        public ActionResult Details(int id)
        {
            Comanda comanda = new Comanda() { id = id };
            var objComanda = new Comanda();
            comanda = objComanda.SelectIdComanda(comanda);
            return View(comanda);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comanda comanda)
        {
            if (ModelState.IsValid)
            {
                var objComanda = new Comanda();
                objComanda.InsertComanda(comanda);
                return RedirectToAction("AdicionarItens", "ItensComanda");
            }
            return View(comanda);
        }

        public ActionResult Edit(int id)
        {
            var comanda = new Comanda() { id = id };
            var objComanda = new Comanda();
            comanda = objComanda.SelectIdComanda(comanda);
            return View(comanda);
        }

        [HttpPost]
        public ActionResult Edit(Comanda comanda)
        {
            if (ModelState.IsValid)
            {
                var objComanda = new Comanda();
                objComanda.UpdateComanda(comanda);
                return RedirectToAction("Index");
            }
            return View(comanda);
        }

        public ActionResult Delete(int id)
        {
            var comanda = new Comanda() { id = id };
            var objComanda = new Comanda();
            comanda = objComanda.SelectIdComanda(comanda);
            return View(comanda);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirma(int id)
        {
            var comanda = new Comanda() { id = id };
            var objComanda = new Comanda();
            objComanda.DeleteComanda(comanda);
            return RedirectToAction("index");
        }
    }
}