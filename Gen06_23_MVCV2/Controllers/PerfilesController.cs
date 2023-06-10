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
    public class PerfilesController : Controller
    {
        private readonly Gen06_23_EscuelaContext _context;

        public PerfilesController(Gen06_23_EscuelaContext context)
        {
            _context = context;
        }

        // GET: Perfiles
        public async Task<IActionResult> Index()
        {
              return View(await _context.Perfiles.ToListAsync());
        }

        // GET: Perfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Perfiles == null)
            {
                return NotFound();
            }

            var perfile = await _context.Perfiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perfile == null)
            {
                return NotFound();
            }

            return View(perfile);
        }

        // GET: Perfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Perfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion")] Perfile perfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(perfile);
        }

        // GET: Perfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Perfiles == null)
            {
                return NotFound();
            }

            var perfile = await _context.Perfiles.FindAsync(id);
            if (perfile == null)
            {
                return NotFound();
            }
            return View(perfile);
        }

        // POST: Perfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] Perfile perfile)
        {
            if (id != perfile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerfileExists(perfile.Id))
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
            return View(perfile);
        }

        // GET: Perfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Perfiles == null)
            {
                return NotFound();
            }

            var perfile = await _context.Perfiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perfile == null)
            {
                return NotFound();
            }

            return View(perfile);
        }

        // POST: Perfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Perfiles == null)
            {
                return Problem("Entity set 'Gen06_23_EscuelaContext.Perfiles'  is null.");
            }
            var perfile = await _context.Perfiles.FindAsync(id);
            if (perfile != null)
            {
                _context.Perfiles.Remove(perfile);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerfileExists(int id)
        {
          return _context.Perfiles.Any(e => e.Id == id);
        }
    }
}
