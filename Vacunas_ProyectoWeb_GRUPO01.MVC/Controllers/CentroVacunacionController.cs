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
    public class CentroVacunacionController : Controller
    {
        private readonly VacunasDbContext _context;

        public CentroVacunacionController(VacunasDbContext context)
        {
            _context = context;
        }

        // GET: CentroVacunacion
        public async Task<IActionResult> Index()
        {
              return _context.CentroVacunacion != null ? 
                          View(await _context.CentroVacunacion.ToListAsync()) :
                          Problem("Entity set 'VacunasDbContext.CentroVacunacion'  is null.");
        }

        // GET: CentroVacunacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CentroVacunacion == null)
            {
                return NotFound();
            }

            var centroVacunacion = await _context.CentroVacunacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (centroVacunacion == null)
            {
                return NotFound();
            }

            return View(centroVacunacion);
        }

        // GET: CentroVacunacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CentroVacunacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Distrito,Direccion")] CentroVacunacion centroVacunacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(centroVacunacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(centroVacunacion);
        }

        // GET: CentroVacunacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CentroVacunacion == null)
            {
                return NotFound();
            }

            var centroVacunacion = await _context.CentroVacunacion.FindAsync(id);
            if (centroVacunacion == null)
            {
                return NotFound();
            }
            return View(centroVacunacion);
        }

        // POST: CentroVacunacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Distrito,Direccion")] CentroVacunacion centroVacunacion)
        {
            if (id != centroVacunacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(centroVacunacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CentroVacunacionExists(centroVacunacion.Id))
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
            return View(centroVacunacion);
        }

        // GET: CentroVacunacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CentroVacunacion == null)
            {
                return NotFound();
            }

            var centroVacunacion = await _context.CentroVacunacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (centroVacunacion == null)
            {
                return NotFound();
            }

            return View(centroVacunacion);
        }

        // POST: CentroVacunacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CentroVacunacion == null)
            {
                return Problem("Entity set 'VacunasDbContext.CentroVacunacion'  is null.");
            }
            var centroVacunacion = await _context.CentroVacunacion.FindAsync(id);
            if (centroVacunacion != null)
            {
                _context.CentroVacunacion.Remove(centroVacunacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CentroVacunacionExists(int id)
        {
          return (_context.CentroVacunacion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
