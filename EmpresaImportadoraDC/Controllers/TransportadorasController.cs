
using EmpresaImportadoraDC.Models.DAL;
using EmpresaImportadoraDC.Models.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmpresaImportadoraDC.Models.Abstract;
using Microsoft.AspNetCore.Hosting;

namespace EmpresaImportadoraDC.Controllers
{
    public class TransportadorasController : Controller
    {
        private readonly ITransportadoraService _transportadoraService;
        private readonly IWebHostEnvironment _hostEnvironment;


        public TransportadorasController(ITransportadoraService transportadoraService, IWebHostEnvironment hostEnvironment)
        {
            _transportadoraService = transportadoraService;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _transportadoraService.ObtenerListaTransportadoras());
        }

        // Crear
        public IActionResult CrearTr()
        {
            return View();
        }

        // Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearTr(Transportadora transportadora)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _transportadoraService.RegistrarTransportadora(transportadora);
                   
                    
                }
                TempData["Accion"] = "CrearTra";
                TempData["Mensaje"] = "Transportadora creada exitosamente";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["Accion"] = "CrearTraF";
                TempData["Mensaje"] = "Fallo al crear la transportadora";
                return RedirectToAction(nameof(Index));
            }
            
        }

        // Editar
       /* public async Task<IActionResult> EditarTr(int? Id)
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
                    TempData["Accion"] = "EditarTra";
                    TempData["Mensaje"] = "Transportadora editada exitosamente";
                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["Accion"] = "EditarTra";
                    TempData["Mensaje"] = "Fallo al editar la transportadora";
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
            try
            {
                var transportadora = await _context.Transportadora.FindAsync(Id);
                _context.Transportadora.Remove(transportadora);
                await _context.SaveChangesAsync();
                TempData["Accion"] = "EliminarTra";
                TempData["Mensaje"] = "Transportadora eliminada exitosamente";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["Accion"] = "EliminarTra";
                TempData["Mensaje"] = "Fallo al eliminar la transportadora";
                return RedirectToAction(nameof(Index));
            }
        }

        private bool TransportadoraExists(int Id)
        {
            return _context.Transportadora.Any(e => e.TransportadoraId == Id);
        }
       */
    }
}
