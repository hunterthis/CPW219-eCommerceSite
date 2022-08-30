using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CPW219_eCommerceSite.Models;

namespace CPW219_eCommerceSite.Controllers
{
    public class TreesController : Controller
    {
        private readonly UserContext _context;

        public TreesController(UserContext context)
        {
            _context = context;
        }

        // GET: Trees
        public async Task<IActionResult> Index()
        {
              return _context.Trees != null ? 
                          View(await _context.Trees.ToListAsync()) :
                          Problem("Entity set 'UserContext.Trees'  is null.");
        }

        // GET: Trees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trees == null)
            {
                return NotFound();
            }

            var trees = await _context.Trees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trees == null)
            {
                return NotFound();
            }

            return View(trees);
        }

        // GET: Trees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Trees trees)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trees);
        }

        // GET: Trees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trees == null)
            {
                return NotFound();
            }

            var trees = await _context.Trees.FindAsync(id);
            if (trees == null)
            {
                return NotFound();
            }
            return View(trees);
        }

        // POST: Trees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Trees trees)
        {
            if (id != trees.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreesExists(trees.Id))
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
            return View(trees);
        }

        // GET: Trees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trees == null)
            {
                return NotFound();
            }

            var trees = await _context.Trees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trees == null)
            {
                return NotFound();
            }

            return View(trees);
        }

        // POST: Trees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trees == null)
            {
                return Problem("Entity set 'UserContext.Trees'  is null.");
            }
            var trees = await _context.Trees.FindAsync(id);
            if (trees != null)
            {
                _context.Trees.Remove(trees);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreesExists(int id)
        {
          return (_context.Trees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
