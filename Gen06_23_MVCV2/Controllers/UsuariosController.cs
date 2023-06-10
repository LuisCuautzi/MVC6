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
    public class UsuariosController : Controller
    {
        private readonly Gen06_23_EscuelaContext _context;

        public UsuariosController(Gen06_23_EscuelaContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var gen06_23_EscuelaContext = _context.Usuarios.Include(u => u.Direccion).Include(u => u.Perfil);
            return View(await gen06_23_EscuelaContext.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.Direccion)
                .Include(u => u.Perfil)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["DireccionId"] = new SelectList(_context.Direcciones, "Id", "Calle");
            ViewData["PerfilId"] = new SelectList(_context.Perfiles, "Id", "Descripcion");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,ApPaterno,ApMaterno,PerfilId,DireccionId,FecNac,Email,Pass")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DireccionId"] = new SelectList(_context.Direcciones, "Id", "Calle", usuario.DireccionId);
            ViewData["PerfilId"] = new SelectList(_context.Perfiles, "Id", "Descripcion", usuario.PerfilId);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["DireccionId"] = new SelectList(_context.Direcciones, "Id", "Calle", usuario.DireccionId);
            ViewData["PerfilId"] = new SelectList(_context.Perfiles, "Id", "Descripcion", usuario.PerfilId);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,ApPaterno,ApMaterno,PerfilId,DireccionId,FecNac,Email,Pass")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
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
            ViewData["DireccionId"] = new SelectList(_context.Direcciones, "Id", "Calle", usuario.DireccionId);
            ViewData["PerfilId"] = new SelectList(_context.Perfiles, "Id", "Descripcion", usuario.PerfilId);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.Direccion)
                .Include(u => u.Perfil)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'Gen06_23_EscuelaContext.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
