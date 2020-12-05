using RestauranteMexicano.Areas.ADM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestauranteMexicano.Areas.ADM.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: ADM/Categoria
        public ActionResult Index()
        {
            var objCategoria = new Categoria();
            var ListaCategoria = objCategoria.SelectCategoria();
            return View(ListaCategoria);
        }

        public ActionResult Details(int id)
        {
            Categoria categoria = new Categoria() { id = id };
            var objcategoria = new Categoria();
            categoria = objcategoria.SelectIdCategoria(categoria);
            return View(categoria);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                var objCategoria = new Categoria();
                objCategoria.InsertCategoria(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public ActionResult Edit(int id)
        {
            var categoria = new Categoria() { id = id };
            var objcategoria = new Categoria();
            categoria = objcategoria.SelectIdCategoria(categoria);
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                var objcategoria = new Categoria();
                objcategoria.UpdateCategoria(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public ActionResult Delete(int id)
        {
            var categoria = new Categoria() { id = id };
            var objcategoria = new Categoria();
            categoria = objcategoria.SelectIdCategoria(categoria);
            return View(categoria);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirma(int id)
        {
            var categoria = new Categoria() { id = id };
            var objcategoria = new Categoria();
            objcategoria.DeleteCategoria(categoria);
            return RedirectToAction("index");
        }
    }
}