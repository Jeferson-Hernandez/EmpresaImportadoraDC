using EmpresaImportadoraDC.Models.DAL;
using EmpresaImportadoraDC.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaImportadoraDC.Controllers
{
    public class MercanciaController : Controller
    {
        private readonly AppDbContext _context;

        public MercanciaController(AppDbContext context)
        {
            _context = context;
        }


        //
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mercancia.ToListAsync());
        }

        //Get
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mercancia = await _context.Mercancia
                .FirstOrDefaultAsync(m => m.MercanciaId == id);
            if (mercancia == null)
            {
                return NotFound();
            }

            return View(mercancia);
        }

        // GET: Cargos/Create
        public IActionResult CrearMerca()
        {
            return View();
        }

        //Merca
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearMerca([Bind("CargoId,Nombre")] Mercancia mercancia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mercancia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mercancia);

        }
        // GET: Cargos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mercancia = await _context.Mercancia.FindAsync(id);
            if (mercancia == null)
            {
                return NotFound();
            }
            return View(mercancia);

        }
        //dg
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CargoId,Nombre")] Mercancia mercancia)
        {
            if (id != mercancia.MercanciaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mercancia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CargoExists(mercancia.MercanciaId))
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
            return View(mercancia);
        }
        // GET: Cargos/Delete/5
        public async Task<IActionResult> ElimiarMerca(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mercancia = await _context.Mercancia
                .FirstOrDefaultAsync(m => m.MercanciaId == id);
            if (mercancia == null)
            {
                return NotFound();
            }

            return View(mercancia);
        }
        // POST: Cargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mercancia = await _context.Mercancia.FindAsync(id);
            _context.Mercancia.Remove(mercancia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CargoExists(int id)
        {
            return _context.Mercancia.Any(e => e.MercanciaId == id);
        }


    }
}