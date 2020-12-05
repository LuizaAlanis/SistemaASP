using RestauranteMexicano.Areas.Vendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestauranteMexicano.Areas.Vendas.Controllers
{
    public class ItensComandaController : Controller
    {
        // GET: Vendas/ItensComanda
        public ActionResult Index()
        {
            var objItens = new ItensComanda();
            var ListaItens = objItens.SelectItensComanda();
            return View(ListaItens);
        }

        public ActionResult AdicionarItens()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarItens(ItensComanda itensComanda)
        {
            if (ModelState.IsValid)
            {
                var objItens = new ItensComanda();
                objItens.InsertItensComanda(itensComanda);
                objItens.Atualizar(itensComanda);
                return RedirectToAction("Index");
            }
            return View(itensComanda);
        }
    }
}