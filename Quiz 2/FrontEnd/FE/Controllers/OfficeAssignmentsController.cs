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
    public class OfficeAssignmentsController : Controller
    {
        private readonly IPeopleServices peopleServices;
        private readonly IOfficeAssignmentsServices officeassignmentsServices;

        public OfficeAssignmentsController(IOfficeAssignmentsServices officeassignmentsServices, IPeopleServices peopleServices)
        {
            this.officeassignmentsServices = officeassignmentsServices;
            this.peopleServices = peopleServices;
        }

        // GET: Temporadas
        public async Task<IActionResult> Index()
        {
            //var akiraToriyamaContext = _context.Temporada.Include(t => t.IdAnimeNavigation);
            return View(await officeassignmentsServices.GetAllAsync());
        }

        // GET: Temporadas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeassignment = await officeassignmentsServices.GetOneByIdAsync((int)id);


            if (officeassignment == null)
            {
                return NotFound();
            }

            return View(officeassignment);
        }

        // GET: Temporadas/Create
        public IActionResult Create()
        {
            ViewData["InstructorId"] = new SelectList(peopleServices.GetAll(), "Id", "Id");
            return View();
        }

        // POST: Temporadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstructorId,Location")] OfficeAssignment officeassignment)
        {
            if (ModelState.IsValid)
            {
                officeassignmentsServices.Insert(officeassignment);
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstructorId"] = new SelectList(peopleServices.GetAll(), "Id", "Id", officeassignment.InstructorId);
            return View(officeassignment);
        }

        // GET: Temporadas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeassignment = officeassignmentsServices.GetOneById((int)id);
            if (officeassignment == null)
            {
                return NotFound();
            }
            ViewData["InstructorId"] = new SelectList(peopleServices.GetAll(), "Id", "Id", officeassignment.InstructorId);
            return View(officeassignment);
        }

        // POST: Temporadas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstructorId,Location")] OfficeAssignment officeassignment)
        {
            if (id != officeassignment.InstructorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    officeassignmentsServices.Update(officeassignment);
                }
                catch (Exception ee)
                {
                    if (!OfficeAssignmentsExists(officeassignment.InstructorId))
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
            ViewData["InstructorId"] = new SelectList(peopleServices.GetAll(), "Id", "Id", officeassignment.InstructorId);
            return View(officeassignment);
        }

        // GET: Temporadas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeassignment = officeassignmentsServices.GetOneByIdAsync((int)id);
            if (officeassignment == null)
            {
                return NotFound();
            }

            return View(officeassignment);
        }

        // POST: Temporadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var officeassignment = officeassignmentsServices.GetOneById((int)id);
            officeassignmentsServices.Update(officeassignment);
            return RedirectToAction(nameof(Index));
        }

   

        private bool OfficeAssignmentsExists(int id)
        {
            return (officeassignmentsServices.GetOneById((int)id) != null);
        }
    }
}
