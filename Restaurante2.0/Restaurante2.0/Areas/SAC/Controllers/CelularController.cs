using RestauranteMexicano.Areas.SAC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestauranteMexicano.Areas.SAC.Controllers
{
    public class CelularController : Controller
    {
        // GET: SAC/Celular
        public ActionResult Index()
        {
            var objCelular = new Celular();
            var ListaCelular = objCelular.SelectCelular();
            return View(ListaCelular);
        }

        public ActionResult Details(int id)
        {
            Celular celular = new Celular() { id = id };
            var objCelular = new Celular();
            celular = objCelular.SelectIdCelular(celular);
            return View(celular);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Celular celular)
        {
            if (ModelState.IsValid)
            {
                var objCelular = new Celular();
                objCelular.InsertCelular(celular);
                return RedirectToAction("Index");
            }
            return View(celular);
        }

        public ActionResult Edit(int id)
        {
            var celular = new Celular() { id = id };
            var objCelular = new Celular();
            celular = objCelular.SelectIdCelular(celular);
            return View(celular);
        }

        [HttpPost]
        public ActionResult Edit(Celular celular)
        {
            if (ModelState.IsValid)
            {
                var objCelular = new Celular();
                objCelular.UpdateCelular(celular);
                return RedirectToAction("Index");
            }
            return View(celular);
        }

        public ActionResult Delete(int id)
        {
            var celular = new Celular() { id = id };
            var objCelular = new Celular();
            celular = objCelular.SelectIdCelular(celular);
            return View(celular);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirma(int id)
        {
            var celular = new Celular() { id = id };
            var objCelular = new Celular();
            objCelular.DeleteCelular(celular);
            return RedirectToAction("index");
        }
    }
}