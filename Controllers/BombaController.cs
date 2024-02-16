using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoBancodeDados.Models;

namespace ProjetoBancodeDados.Controllers
{
    public class BombaController : Controller
    {
        private readonly Contexto _context;

        public BombaController(Contexto context)
        {
            _context = context;
        }

        // GET: Bomba
        public async Task<IActionResult> Index()
        {
              return _context.Bomba != null ? 
                          View(await _context.Bomba.ToListAsync()) :
                          Problem("Entity set 'Contexto.Bomba'  is null.");
        }

        // GET: Bomba/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bomba == null)
            {
                return NotFound();
            }

            var bomba = await _context.Bomba
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bomba == null)
            {
                return NotFound();
            }

            return View(bomba);
        }

        // GET: Bomba/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bomba/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroBomba")] Bomba bomba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bomba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bomba);
        }

        // GET: Bomba/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bomba == null)
            {
                return NotFound();
            }

            var bomba = await _context.Bomba.FindAsync(id);
            if (bomba == null)
            {
                return NotFound();
            }
            return View(bomba);
        }

        // POST: Bomba/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroBomba")] Bomba bomba)
        {
            if (id != bomba.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bomba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BombaExists(bomba.Id))
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
            return View(bomba);
        }

        // GET: Bomba/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bomba == null)
            {
                return NotFound();
            }

            var bomba = await _context.Bomba
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bomba == null)
            {
                return NotFound();
            }

            return View(bomba);
        }

        // POST: Bomba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bomba == null)
            {
                return Problem("Entity set 'Contexto.Bomba'  is null.");
            }
            var bomba = await _context.Bomba.FindAsync(id);
            if (bomba != null)
            {
                _context.Bomba.Remove(bomba);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BombaExists(int id)
        {
          return (_context.Bomba?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
