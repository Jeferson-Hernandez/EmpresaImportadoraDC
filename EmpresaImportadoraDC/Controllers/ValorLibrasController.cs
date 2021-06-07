using EmpresaImportadoraDC.Models.Abstract;
using EmpresaImportadoraDC.Models.DAL;
using EmpresaImportadoraDC.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaImportadoraDC.Controllers
{
    public class ValorLibrasController : Controller
    {
        private readonly IValorLibraService _valorLibraService;

        public ValorLibrasController(IValorLibraService valorLibraService)
        {
            _valorLibraService = valorLibraService;
        }

       [HttpGet]
       public async Task<IActionResult> EditarValorLibra()
        {
            ValorLibra valorLibras = await _valorLibraService.ObtenerValorLibra(); 
            return View(valorLibras);
        }
        [HttpPost]
        public async Task<IActionResult> EditarValorLibra(ValorLibra valorLibra)
        {
            if (ModelState.IsValid)
            {
                await _valorLibraService.EditarValorLibra(valorLibra);
                TempData["Accion"] = "EditarValor";
                TempData["Mensaje"] = "Valor editado correctamente";
                return RedirectToAction("EditarValorLibra");
            }
            else
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Ocurrió un error";
                return RedirectToAction("EditarValorLibra");
            } 
        }
    }
    
}
