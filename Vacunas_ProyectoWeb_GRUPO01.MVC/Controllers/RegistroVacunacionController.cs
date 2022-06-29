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
    public class RegistroVacunacionController : Controller
    {
        private readonly VacunasDbContext _context;

        public RegistroVacunacionController(VacunasDbContext context)
        {
            _context = context;
        }

        // GET: RegistroVacunacion
        public async Task<IActionResult> Index()
        {
            var vacunasDbContext = _context.RegistroVacunacion.Include(r => r.CentroVacunacion).Include(r => r.Enfermero).Include(r => r.PersonalRegistro).Include(r => r.Vacuna);
            return View(await vacunasDbContext.ToListAsync());
        }

        // GET: RegistroVacunacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RegistroVacunacion == null)
            {
                return NotFound();
            }

            var registroVacunacion = await _context.RegistroVacunacion
                .Include(r => r.CentroVacunacion)
                .Include(r => r.Enfermero)
                .Include(r => r.PersonalRegistro)
                .Include(r => r.Vacuna)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registroVacunacion == null)
            {
                return NotFound();
            }

            return View(registroVacunacion);
        }

        // GET: RegistroVacunacion/Create
        public IActionResult Create()
        {
            ViewData["CentroVacunacionId"] = new SelectList(_context.CentroVacunacion, "Id", "Id");
            ViewData["EnfermeroId"] = new SelectList(_context.Enfermero, "Id", "Id");
            ViewData["PersonalRegistroId"] = new SelectList(_context.PersonalRegistro, "Id", "Id");
            ViewData["VacunaId"] = new SelectList(_context.Vacuna, "Id", "Id");
            return View();
        }

        // POST: RegistroVacunacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CentroVacunacionId,PacienteId,EnfermeroId,NumeroDosis,FechaVacunacion,PersonalRegistroId,VacunaId")] RegistroVacunacion registroVacunacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroVacunacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CentroVacunacionId"] = new SelectList(_context.CentroVacunacion, "Id", "Id", registroVacunacion.CentroVacunacionId);
            ViewData["EnfermeroId"] = new SelectList(_context.Enfermero, "Id", "Id", registroVacunacion.EnfermeroId);
            ViewData["PersonalRegistroId"] = new SelectList(_context.PersonalRegistro, "Id", "Id", registroVacunacion.PersonalRegistroId);
            ViewData["VacunaId"] = new SelectList(_context.Vacuna, "Id", "Id", registroVacunacion.VacunaId);
            return View(registroVacunacion);
        }

        // GET: RegistroVacunacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RegistroVacunacion == null)
            {
                return NotFound();
            }

            var registroVacunacion = await _context.RegistroVacunacion.FindAsync(id);
            if (registroVacunacion == null)
            {
                return NotFound();
            }
            ViewData["CentroVacunacionId"] = new SelectList(_context.CentroVacunacion, "Id", "Id", registroVacunacion.CentroVacunacionId);
            ViewData["EnfermeroId"] = new SelectList(_context.Enfermero, "Id", "Id", registroVacunacion.EnfermeroId);
            ViewData["PersonalRegistroId"] = new SelectList(_context.PersonalRegistro, "Id", "Id", registroVacunacion.PersonalRegistroId);
            ViewData["VacunaId"] = new SelectList(_context.Vacuna, "Id", "Id", registroVacunacion.VacunaId);
            return View(registroVacunacion);
        }

        // POST: RegistroVacunacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CentroVacunacionId,PacienteId,EnfermeroId,NumeroDosis,FechaVacunacion,PersonalRegistroId,VacunaId")] RegistroVacunacion registroVacunacion)
        {
            if (id != registroVacunacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroVacunacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroVacunacionExists(registroVacunacion.Id))
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
            ViewData["CentroVacunacionId"] = new SelectList(_context.CentroVacunacion, "Id", "Id", registroVacunacion.CentroVacunacionId);
            ViewData["EnfermeroId"] = new SelectList(_context.Enfermero, "Id", "Id", registroVacunacion.EnfermeroId);
            ViewData["PersonalRegistroId"] = new SelectList(_context.PersonalRegistro, "Id", "Id", registroVacunacion.PersonalRegistroId);
            ViewData["VacunaId"] = new SelectList(_context.Vacuna, "Id", "Id", registroVacunacion.VacunaId);
            return View(registroVacunacion);
        }

        // GET: RegistroVacunacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RegistroVacunacion == null)
            {
                return NotFound();
            }

            var registroVacunacion = await _context.RegistroVacunacion
                .Include(r => r.CentroVacunacion)
                .Include(r => r.Enfermero)
                .Include(r => r.PersonalRegistro)
                .Include(r => r.Vacuna)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registroVacunacion == null)
            {
                return NotFound();
            }

            return View(registroVacunacion);
        }

        // POST: RegistroVacunacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RegistroVacunacion == null)
            {
                return Problem("Entity set 'VacunasDbContext.RegistroVacunacion'  is null.");
            }
            var registroVacunacion = await _context.RegistroVacunacion.FindAsync(id);
            if (registroVacunacion != null)
            {
                _context.RegistroVacunacion.Remove(registroVacunacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroVacunacionExists(int id)
        {
          return (_context.RegistroVacunacion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
