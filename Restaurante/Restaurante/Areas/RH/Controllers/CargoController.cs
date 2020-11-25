using Restaurante.Areas.RH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurante.Areas.RH.Controllers
{
    public class CargoController : Controller
    {
        // GET: RH/Cargo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Select()
        {
            var objCargo = new Cargo();
            var ListaCargo = objCargo.SelectCargo();
            return View(ListaCargo);
        }

        public ActionResult Details(int id)
        {
            Cargo cargo = new Cargo() { id = id };
            var objCargo = new Cargo();
            cargo = objCargo.SelectIdCargo(cargo);
            return View(cargo);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                var objCargo = new Cargo();
                objCargo.InsertCargo(cargo);
                return RedirectToAction("index");
            }
            return View(cargo);
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}