using RestauranteMexicano.Areas.ADM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestauranteMexicano.Areas.ADM.Controllers
{
    public class MesaController : Controller
    {
        // GET: ADM/Mesa
        public ActionResult Index()
        {
            var objMesa = new Mesa();
            var ListaMesa = objMesa.SelectMesa();
            return View(ListaMesa);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Mesa mesa)
        {
            if (ModelState.IsValid)
            {
                var objMesa = new Mesa();
                objMesa.InsertMesa(mesa);
                return RedirectToAction("Index");
            }
            return View(mesa);
        }

        public ActionResult Delete(int id)
        {
            var objmesa = new Mesa();
            objmesa.DeleteMesa(id);
            return RedirectToAction("Index");
        }
    }
}