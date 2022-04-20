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
    public class EnrollmentsController : Controller
    {
        private readonly IPeopleServices peopleServices;
        private readonly ICoursesServices coursesServices;
        private readonly IEnrollmentsServices enrollmentsServices;

        public EnrollmentsController(IPeopleServices peopleServices, ICoursesServices coursesServices, IEnrollmentsServices enrollmentsServices)
        {
            this.peopleServices = peopleServices;
            this.coursesServices = coursesServices;
            this.enrollmentsServices = enrollmentsServices;
        }

        // GET: Capituloes
        public async Task<IActionResult> Index()
        {
            //var akiraToriyamaContext = _context.Capitulo.Include(c => c.IdAnimeNavigation).Include(c => c.IdTemporadaNavigation);
            return View(await enrollmentsServices.GetAllAsync());
        }

        // GET: Capituloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await enrollmentsServices.GetOneByIdAsync((int)id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Capituloes/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(peopleServices.GetAll(), "Id", "Id");
            //ViewData["CourseId"] = new SelectList(coursesServices.GetAll(), "Id", "Id");
            return View();
        }

        // POST: Capituloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentId,CourseId,StudentId,Grade")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                enrollmentsServices.Insert(enrollment);
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(peopleServices.GetAll(), "Id", "Id", enrollment.StudentId);
            //ViewData["CourseId"] = new SelectList(coursesServices.GetAll(), "Id", "Id", enrollment.CourseId);
            return View(enrollment);
        }

        // GET: Capituloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = enrollmentsServices.GetOneById((int)id);
            if (enrollment == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(peopleServices.GetAll(), "Id", "Id", enrollment.StudentId);
            ViewData["CourseId"] = new SelectList(coursesServices.GetAll(), "Id", "Id", enrollment.CourseId);
            return View(enrollment);
        }

        // POST: Capituloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrollmentId,CourseId,StudentId,Grade")] Enrollment enrollment)
        {
            if (id != enrollment.EnrollmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    enrollmentsServices.Update(enrollment);
                }
                catch (Exception ee)
                {
                    if (!EnrollmentExists(enrollment.EnrollmentId))
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
            ViewData["Id"] = new SelectList(peopleServices.GetAll(), "Id", "Id", enrollment.StudentId);
            ViewData["CourseId"] = new SelectList(coursesServices.GetAll(), "Id", "Id", enrollment.CourseId);
            return View(enrollment);
        }

        // GET: Capituloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = enrollmentsServices.GetOneByIdAsync((int)id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Capituloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollment = enrollmentsServices.GetOneById((int)id);
            enrollmentsServices.Delete(enrollment);
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(int id)
        {
            return (enrollmentsServices.GetOneById((int)id)) != null;
        }
    }
}

