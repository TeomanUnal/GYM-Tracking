using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gym.Models;
using Microsoft.AspNetCore.Authorization;

namespace gym.Controllers
{
    [Authorize]//3.adım:

    public class SınıflarController : Controller
    {
        private readonly gymContext _context;

        public SınıflarController(gymContext context)
        {
            _context = context;
        }

        // GET: Sınıflar
        public async Task<IActionResult> Index()
        {
            var gymContext = _context.Sınıflars.Include(s => s.Trainer);
            return View(await gymContext.ToListAsync());
        }

        // GET: Sınıflar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sınıflars == null)
            {
                return NotFound();
            }

            var sınıflar = await _context.Sınıflars
                .Include(s => s.Trainer)
                .FirstOrDefaultAsync(m => m.ClassId == id);
            if (sınıflar == null)
            {
                return NotFound();
            }

            return View(sınıflar);
        }

        // GET: Sınıflar/Create
        public IActionResult Create()
        {
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "FirstName");
            return View();
        }

        // POST: Sınıflar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassId,ClassName,TrainerId,Schedule")] Sınıflar sınıflar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sınıflar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "FirstName", sınıflar.TrainerId);
            return View(sınıflar);
        }

        // GET: Sınıflar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sınıflars == null)
            {
                return NotFound();
            }

            var sınıflar = await _context.Sınıflars.FindAsync(id);
            if (sınıflar == null)
            {
                return NotFound();
            }
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "FirstName", sınıflar.TrainerId);
            return View(sınıflar);
        }

        // POST: Sınıflar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassId,ClassName,TrainerId,Schedule")] Sınıflar sınıflar)
        {
            if (id != sınıflar.ClassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sınıflar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SınıflarExists(sınıflar.ClassId))
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
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "FirstName", sınıflar.TrainerId);
            return View(sınıflar);
        }

        // GET: Sınıflar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sınıflars == null)
            {
                return NotFound();
            }

            var sınıflar = await _context.Sınıflars
                .Include(s => s.Trainer)
                .FirstOrDefaultAsync(m => m.ClassId == id);
            if (sınıflar == null)
            {
                return NotFound();
            }

            return View(sınıflar);
        }

        // POST: Sınıflar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sınıflars == null)
            {
                return Problem("Entity set 'gymContext.Sınıflars'  is null.");
            }
            var sınıflar = await _context.Sınıflars.FindAsync(id);
            if (sınıflar != null)
            {
                _context.Sınıflars.Remove(sınıflar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SınıflarExists(int id)
        {
          return (_context.Sınıflars?.Any(e => e.ClassId == id)).GetValueOrDefault();
        }
    }
}
