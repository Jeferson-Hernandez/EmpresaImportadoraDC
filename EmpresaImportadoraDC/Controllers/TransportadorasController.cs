
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
        public async Task<IActionResult> EditarTr(int Id)
        {

            Transportadora transportadora = await _transportadoraService.ObtenerTransportadoraPorId(Id);
            return View(transportadora);
        }

        // Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarTr(int Id, Transportadora transportadora)
        {
            if (Id != transportadora.TransportadoraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _transportadoraService.EditarTransportadora(transportadora);
                    TempData["Accion"] = "EditarTr";
                    TempData["Mensaje"] = "Modificacion exitosa";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["Accion"] = "EditarTrF";
                    TempData["Mensaje"] = "Modificacion fallida";
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(transportadora);
        }
        [HttpPost]
        public async Task<IActionResult> EliminarTr(int Id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Transportadora transportadora = await _transportadoraService.ObtenerTransportadoraPorId(Id);

                    await _transportadoraService.EliminarTransportadora(Id);
                    TempData["Accion"] = "EliminarTr";
                    TempData["Mensaje"] = "Transportadora eliminada correctamente";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["Accion"] = "Error";
                    TempData["Mensaje"] = "Ocurrió un error";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Ocurrió un error";
                return RedirectToAction("Index");
            }

        }
        
    }
}
