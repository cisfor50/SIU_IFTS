using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIUIFTS.Data;
using SIUIFTS.Models;

namespace SIUIFTS.Controllers
{
    public class InscripcionesController : Controller
    {
        private readonly SIUIFTSContext _contexto;

        public InscripcionesController(SIUIFTSContext contexto)
        {
            _contexto = contexto;
        }

        // GET: Inscripciones
        public async Task<IActionResult> Index()
        {
            var sIUIFTScontexto = _contexto.Inscripciones.Include(i => i.Materia);
            return View(await sIUIFTScontexto.ToListAsync());
        }

        // GET: Inscripciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripcion = await _contexto.Inscripciones
                .Include(i => i.Materia)
                .FirstOrDefaultAsync(m => m.InscripcionID == id);
            if (inscripcion == null)
            {
                return NotFound();
            }

            return View(inscripcion);
        }

        // GET: Inscripciones/Create        
        public IActionResult Create()
        {
            ViewData["MateriaID"] = new SelectList(_contexto.Materias, "MateriaID", "MateriaID");
            return View();
        }

        // POST: Inscripciones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InscripcionID,MateriaID,AlumnoID,Nota")] Inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(inscripcion);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MateriaID"] = new SelectList(_contexto.Materias, "MateriaID", "MateriaID", inscripcion.MateriaID);
            return View(inscripcion);
        }

        // GET: Inscripciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripcion = await _contexto.Inscripciones.FindAsync(id);
            if (inscripcion == null)
            {
                return NotFound();
            }
            ViewData["MateriaID"] = new SelectList(_contexto.Materias, "MateriaID", "MateriaID", inscripcion.MateriaID);
            return View(inscripcion);
        }

        // POST: Inscripciones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InscripcionID,MateriaID,AlumnoID,Nota")] Inscripcion inscripcion)
        {
            if (id != inscripcion.InscripcionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(inscripcion);
                    await _contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscripcionExists(inscripcion.InscripcionID))
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
            ViewData["MateriaID"] = new SelectList(_contexto.Materias, "MateriaID", "MateriaID", inscripcion.MateriaID);
            return View(inscripcion);
        }

        // GET: Inscripciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripcion = await _contexto.Inscripciones
                .Include(i => i.Materia)
                .FirstOrDefaultAsync(m => m.InscripcionID == id);
            if (inscripcion == null)
            {
                return NotFound();
            }

            return View(inscripcion);
        }

        // POST: Inscripciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inscripcion = await _contexto.Inscripciones.FindAsync(id);
            _contexto.Inscripciones.Remove(inscripcion);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscripcionExists(int id)
        {
            return _contexto.Inscripciones.Any(e => e.InscripcionID == id);
        }
    }
}
