using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FE.W.Models;

namespace FE.W.Controllers
{
    public class KidsController : Controller
    {
        private readonly BoomContext _context;

        public KidsController(BoomContext context)
        {
            _context = context;
        }

        // GET: Kids
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kids.ToListAsync());
        }

        // GET: Kids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kids = await _context.Kids
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kids == null)
            {
                return NotFound();
            }

            return View(kids);
        }

        // GET: Kids/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,BirthDate")] Kids kids)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kids);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kids);
        }

        // GET: Kids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kids = await _context.Kids.FindAsync(id);
            if (kids == null)
            {
                return NotFound();
            }
            return View(kids);
        }

        // POST: Kids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,BirthDate")] Kids kids)
        {
            if (id != kids.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kids);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KidsExists(kids.Id))
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
            return View(kids);
        }

        // GET: Kids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kids = await _context.Kids
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kids == null)
            {
                return NotFound();
            }

            return View(kids);
        }

        // POST: Kids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kids = await _context.Kids.FindAsync(id);
            _context.Kids.Remove(kids);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KidsExists(int id)
        {
            return _context.Kids.Any(e => e.Id == id);
        }
    }
}
