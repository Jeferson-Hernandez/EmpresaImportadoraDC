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
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Ocurrió un error";
                return RedirectToAction("index");
            }

            var mercancia = await _context.Mercancia
                .FirstOrDefaultAsync(m => m.MercanciaId == id);
            if (mercancia == null)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Ocurrió un error";
                return RedirectToAction("index");
            }

            return View(mercancia);
        }

        // Ver la vista de mercancias
        public IActionResult CrearMer()
        {
            return View();
        }

        //Registrar nueva mercancia
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearMer([Bind("TipoMercancia")] Mercancia mercancia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mercancia);
                await _context.SaveChangesAsync();
                TempData["Accion"] = "RegistrarMercancia";
                TempData["Mensaje"] = "Mercancía registrada correctamente";
                return RedirectToAction(nameof(Index));
            }
            return View(mercancia);

        }
        // GET: Mercancia/Edit/5
        public async Task<IActionResult> EditarMerca(int? id)
        {
            if (id == null)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Ocurrió un error";
                return RedirectToAction("index");
            }

            var mercancia = await _context.Mercancia.FindAsync(id);
            if (mercancia == null)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Ocurrió un error";
                return RedirectToAction("index");
            }
            return View(mercancia);

        }
        //dg
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarMerca(int id, [Bind("MercanciaId", "TipoMercancia")] Mercancia mercancia)
        {
            if (id != mercancia.MercanciaId)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Ocurrió un error";
                return RedirectToAction("index");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mercancia);
                    TempData["Accion"] = "EditarMercancia";
                    TempData["Mensaje"] = "Mercancía editada correctamente";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MercanciaExistente(mercancia.MercanciaId))
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Ocurrió un error";
                        return RedirectToAction("index");
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
        // GET: Elimiar/Delete/5
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
        // POST: Merca/Delete/5
        [HttpPost, ActionName("ElimiarMerca")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mercancia = await _context.Mercancia.FindAsync(id);
            _context.Mercancia.Remove(mercancia);
            await _context.SaveChangesAsync();
            TempData["Accion"] = "EliminarMercancia";
            TempData["Mensaje"] = "Mercancía eliminada correctamente";
            return RedirectToAction(nameof(Index));
        }

        private bool MercanciaExistente(int id)
        {
            return _context.Mercancia.Any(e => e.MercanciaId == id);
        }


    }
}