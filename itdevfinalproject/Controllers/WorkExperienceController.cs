using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using itdevfinalproject.Data;
using itdevfinalproject.Models;
using Microsoft.AspNetCore.Authorization;

namespace itdevfinalproject.Controllers
{
    public class WorkExperienceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkExperienceController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles ="Manager,Employee,Admin")]
        // GET: WorkExperience
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkExperience.ToListAsync());
        }
        [Authorize(Roles = "Manager,Employee,Admin")]
        // GET: WorkExperience/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperience
                .FirstOrDefaultAsync(m => m.WorkExepienceId == id);
            if (workExperience == null)
            {
                return NotFound();
            }

            return View(workExperience);
        }
        [Authorize(Roles = "Manager")]
        // GET: WorkExperience/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkExperience/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkExepienceId,YearsSinceLastPromotion,YearsWithCurrentManager,YearsInCurrentRole,YearsAtCompany,EmployeeNumber")] WorkExperience workExperience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workExperience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workExperience);
        }
        [Authorize(Roles = "Manager")]
        // GET: WorkExperience/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperience.FindAsync(id);
            if (workExperience == null)
            {
                return NotFound();
            }
            return View(workExperience);
        }
        [Authorize(Roles = "Manager")]
        // POST: WorkExperience/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkExepienceId,YearsSinceLastPromotion,YearsWithCurrentManager,YearsInCurrentRole,YearsAtCompany,EmployeeNumber")] WorkExperience workExperience)
        {
            if (id != workExperience.WorkExepienceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workExperience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkExperienceExists(workExperience.WorkExepienceId))
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
            return View(workExperience);
        }
        [Authorize(Roles = "Manager")]
        // GET: WorkExperience/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperience
                .FirstOrDefaultAsync(m => m.WorkExepienceId == id);
            if (workExperience == null)
            {
                return NotFound();
            }

            return View(workExperience);
        }
        [Authorize(Roles = "Manager")]
        // POST: WorkExperience/Delete/5

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workExperience = await _context.WorkExperience.FindAsync(id);
            _context.WorkExperience.Remove(workExperience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkExperienceExists(int id)
        {
            return _context.WorkExperience.Any(e => e.WorkExepienceId == id);
        }
    }
}
