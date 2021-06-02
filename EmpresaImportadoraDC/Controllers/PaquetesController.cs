using EmpresaImportadoraDC.Models.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaImportadoraDC.Controllers
{
    public class PaquetesController : Controller
    {
        private readonly IPaqueteService _paqueteService;

        public PaquetesController(IPaqueteService paqueteService)
        {
            _paqueteService = paqueteService;
        }

        [HttpGet]
        public async Task <IActionResult> Index()
        {            
            return View(await _paqueteService.ObtenerListaPaquetes());
        }

        [HttpGet]
        public async Task<IActionResult> DetallePaquete(int? id)
        {
            if (id == null)
                return NotFound();

            return View(await _paqueteService.ObtenerPaquetePorId(id.Value));
        }
    }
}
