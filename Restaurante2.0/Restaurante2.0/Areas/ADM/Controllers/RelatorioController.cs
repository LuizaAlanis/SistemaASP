using RestauranteMexicano.Areas.ADM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestauranteMexicano.Areas.ADM.Controllers
{
    public class RelatorioController : Controller
    {
        // GET: ADM/Relatorio
        public ActionResult Index()
        {
            var objRelatorio = new Relatorio();
            var ListaRelatorio = objRelatorio.SelectRelatorio();
            return View(ListaRelatorio);
        }

        public ActionResult Details(int id)
        {
            Relatorio relatorio = new Relatorio() { id = id };
            var objRelatorio = new Relatorio();
            relatorio = objRelatorio.SelectIdRelatorio(relatorio);
            return View(relatorio);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Relatorio relatorio)
        {
            if (ModelState.IsValid)
            {
                var objRelatorio = new Relatorio();
                objRelatorio.InsertRelatorio(relatorio);
                return RedirectToAction("Index");
            }
            return View(relatorio);
        }

        public ActionResult Edit(int id)
        {
            var relatorio = new Relatorio() { id = id };
            var objRelatorio = new Relatorio();
            relatorio = objRelatorio.SelectIdRelatorio(relatorio);
            return View(relatorio);
        }

        [HttpPost]
        public ActionResult Edit(Relatorio relatorio)
        {
            if (ModelState.IsValid)
            {
                var objRelatorio = new Relatorio();
                objRelatorio.UpdateRelatorio(relatorio);
                return RedirectToAction("Index");
            }
            return View(relatorio);
        }

        public ActionResult Delete(int id)
        {
            var relatorio = new Relatorio() { id = id };
            var objRelatorio = new Relatorio();
            relatorio = objRelatorio.SelectIdRelatorio(relatorio);
            return View(relatorio);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirma(int id)
        {
            var relatorio = new Relatorio() { id = id };
            var objRelatorio = new Relatorio();
            objRelatorio.DeleteRelatorio(relatorio);
            return RedirectToAction("index");
        }
    }
}