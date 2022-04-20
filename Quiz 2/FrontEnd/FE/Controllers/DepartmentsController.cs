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
    public class DepartmentsController : Controller
    {
        private readonly IPeopleServices peopleServices;
        private readonly IDepartmentsServices departmentsServices;

        public DepartmentsController(IDepartmentsServices departmentsServices, IPeopleServices peopleServices)
        {
            this.departmentsServices = departmentsServices;
            this.peopleServices = peopleServices;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            //var akiraToriyamaContext = _context.Department.Include(t => t.IdPersonNavigation);
            return View(await departmentsServices.GetAllAsync());
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await departmentsServices.GetOneByIdAsync((int)id);


            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            ViewData["InstructorId"] = new SelectList(peopleServices.GetAll(), "Id", "Id");
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentId,Name,Budget,StartDate,InstructorId,RowVersion")] Department department)
        {
            if (ModelState.IsValid)
            {
                departmentsServices.Insert(department);
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstructorId"] = new SelectList(peopleServices.GetAll(), "Id", "Id", department.InstructorId);
            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = departmentsServices.GetOneById((int)id);
            if (department == null)
            {
                return NotFound();
            }
            ViewData["InstructorId"] = new SelectList(peopleServices.GetAll(), "Id", "Id", department.InstructorId);
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentId,Name,Budget,StartDate,InstructorId,RowVersion")] Department department)
        {
            if (id != department.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    departmentsServices.Update(department);
                }
                catch (Exception ee)
                {
                    if (!DepartmentExists(department.DepartmentId))
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
            ViewData["InstructorId"] = new SelectList(peopleServices.GetAll(), "Id", "Id", department.InstructorId);
            return View(department);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = departmentsServices.GetOneByIdAsync((int)id);
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
            var department = departmentsServices.GetOneById((int)id);
            departmentsServices.Update(department);
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(int id)
        {
            return (departmentsServices.GetOneById((int)id) != null);
        }
    }
}

