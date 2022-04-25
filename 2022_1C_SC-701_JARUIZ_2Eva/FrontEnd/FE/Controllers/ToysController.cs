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
    public class ToysController : Controller
    {
        private readonly IKidsServices kidsServices;
        private readonly IToysServices toysServices;

        public ToysController(IToysServices toysServices, IKidsServices kidsServices)
        {
            this.toysServices = toysServices;
            this.kidsServices = kidsServices;
        }

        // GET: Temporadas
        public async Task<IActionResult> Index()
        {
            //var akiraToriyamaContext = _context.Temporada.Include(t => t.IdAnimeNavigation);
            return View(await toysServices.GetAllAsync());
        }

        // GET: Temporadas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toy = await toysServices.GetOneByIdAsync((int)id);


            if (toy == null)
            {
                return NotFound();
            }

            return View(toy);
        }

        // GET: Temporadas/Create
        public IActionResult Create()
        {
            ViewData["KidId"] = new SelectList(kidsServices.GetAll(), "Id", "Id");
            return View();
        }

        // POST: Temporadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KidId,Name,Colour")] Toys toy)
        {
            if (ModelState.IsValid)
            {
                toysServices.Insert(toy);
                return RedirectToAction(nameof(Index));
            }
            ViewData["KidId"] = new SelectList(kidsServices.GetAll(), "Id", "Id", toy.KidId);
            return View(toy);
        }

        // GET: Temporadas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toy = toysServices.GetOneById((int)id);
            if (toy == null)
            {
                return NotFound();
            }
            ViewData["KidId"] = new SelectList(kidsServices.GetAll(), "Id", "Id", toy.KidId);
            return View(toy);
        }

        // POST: Temporadas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KidId,Name,Colour")] Toys toy)
        {
            if (id != toy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    toysServices.Update(toy);
                }
                catch (Exception ee)
                {
                    if (!TemporadaExists(toy.Id))
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
            ViewData["KidId"] = new SelectList(kidsServices.GetAll(), "Id", "Id", toy.KidId);
            return View(toy);
        }

        // GET: Temporadas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toy = toysServices.GetOneByIdAsync((int)id);
            if (toy == null)
            {
                return NotFound();
            }

            return View(toy);
        }

        // POST: Temporadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toy = toysServices.GetOneById((int)id);
            toysServices.Delete(toy);
            return RedirectToAction(nameof(Index));
        }

        private bool TemporadaExists(int id)
        {
            return (toysServices.GetOneById((int)id) != null);
        }
    }
}
