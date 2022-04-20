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
    public class CoursesController : Controller
    {
        private readonly IDepartmentsServices departmentsServices;
        private readonly ICoursesServices coursesServices;

        public CoursesController(ICoursesServices coursesServices, IDepartmentsServices departmentsServices)
        {
            this.coursesServices = coursesServices;
            this.departmentsServices = departmentsServices;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            //var akiraToriyamaContext = _context.Department.Include(t => t.IdPersonNavigation);
            return View(await coursesServices.GetAllAsync());
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await coursesServices.GetOneByIdAsync((int)id);


            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(departmentsServices.GetAll(), "Id", "Id");
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,Title,Credits,DepartmentId")] Course course)
        {
            if (ModelState.IsValid)
            {
                coursesServices.Insert(course);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(departmentsServices.GetAll(), "Id", "Id", course.DepartmentId);
            return View(course);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = coursesServices.GetOneById((int)id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(departmentsServices.GetAll(), "Id", "Id", course.DepartmentId);
            return View(course);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,Title,Credits,DepartmentId")] Course course)
        {
            if (id != course.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    coursesServices.Update(course);
                }
                catch (Exception ee)
                {
                    if (!DepartmentExists(course.DepartmentId))
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
            ViewData["DepartmentId"] = new SelectList(departmentsServices.GetAll(), "Id", "Id", course.DepartmentId);
            return View(course);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = coursesServices.GetOneByIdAsync((int)id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = coursesServices.GetOneById((int)id);
            coursesServices.Update(course);
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(int id)
        {
            return (coursesServices.GetOneById((int)id) != null);
        }
    }
}

