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
    public class RegistroReporteIncidenteController : Controller
    {
        private readonly VacunasDbContext _context;

        public RegistroReporteIncidenteController(VacunasDbContext context)
        {
            _context = context;
        }

        // GET: RegistroReporteIncidente
        public async Task<IActionResult> Index()
        {
            var vacunasDbContext = _context.RegistroReporteIncidente.Include(r => r.AdministrativoSalud).Include(r => r.CentroVacunacion).Include(r => r.Paciente);
            return View(await vacunasDbContext.ToListAsync());
        }

        // GET: RegistroReporteIncidente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RegistroReporteIncidente == null)
            {
                return NotFound();
            }

            var registroReporteIncidente = await _context.RegistroReporteIncidente
                .Include(r => r.AdministrativoSalud)
                .Include(r => r.CentroVacunacion)
                .Include(r => r.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registroReporteIncidente == null)
            {
                return NotFound();
            }

            return View(registroReporteIncidente);
        }

        // GET: RegistroReporteIncidente/Create
        public IActionResult Create()
        {
            ViewData["AdministrativoSaludId"] = new SelectList(_context.AdministrativoSalud, "Id", "Id");
            ViewData["CentroVacunacionId"] = new SelectList(_context.CentroVacunacion, "Id", "Id");
            ViewData["PacienteId"] = new SelectList(_context.Paciente, "Id", "Id");
            return View();
        }

        // POST: RegistroReporteIncidente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PacienteId,CentroVacunacionId,Descripcion,AdministrativoSaludId,FechaReporte,NivelImportancia")] RegistroReporteIncidente registroReporteIncidente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroReporteIncidente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdministrativoSaludId"] = new SelectList(_context.AdministrativoSalud, "Id", "Id", registroReporteIncidente.AdministrativoSaludId);
            ViewData["CentroVacunacionId"] = new SelectList(_context.CentroVacunacion, "Id", "Id", registroReporteIncidente.CentroVacunacionId);
            ViewData["PacienteId"] = new SelectList(_context.Paciente, "Id", "Id", registroReporteIncidente.PacienteId);
            return View(registroReporteIncidente);
        }

        // GET: RegistroReporteIncidente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RegistroReporteIncidente == null)
            {
                return NotFound();
            }

            var registroReporteIncidente = await _context.RegistroReporteIncidente.FindAsync(id);
            if (registroReporteIncidente == null)
            {
                return NotFound();
            }
            ViewData["AdministrativoSaludId"] = new SelectList(_context.AdministrativoSalud, "Id", "Id", registroReporteIncidente.AdministrativoSaludId);
            ViewData["CentroVacunacionId"] = new SelectList(_context.CentroVacunacion, "Id", "Id", registroReporteIncidente.CentroVacunacionId);
            ViewData["PacienteId"] = new SelectList(_context.Paciente, "Id", "Id", registroReporteIncidente.PacienteId);
            return View(registroReporteIncidente);
        }

        // POST: RegistroReporteIncidente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PacienteId,CentroVacunacionId,Descripcion,AdministrativoSaludId,FechaReporte,NivelImportancia")] RegistroReporteIncidente registroReporteIncidente)
        {
            if (id != registroReporteIncidente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroReporteIncidente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroReporteIncidenteExists(registroReporteIncidente.Id))
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
            ViewData["AdministrativoSaludId"] = new SelectList(_context.AdministrativoSalud, "Id", "Id", registroReporteIncidente.AdministrativoSaludId);
            ViewData["CentroVacunacionId"] = new SelectList(_context.CentroVacunacion, "Id", "Id", registroReporteIncidente.CentroVacunacionId);
            ViewData["PacienteId"] = new SelectList(_context.Paciente, "Id", "Id", registroReporteIncidente.PacienteId);
            return View(registroReporteIncidente);
        }

        // GET: RegistroReporteIncidente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RegistroReporteIncidente == null)
            {
                return NotFound();
            }

            var registroReporteIncidente = await _context.RegistroReporteIncidente
                .Include(r => r.AdministrativoSalud)
                .Include(r => r.CentroVacunacion)
                .Include(r => r.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registroReporteIncidente == null)
            {
                return NotFound();
            }

            return View(registroReporteIncidente);
        }

        // POST: RegistroReporteIncidente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RegistroReporteIncidente == null)
            {
                return Problem("Entity set 'VacunasDbContext.RegistroReporteIncidente'  is null.");
            }
            var registroReporteIncidente = await _context.RegistroReporteIncidente.FindAsync(id);
            if (registroReporteIncidente != null)
            {
                _context.RegistroReporteIncidente.Remove(registroReporteIncidente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroReporteIncidenteExists(int id)
        {
          return (_context.RegistroReporteIncidente?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
