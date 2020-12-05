using RestauranteMexicano.Areas.RH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestauranteMexicano.Areas.RH.Controllers
{
    public class CargoController : Controller
    {
        // GET: RH/Cargo
        public ActionResult Index()
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
                return RedirectToAction("Index");
            }
            return View(cargo);
        }

        public ActionResult Edit(int id)
        {
            var cargo = new Cargo() { id = id };
            var objCargo = new Cargo();
            cargo = objCargo.SelectIdCargo(cargo);
            return View(cargo);
        }

        [HttpPost]
        public ActionResult Edit(Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                var objCargo = new Cargo();
                objCargo.UpdateCargo(cargo);
                return RedirectToAction("Index");
            }
            return View(cargo);
        }

        public ActionResult Delete(int id)
        {
            var cargo = new Cargo() { id = id };
            var objCargo = new Cargo();
            cargo = objCargo.SelectIdCargo(cargo);
            return View(cargo);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirma(int id)
        {
            var cargo = new Cargo() { id = id };
            var objCargo = new Cargo();
            objCargo.DeleteCargo(cargo);
            return RedirectToAction("index");
        }
    }
}