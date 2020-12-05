using RestauranteMexicano.Areas.RH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestauranteMexicano.Areas.RH.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: RH/Funcionario
        public ActionResult Index()
        {
            var objFuncionario = new Funcionario();
            var ListaFuncionario = objFuncionario.SelectFuncionario();
            return View(ListaFuncionario);
        }

        public ActionResult Details(int id)
        {
            Funcionario funcionario = new Funcionario() { id = id };
            var objFuncionario = new Funcionario();
            funcionario = objFuncionario.SelectIdFuncionario(funcionario);
            return View(funcionario);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                var objFuncionario = new Funcionario();
                objFuncionario.InsertFuncionario(funcionario);
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        public ActionResult Edit(int id)
        {
            var funcionario = new Funcionario() { id = id };
            var objFuncionario = new Funcionario();
            funcionario = objFuncionario.SelectIdFuncionario(funcionario);
            return View(funcionario);
        }

        [HttpPost]
        public ActionResult Edit(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                var objFuncionario = new Funcionario();
                objFuncionario.UpdateFuncionario(funcionario);
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        public ActionResult Delete(int id)
        {
            var funcionario = new Funcionario() { id = id };
            var objFuncionario = new Funcionario();
            funcionario = objFuncionario.SelectIdFuncionario(funcionario);
            return View(funcionario);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirma(int id)
        {
            var funcionario = new Funcionario() { id = id };
            var objFuncionario = new Funcionario();
            objFuncionario.DeleteFuncionario(funcionario);
            return RedirectToAction("index");
        }
    }
}