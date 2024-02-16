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
    public class CombustivelController : Controller
    {
        private readonly Contexto _context;

        public CombustivelController(Contexto context)
        {
            _context = context;
        }

        // GET: Combustivel
        public async Task<IActionResult> Index()
        {
              return _context.Combustivel != null ? 
                          View(await _context.Combustivel.ToListAsync()) :
                          Problem("Entity set 'Contexto.Combustivel'  is null.");
        }

        // GET: Combustivel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Combustivel == null)
            {
                return NotFound();
            }

            var combustivel = await _context.Combustivel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (combustivel == null)
            {
                return NotFound();
            }

            return View(combustivel);
        }

        // GET: Combustivel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Combustivel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeCombustivel,TipoCombustivel,PrecoCombustivel")] Combustivel combustivel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(combustivel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(combustivel);
        }

        // GET: Combustivel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Combustivel == null)
            {
                return NotFound();
            }

            var combustivel = await _context.Combustivel.FindAsync(id);
            if (combustivel == null)
            {
                return NotFound();
            }
            return View(combustivel);
        }

        // POST: Combustivel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeCombustivel,TipoCombustivel,PrecoCombustivel")] Combustivel combustivel)
        {
            if (id != combustivel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(combustivel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CombustivelExists(combustivel.Id))
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
            return View(combustivel);
        }

        // GET: Combustivel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Combustivel == null)
            {
                return NotFound();
            }

            var combustivel = await _context.Combustivel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (combustivel == null)
            {
                return NotFound();
            }

            return View(combustivel);
        }

        // POST: Combustivel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Combustivel == null)
            {
                return Problem("Entity set 'Contexto.Combustivel'  is null.");
            }
            var combustivel = await _context.Combustivel.FindAsync(id);
            if (combustivel != null)
            {
                _context.Combustivel.Remove(combustivel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CombustivelExists(int id)
        {
          return (_context.Combustivel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
