using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaSemana2BUENA.Controllers
{
    public class Numero2Controller1 : Controller
    {
        // GET: Numero2Controller1
        public ActionResult Index()
        {
            return View();
        }

        // GET: Numero2Controller1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult VistaUNO()
        {
            return View();
        }

        public ActionResult VistaDOS()
        {
            return View();
        }

        // GET: Numero2Controller1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Numero2Controller1/Create
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

        // GET: Numero2Controller1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Numero2Controller1/Edit/5
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

        // GET: Numero2Controller1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Numero2Controller1/Delete/5
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
