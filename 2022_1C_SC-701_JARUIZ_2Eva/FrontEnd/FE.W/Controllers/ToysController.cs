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
    public class ToysController : Controller
    {
        private readonly BoomContext _context;

        public ToysController(BoomContext context)
        {
            _context = context;
        }

        // GET: Toys
        public async Task<IActionResult> Index()
        {
            var boomContext = _context.Toys.Include(t => t.Kid);
            return View(await boomContext.ToListAsync());
        }

        // GET: Toys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toys = await _context.Toys
                .Include(t => t.Kid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toys == null)
            {
                return NotFound();
            }

            return View(toys);
        }

        // GET: Toys/Create
        public IActionResult Create()
        {
            ViewData["KidId"] = new SelectList(_context.Kids, "Id", "Id");
            return View();
        }

        // POST: Toys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KidId,Name,Colour")] Toys toys)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toys);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KidId"] = new SelectList(_context.Kids, "Id", "Id", toys.KidId);
            return View(toys);
        }

        // GET: Toys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toys = await _context.Toys.FindAsync(id);
            if (toys == null)
            {
                return NotFound();
            }
            ViewData["KidId"] = new SelectList(_context.Kids, "Id", "Id", toys.KidId);
            return View(toys);
        }

        // POST: Toys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KidId,Name,Colour")] Toys toys)
        {
            if (id != toys.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toys);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToysExists(toys.Id))
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
            ViewData["KidId"] = new SelectList(_context.Kids, "Id", "Id", toys.KidId);
            return View(toys);
        }

        // GET: Toys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toys = await _context.Toys
                .Include(t => t.Kid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toys == null)
            {
                return NotFound();
            }

            return View(toys);
        }

        // POST: Toys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toys = await _context.Toys.FindAsync(id);
            _context.Toys.Remove(toys);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToysExists(int id)
        {
            return _context.Toys.Any(e => e.Id == id);
        }
    }
}
