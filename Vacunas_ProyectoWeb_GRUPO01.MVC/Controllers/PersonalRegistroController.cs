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
    public class PersonalRegistroController : Controller
    {
        private readonly VacunasDbContext _context;

        public PersonalRegistroController(VacunasDbContext context)
        {
            _context = context;
        }

        // GET: PersonalRegistro
        public async Task<IActionResult> Index()
        {
              return _context.PersonalRegistro != null ? 
                          View(await _context.PersonalRegistro.ToListAsync()) :
                          Problem("Entity set 'VacunasDbContext.PersonalRegistro'  is null.");
        }

        // GET: PersonalRegistro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PersonalRegistro == null)
            {
                return NotFound();
            }

            var personalRegistro = await _context.PersonalRegistro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalRegistro == null)
            {
                return NotFound();
            }

            return View(personalRegistro);
        }

        // GET: PersonalRegistro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalRegistro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombres,Apellidos,Dni,Numero,Email,Genero,Distrito,Direccion")] PersonalRegistro personalRegistro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalRegistro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalRegistro);
        }

        // GET: PersonalRegistro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PersonalRegistro == null)
            {
                return NotFound();
            }

            var personalRegistro = await _context.PersonalRegistro.FindAsync(id);
            if (personalRegistro == null)
            {
                return NotFound();
            }
            return View(personalRegistro);
        }

        // POST: PersonalRegistro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombres,Apellidos,Dni,Numero,Email,Genero,Distrito,Direccion")] PersonalRegistro personalRegistro)
        {
            if (id != personalRegistro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalRegistro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalRegistroExists(personalRegistro.Id))
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
            return View(personalRegistro);
        }

        // GET: PersonalRegistro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PersonalRegistro == null)
            {
                return NotFound();
            }

            var personalRegistro = await _context.PersonalRegistro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalRegistro == null)
            {
                return NotFound();
            }

            return View(personalRegistro);
        }

        // POST: PersonalRegistro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PersonalRegistro == null)
            {
                return Problem("Entity set 'VacunasDbContext.PersonalRegistro'  is null.");
            }
            var personalRegistro = await _context.PersonalRegistro.FindAsync(id);
            if (personalRegistro != null)
            {
                _context.PersonalRegistro.Remove(personalRegistro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalRegistroExists(int id)
        {
          return (_context.PersonalRegistro?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
