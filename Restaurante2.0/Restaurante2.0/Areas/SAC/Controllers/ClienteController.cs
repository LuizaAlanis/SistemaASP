using RestauranteMexicano.Areas.SAC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestauranteMexicano.Areas.SAC.Controllers
{
    public class ClienteController : Controller
    {
        // GET: SAC/Cliente
        public ActionResult Index()
        {
            var objCliente = new Cliente();
            var ListaCliente = objCliente.SelectCliente();
            return View(ListaCliente);
        }

        public ActionResult Details(int id)
        {
            Cliente cliente = new Cliente() { id = id };
            var objCliente = new Cliente();
            cliente = objCliente.SelectIdCliente(cliente);
            return View(cliente);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var objCliente = new Cliente();
                objCliente.InsertCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Edit(int id)
        {
            var cliente = new Cliente() { id = id };
            var objCliente = new Cliente();
            cliente = objCliente.SelectIdCliente(cliente);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var objCliente = new Cliente();
                objCliente.UpdateCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Delete(int id)
        {
            var cliente = new Cliente() { id = id };
            var objCliente = new Cliente();
            cliente = objCliente.SelectIdCliente(cliente);
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirma(int id)
        {
            var cliente = new Cliente() { id = id };
            var objCliente = new Cliente();
            objCliente.DeleteCliente(cliente);
            return RedirectToAction("index");
        }
    }
}