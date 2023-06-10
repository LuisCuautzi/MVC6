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
    [Authorize(Roles = "2, 1")]
    public class CursoesController : Controller
    {
        private readonly Gen06_23_EscuelaContext _context;

        public CursoesController(Gen06_23_EscuelaContext context)
        {
            _context = context;
        }

        // GET: Cursoes
        public async Task<IActionResult> Index()
        {
            var gen06_23_EscuelaContext = _context.Cursos.Include(c => c.Categoria).Include(c => c.InstructorAuxiliar).Include(c => c.InstructorTitular);
            return View(await gen06_23_EscuelaContext.ToListAsync());
        }

        // GET: Cursoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos
                .Include(c => c.Categoria)
                .Include(c => c.InstructorAuxiliar)
                .Include(c => c.InstructorTitular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // GET: Cursoes/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nombre");
            ViewData["InstructorAuxiliarId"] = new SelectList(_context.Instructores, "Id", "ApMaterno");
            ViewData["InstructorTitularId"] = new SelectList(_context.Instructores, "Id", "ApMaterno");
            return View();
        }

        // POST: Cursoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,FechaCreacion,Duracion,Ilustracion,CategoriaId,InstructorTitularId,InstructorAuxiliarId")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nombre", curso.CategoriaId);
            ViewData["InstructorAuxiliarId"] = new SelectList(_context.Instructores, "Id", "ApMaterno", curso.InstructorAuxiliarId);
            ViewData["InstructorTitularId"] = new SelectList(_context.Instructores, "Id", "ApMaterno", curso.InstructorTitularId);
            return View(curso);
        }

        // GET: Cursoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nombre", curso.CategoriaId);
            ViewData["InstructorAuxiliarId"] = new SelectList(_context.Instructores, "Id", "ApMaterno", curso.InstructorAuxiliarId);
            ViewData["InstructorTitularId"] = new SelectList(_context.Instructores, "Id", "ApMaterno", curso.InstructorTitularId);
            return View(curso);
        }

        // POST: Cursoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,FechaCreacion,Duracion,Ilustracion,CategoriaId,InstructorTitularId,InstructorAuxiliarId")] Curso curso)
        {
            if (id != curso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(curso.Id))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nombre", curso.CategoriaId);
            ViewData["InstructorAuxiliarId"] = new SelectList(_context.Instructores, "Id", "ApMaterno", curso.InstructorAuxiliarId);
            ViewData["InstructorTitularId"] = new SelectList(_context.Instructores, "Id", "ApMaterno", curso.InstructorTitularId);
            return View(curso);
        }

        // GET: Cursoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos
                .Include(c => c.Categoria)
                .Include(c => c.InstructorAuxiliar)
                .Include(c => c.InstructorTitular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: Cursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cursos == null)
            {
                return Problem("Entity set 'Gen06_23_EscuelaContext.Cursos'  is null.");
            }
            var curso = await _context.Cursos.FindAsync(id);
            if (curso != null)
            {
                _context.Cursos.Remove(curso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoExists(int id)
        {
          return _context.Cursos.Any(e => e.Id == id);
        }
    }
}
