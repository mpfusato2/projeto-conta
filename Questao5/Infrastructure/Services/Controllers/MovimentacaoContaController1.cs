﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Questao5.Infrastructure.Services.Controllers
{
    public class MovimentacaoContaController1 : Controller
    {
        // GET: MovimentacaoContaController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: MovimentacaoContaController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MovimentacaoContaController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovimentacaoContaController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovimentacaoContaController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovimentacaoContaController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovimentacaoContaController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovimentacaoContaController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
