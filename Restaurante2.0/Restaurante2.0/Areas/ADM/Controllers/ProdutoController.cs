using RestauranteMexicano.Areas.ADM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestauranteMexicano.Areas.ADM.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: ADM/Produto
        public ActionResult Index()
        {
            var objProduto = new Produto();
            var ListaProduto = objProduto.SelectProduto();
            return View(ListaProduto);
        }

        public ActionResult Details(int id)
        {
            Produto produto = new Produto() { id = id };
            var objProduto = new Produto();
            produto = objProduto.SelectIdProduto(produto);
            return View(produto);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                var objProduto = new Produto();
                objProduto.InsertProduto(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public ActionResult Edit(int id)
        {
            var produto = new Produto() { id = id };
            var objProduto = new Produto();
            produto = objProduto.SelectIdProduto(produto);
            return View(produto);
        }

        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                var objProduto = new Produto();
                objProduto.UpdateProduto(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public ActionResult Delete(int id)
        {
            var produto = new Produto() { id = id };
            var objProduto = new Produto();
            produto = objProduto.SelectIdProduto(produto);
            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirma(int id)
        {
            var produto = new Produto() { id = id };
            var objProduto = new Produto();
            objProduto.DeleteProduto(produto);
            return RedirectToAction("index");
        }
    }
}