using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vacunas_ProyectoWeb_GRUPO01.MVC.Models;

namespace Vacunas_ProyectoWeb_GRUPO01.MVC.Controllers
{
    public class VacunaController : Controller
    {
        private readonly VacunasDbContext _context;

        public VacunaController(VacunasDbContext context)
        {
            _context = context;
        }

        // GET: Vacuna
        public async Task<IActionResult> Index()
        {
              return _context.Vacuna != null ? 
                          View(await _context.Vacuna.ToListAsync()) :
                          Problem("Entity set 'VacunasDbContext.Vacuna'  is null.");
        }

        // GET: Vacuna/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vacuna == null)
            {
                return NotFound();
            }

            var vacuna = await _context.Vacuna
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacuna == null)
            {
                return NotFound();
            }

            return View(vacuna);
        }

        // GET: Vacuna/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vacuna/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Laboratorio,Procedencia")] Vacuna vacuna)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacuna);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vacuna);
        }

        // GET: Vacuna/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vacuna == null)
            {
                return NotFound();
            }

            var vacuna = await _context.Vacuna.FindAsync(id);
            if (vacuna == null)
            {
                return NotFound();
            }
            return View(vacuna);
        }

        // POST: Vacuna/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Laboratorio,Procedencia")] Vacuna vacuna)
        {
            if (id != vacuna.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacuna);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacunaExists(vacuna.Id))
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
            return View(vacuna);
        }

        // GET: Vacuna/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vacuna == null)
            {
                return NotFound();
            }

            var vacuna = await _context.Vacuna
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacuna == null)
            {
                return NotFound();
            }

            return View(vacuna);
        }

        // POST: Vacuna/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vacuna == null)
            {
                return Problem("Entity set 'VacunasDbContext.Vacuna'  is null.");
            }
            var vacuna = await _context.Vacuna.FindAsync(id);
            if (vacuna != null)
            {
                _context.Vacuna.Remove(vacuna);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacunaExists(int id)
        {
          return (_context.Vacuna?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
