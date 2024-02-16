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
    public class VendasController : Controller
    {
        private readonly Contexto _context;

        public VendasController(Contexto context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Vendas.Include(v => v.Bomba).Include(v => v.Cliente).Include(v => v.Combustivel).Include(v => v.Funcionarios);
            return View(await contexto.ToListAsync());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var vendas = await _context.Vendas
                .Include(v => v.Bomba)
                .Include(v => v.Cliente)
                .Include(v => v.Combustivel)
                .Include(v => v.Funcionarios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendas == null)
            {
                return NotFound();
            }

            return View(vendas);
        }

        public async Task<IActionResult> Imprimir(int? id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var vendas = await _context.Vendas
                .Include(v => v.Bomba)
                .Include(v => v.Cliente)
                .Include(v => v.Combustivel)
                .Include(v => v.Funcionarios)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (vendas == null)
            {
                return NotFound();
            }

            return View(vendas);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            ViewData["BombaId"] = new SelectList(_context.Bomba, "Id", "NumeroBomba");
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "NomeCliente");
            ViewData["CombustivelId"] = new SelectList(_context.Combustivel, "Id", "NomeCombustivel");
            ViewData["FuncionariosId"] = new SelectList(_context.Funcionarios, "Id", "NomeFuncionario");
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,QuantidadeLitros,BombaId,CombustivelId,FuncionariosId")] Vendas vendas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BombaId"] = new SelectList(_context.Bomba, "Id", "NumeroBomba", vendas.BombaId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "NomeCliente", vendas.ClienteId);
            ViewData["CombustivelId"] = new SelectList(_context.Combustivel, "Id", "NomeCombustivel", vendas.CombustivelId);
            ViewData["FuncionariosId"] = new SelectList(_context.Funcionarios, "Id", "NomeFuncionario", vendas.FuncionariosId);
            return View(vendas);
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var vendas = await _context.Vendas.FindAsync(id);
            if (vendas == null)
            {
                return NotFound();
            }
            ViewData["BombaId"] = new SelectList(_context.Bomba, "Id", "NumeroBomba", vendas.BombaId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "NomeCliente", vendas.ClienteId);
            ViewData["CombustivelId"] = new SelectList(_context.Combustivel, "Id", "NomeCombustivel", vendas.CombustivelId);
            ViewData["FuncionariosId"] = new SelectList(_context.Funcionarios, "Id", "NomeFuncionario", vendas.FuncionariosId);
            return View(vendas);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,QuantidadeLitros,BombaId,CombustivelId,FuncionariosId")] Vendas vendas)
        {
            if (id != vendas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendasExists(vendas.Id))
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
            ViewData["BombaId"] = new SelectList(_context.Bomba, "Id", "NumeroBomba", vendas.BombaId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "NomeCliente", vendas.ClienteId);
            ViewData["CombustivelId"] = new SelectList(_context.Combustivel, "Id", "NomeCombustivel", vendas.CombustivelId);
            ViewData["FuncionariosId"] = new SelectList(_context.Funcionarios, "Id", "NomeFuncionario", vendas.FuncionariosId);
            return View(vendas);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var vendas = await _context.Vendas
                .Include(v => v.Bomba)
                .Include(v => v.Cliente)
                .Include(v => v.Combustivel)
                .Include(v => v.Funcionarios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendas == null)
            {
                return NotFound();
            }

            return View(vendas);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vendas == null)
            {
                return Problem("Entity set 'Contexto.Vendas'  is null.");
            }
            var vendas = await _context.Vendas.FindAsync(id);
            if (vendas != null)
            {
                _context.Vendas.Remove(vendas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendasExists(int id)
        {
          return (_context.Vendas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
