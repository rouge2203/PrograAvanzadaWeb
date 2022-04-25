using FE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FE.Models;

namespace FE.Controllers
{
    public class KidsController : Controller
    {
        private readonly IKidsServices kidsServices;

        public KidsController(IKidsServices kidsServices)
        {
            this.kidsServices = kidsServices;
        }

        // GET: Animes
        public async Task<IActionResult> Index()
        {
            return View(kidsServices.GetAll());
        }

        // GET: Animes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kid = kidsServices.GetOneById((int)id);
            if (kid == null)
            {
                return NotFound();
            }

            return View(kid);
        }

        // GET: Animes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,BirthDate,")] Kids kid)
        {
            if (ModelState.IsValid)
            {
                kidsServices.Insert(kid);
                return RedirectToAction(nameof(Index));
            }
            return View(kid);
        }

        // GET: Animes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kid = kidsServices.GetOneById((int)id);
            if (kid == null)
            {
                return NotFound();
            }
            return View(kid);
        }

        // POST: Animes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,BirthDate,")] Kids kid)
        {
            if (id != kid.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    kidsServices.Update(kid);
                }
                catch (Exception ee)
                {
                    if (!AnimeExists(kid.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kid);
        }

        // GET: Animes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kid = kidsServices.GetOneById((int)id);
            if (kid == null)
            {
                return NotFound();
            }

            return View(kid);
        }

        // POST: Animes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kid = kidsServices.GetOneById(id);
            kidsServices.Delete(kid);
            return RedirectToAction(nameof(Index));
        }

        private bool AnimeExists(int id)
        {
            return (kidsServices.GetOneById(id) != null);
        }
    }
}

