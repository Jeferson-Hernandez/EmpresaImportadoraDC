
using EmpresaImportadoraDC.Models.DAL;
using EmpresaImportadoraDC.Models.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmpresaImportadoraDC.Controllers
{
    public class TransportadorasController : Controller
    {
        private readonly AppDbContext _context;

        public TransportadorasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Transportadoras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transportadora.ToListAsync());
        }
        
        // Crear
        public IActionResult CrearTr()
        {
            return View();
        }

        // Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearTr([Bind("TransportadoraId, Nombre, Pais")] Transportadora transportadora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transportadora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transportadora);
        }

        // Editar
        public async Task<IActionResult> EditarTr(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var transportadora = await _context.Transportadora.FindAsync(Id);
            if (transportadora == null)
            {
                return NotFound();
            }
            return View(transportadora);
        }

        // Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarTr(int Id, [Bind("TransportadoraId, Nombre, Pais")] Transportadora transportadora)
        {
            if (Id != transportadora.TransportadoraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transportadora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportadoraExists(transportadora.TransportadoraId))
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
            return View(transportadora);
        }

        //Eliminar
        public async Task<IActionResult> EliminarTr(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var transportadora = await _context.Transportadora
                .FirstOrDefaultAsync(m => m.TransportadoraId == Id);
            if (transportadora == null)
            {
                return NotFound();
            }

            return View(transportadora);
        }

        // Eliminar
        [HttpPost, ActionName("EliminarTr")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int Id)
        {
            var transportadora = await _context.Transportadora.FindAsync(Id);
            _context.Transportadora.Remove(transportadora);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransportadoraExists(int Id)
        {
            return _context.Transportadora.Any(e => e.TransportadoraId == Id);
        }
    }
}
