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
    public class AdministrativoSaludController : Controller
    {
        private readonly VacunasDbContext _context;

        public AdministrativoSaludController(VacunasDbContext context)
        {
            _context = context;
        }

        // GET: AdministrativoSalud
        public async Task<IActionResult> Index()
        {
              return _context.AdministrativoSalud != null ? 
                          View(await _context.AdministrativoSalud.ToListAsync()) :
                          Problem("Entity set 'VacunasDbContext.AdministrativoSalud'  is null.");
        }

        // GET: AdministrativoSalud/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AdministrativoSalud == null)
            {
                return NotFound();
            }

            var administrativoSalud = await _context.AdministrativoSalud
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administrativoSalud == null)
            {
                return NotFound();
            }

            return View(administrativoSalud);
        }

        // GET: AdministrativoSalud/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdministrativoSalud/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombres,Apellidos,Dni,Numero,Email,Genero,Distrito,Direccion")] AdministrativoSalud administrativoSalud)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrativoSalud);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(administrativoSalud);
        }

        // GET: AdministrativoSalud/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AdministrativoSalud == null)
            {
                return NotFound();
            }

            var administrativoSalud = await _context.AdministrativoSalud.FindAsync(id);
            if (administrativoSalud == null)
            {
                return NotFound();
            }
            return View(administrativoSalud);
        }

        // POST: AdministrativoSalud/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombres,Apellidos,Dni,Numero,Email,Genero,Distrito,Direccion")] AdministrativoSalud administrativoSalud)
        {
            if (id != administrativoSalud.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administrativoSalud);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministrativoSaludExists(administrativoSalud.Id))
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
            return View(administrativoSalud);
        }

        // GET: AdministrativoSalud/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AdministrativoSalud == null)
            {
                return NotFound();
            }

            var administrativoSalud = await _context.AdministrativoSalud
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administrativoSalud == null)
            {
                return NotFound();
            }

            return View(administrativoSalud);
        }

        // POST: AdministrativoSalud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AdministrativoSalud == null)
            {
                return Problem("Entity set 'VacunasDbContext.AdministrativoSalud'  is null.");
            }
            var administrativoSalud = await _context.AdministrativoSalud.FindAsync(id);
            if (administrativoSalud != null)
            {
                _context.AdministrativoSalud.Remove(administrativoSalud);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministrativoSaludExists(int id)
        {
          return (_context.AdministrativoSalud?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
