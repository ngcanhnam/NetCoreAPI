using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CanhNamtest;

namespace CanhNamtest.Controllers
{
    public class LophocController : Controller
    {
        private readonly LTQLDb _context;

        public LophocController(LTQLDb context)
        {
            _context = context;
        }

        // GET: Lophoc
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lophoc.ToListAsync());
        }

        // GET: Lophoc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lophoc = await _context.Lophoc
                .FirstOrDefaultAsync(m => m.Malop == id);
            if (lophoc == null)
            {
                return NotFound();
            }

            return View(lophoc);
        }

        // GET: Lophoc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lophoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Malop,Tenlop")] Lophoc lophoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lophoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lophoc);
        }

        // GET: Lophoc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lophoc = await _context.Lophoc.FindAsync(id);
            if (lophoc == null)
            {
                return NotFound();
            }
            return View(lophoc);
        }

        // POST: Lophoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Malop,Tenlop")] Lophoc lophoc)
        {
            if (id != lophoc.Malop)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lophoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LophocExists(lophoc.Malop))
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
            return View(lophoc);
        }

        // GET: Lophoc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lophoc = await _context.Lophoc
                .FirstOrDefaultAsync(m => m.Malop == id);
            if (lophoc == null)
            {
                return NotFound();
            }

            return View(lophoc);
        }

        // POST: Lophoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lophoc = await _context.Lophoc.FindAsync(id);
            if (lophoc != null)
            {
                _context.Lophoc.Remove(lophoc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LophocExists(int id)
        {
            return _context.Lophoc.Any(e => e.Malop == id);
        }
    }
}
