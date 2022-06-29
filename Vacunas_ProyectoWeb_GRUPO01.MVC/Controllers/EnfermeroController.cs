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
    public class EnfermeroController : Controller
    {
        private readonly VacunasDbContext _context;

        public EnfermeroController(VacunasDbContext context)
        {
            _context = context;
        }

        // GET: Enfermero
        public async Task<IActionResult> Index()
        {
            var vacunasDbContext = _context.Enfermero.Include(e => e.CentroVacunacion);
            return View(await vacunasDbContext.ToListAsync());
        }

        // GET: Enfermero/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Enfermero == null)
            {
                return NotFound();
            }

            var enfermero = await _context.Enfermero
                .Include(e => e.CentroVacunacion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enfermero == null)
            {
                return NotFound();
            }

            return View(enfermero);
        }

        // GET: Enfermero/Create
        public IActionResult Create()
        {
            ViewData["CentroVacunacionId"] = new SelectList(_context.CentroVacunacion, "Id", "Id");
            return View();
        }

        // POST: Enfermero/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombres,Apellidos,Dni,Numero,Email,Genero,Distrito,Direccion,CentroVacunacionId")] Enfermero enfermero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enfermero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CentroVacunacionId"] = new SelectList(_context.CentroVacunacion, "Id", "Id", enfermero.CentroVacunacionId);
            return View(enfermero);
        }

        // GET: Enfermero/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Enfermero == null)
            {
                return NotFound();
            }

            var enfermero = await _context.Enfermero.FindAsync(id);
            if (enfermero == null)
            {
                return NotFound();
            }
            ViewData["CentroVacunacionId"] = new SelectList(_context.CentroVacunacion, "Id", "Id", enfermero.CentroVacunacionId);
            return View(enfermero);
        }

        // POST: Enfermero/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombres,Apellidos,Dni,Numero,Email,Genero,Distrito,Direccion,CentroVacunacionId")] Enfermero enfermero)
        {
            if (id != enfermero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enfermero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnfermeroExists(enfermero.Id))
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
            ViewData["CentroVacunacionId"] = new SelectList(_context.CentroVacunacion, "Id", "Id", enfermero.CentroVacunacionId);
            return View(enfermero);
        }

        // GET: Enfermero/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Enfermero == null)
            {
                return NotFound();
            }

            var enfermero = await _context.Enfermero
                .Include(e => e.CentroVacunacion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enfermero == null)
            {
                return NotFound();
            }

            return View(enfermero);
        }

        // POST: Enfermero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Enfermero == null)
            {
                return Problem("Entity set 'VacunasDbContext.Enfermero'  is null.");
            }
            var enfermero = await _context.Enfermero.FindAsync(id);
            if (enfermero != null)
            {
                _context.Enfermero.Remove(enfermero);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnfermeroExists(int id)
        {
          return (_context.Enfermero?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
