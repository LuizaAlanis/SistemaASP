using Restaurante.Areas.RH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurante.Areas.RH.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: RH/Funcionario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Select()
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
                return RedirectToAction("index");
            }
            return View(funcionario);
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