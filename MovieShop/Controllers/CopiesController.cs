using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieShop.Data;
using MovieShop.Models;

namespace MovieShop.Controllers
{
    public class CopiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CopiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        private IQueryable<Copy> GetCopies()
        {
            return _context.Copy.Include(c => c.Movie).AsNoTracking();
        }

        // GET: Copies
        public async Task<IActionResult> Index()
        {
            return View(await GetCopies().ToListAsync());
        }

        // GET: Copies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var copy = await GetCopies()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (copy == null)
            {
                return NotFound();
            }

            return View(copy);
        }

        // GET: Copies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Copies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code")] Copy copy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(copy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(copy);
        }

        // GET: Copies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var copy = await _context.Copy.FindAsync(id);
            if (copy == null)
            {
                return NotFound();
            }
            return View(copy);
        }

        // POST: Copies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code")] Copy copy)
        {
            if (id != copy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(copy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CopyExists(copy.Id))
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
            return View(copy);
        }

        // GET: Copies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var copy = await _context.Copy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (copy == null)
            {
                return NotFound();
            }

            return View(copy);
        }

        // POST: Copies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var copy = await _context.Copy.FindAsync(id);
            _context.Copy.Remove(copy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CopyExists(int id)
        {
            return _context.Copy.Any(e => e.Id == id);
        }
    }
}
