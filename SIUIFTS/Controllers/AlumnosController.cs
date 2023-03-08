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
    [Authorize]
    public class AlumnosController : Controller
    {
        private readonly SIUIFTSContext _contexto;

        public AlumnosController(SIUIFTSContext contexto)
        {
            _contexto = contexto;
        }

        // GET: Alumnos
        //busco y muestro todos los alumnos que tenga guardados en la base
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            //Si el string no esta null o vacio busca nombre o apellido
            if (!String.IsNullOrEmpty(searchString))
            {
                var alumnos = _contexto.Alumnos.Where(a => a.Apellido.Contains(searchString)
                                       || a.Nombre.Contains(searchString)
                                       || a.AlumnoID.ToString().Contains(searchString));

                return View(alumnos.ToList());
            }

            else
            {
                return View(await _contexto.Alumnos.ToListAsync());
            }            
        }

        // GET: Alumnos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _contexto.Alumnos
                .Include(a => a.Inscripciones)
                    .ThenInclude(i => i.Materia)
                .AsNoTracking() //mejora el rendimiento en casos en los que no se actualizarán las entidades devueltas en la duración del contexto actual
                .FirstOrDefaultAsync(m => m.AlumnoID == id);

            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // GET: Alumnos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alumnos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlumnoID,Apellido,Nombre,FechaDeInscripcion")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(alumno);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alumno);
        }

        // GET: Alumnos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _contexto.Alumnos.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }
            return View(alumno);
        }

        // POST: Alumnos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlumnoID,Apellido,Nombre,FechaDeInscripcion")] Alumno alumno)
        {
            if (id != alumno.AlumnoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(alumno);
                    await _contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnoExists(alumno.AlumnoID))
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
            return View(alumno);
        }

        // GET: Alumnos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _contexto.Alumnos
                .FirstOrDefaultAsync(m => m.AlumnoID == id);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alumno = await _contexto.Alumnos.FindAsync(id);
            _contexto.Alumnos.Remove(alumno);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnoExists(int id)
        {
            return _contexto.Alumnos.Any(e => e.AlumnoID == id);
        }
    }
}
