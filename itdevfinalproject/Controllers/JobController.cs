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
    public class JobController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Manager,Employee,Admin")]
        // GET: Job 
        public async Task<IActionResult> Index()
        {
            return View(await _context.Job.ToListAsync());
        }
        [Authorize(Roles = "Manager,Employee,Admin")]
        // GET: Job/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Job
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }
        [Authorize(Roles = "Manager")]
        // GET: Job/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Job/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobId,BusinessTravel,JobLevel,JobInvolvement,EmployeeNumber")] Job job)
        {
            if (ModelState.IsValid)
            {
                _context.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(job);
        }
        [Authorize(Roles = "Manager")]
        // GET: Job/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Job.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }
        [Authorize(Roles = "Manager")]
        // POST: Job/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobId,BusinessTravel,JobLevel,JobInvolvement,EmployeeNumber")] Job job)
        {
            if (id != job.JobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.JobId))
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
            return View(job);
        }
        [Authorize(Roles = "Manager")]
        // GET: Job/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Job
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }
        [Authorize(Roles = "Manager")]
        // POST: Job/Delete/5

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job = await _context.Job.FindAsync(id);
            _context.Job.Remove(job);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobExists(int id)
        {
            return _context.Job.Any(e => e.JobId == id);
        }
    }
}
