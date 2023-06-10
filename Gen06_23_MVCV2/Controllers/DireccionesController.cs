using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gen06_23_MVCV2.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Gen06_23_MVCV2.Controllers
{
    [Authorize(Roles = "1")]
    public class DireccionesController : Controller
    {
        private readonly Gen06_23_EscuelaContext _context;

        public DireccionesController(Gen06_23_EscuelaContext context)
        {
            _context = context;
        }

        // GET: Direcciones
        public async Task<IActionResult> Index()
        {
              return View(await _context.Direcciones.ToListAsync());
        }

        // GET: Direcciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Direcciones == null)
            {
                return NotFound();
            }

            var direccione = await _context.Direcciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccione == null)
            {
                return NotFound();
            }

            return View(direccione);
        }

        // GET: Direcciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Direcciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Calle,Colonia,Cikudad,Estado,Municipio,Telefono")] Direccione direccione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(direccione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(direccione);
        }

        // GET: Direcciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Direcciones == null)
            {
                return NotFound();
            }

            var direccione = await _context.Direcciones.FindAsync(id);
            if (direccione == null)
            {
                return NotFound();
            }
            return View(direccione);
        }

        // POST: Direcciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Calle,Colonia,Cikudad,Estado,Municipio,Telefono")] Direccione direccione)
        {
            if (id != direccione.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(direccione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DireccioneExists(direccione.Id))
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
            return View(direccione);
        }

        // GET: Direcciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Direcciones == null)
            {
                return NotFound();
            }

            var direccione = await _context.Direcciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccione == null)
            {
                return NotFound();
            }

            return View(direccione);
        }

        // POST: Direcciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Direcciones == null)
            {
                return Problem("Entity set 'Gen06_23_EscuelaContext.Direcciones'  is null.");
            }
            var direccione = await _context.Direcciones.FindAsync(id);
            if (direccione != null)
            {
                _context.Direcciones.Remove(direccione);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DireccioneExists(int id)
        {
          return _context.Direcciones.Any(e => e.Id == id);
        }
    }
}
