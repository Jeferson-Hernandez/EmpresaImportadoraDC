using EmpresaImportadoraDC.Models.Abstract;
using EmpresaImportadoraDC.Models.Entities;
using EmpresaImportadoraDC.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaImportadoraDC.Controllers
{
    public class PaquetesController : Controller
    {
        private readonly IPaqueteService _paqueteService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PaquetesController(IPaqueteService paqueteService, IWebHostEnvironment hostEnvironment)
        {
            _paqueteService = paqueteService;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
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

        [HttpGet]
        public IActionResult CrearPaquete()
        {
            return View(new PaqueteViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CrearPaquete(PaqueteViewModel paqueteViewModel)
        {
            //if (ModelState.IsValid)
            //{
                Paquete paquete = new()
                {
                    Codigo = "MIA-" + DateTime.Now.ToString("yymmssfff"),
                    PesoLibras = paqueteViewModel.PesoLibras,
                    ClienteId = paqueteViewModel.ClienteId,
                    Estado = "En Bodega Miami",
                    NoGuiaUSA = paqueteViewModel.NoGuiaUSA,
                    TransportadoraUSA = paqueteViewModel.TransportadoraUSA,
                    MercanciaId = paqueteViewModel.MercanciaId,
                    ValorTotal = 35000 * paqueteViewModel.PesoLibras
                };

                string wwwRootPath = null;
                string path = null;

                if (paqueteViewModel.Imagen != null)
                {
                    wwwRootPath = _hostEnvironment.WebRootPath;
                    string nombreImagen = Path.GetFileNameWithoutExtension(paqueteViewModel.Imagen.FileName);
                    string extension = Path.GetExtension(paqueteViewModel.Imagen.FileName);
                    paquete.RutaImagen = nombreImagen + DateTime.Now.ToString("yymmssfff") + extension;
                    path = Path.Combine(wwwRootPath + "/imagenes/" + paquete.RutaImagen);
                }

                try
                {
                    if (path != null)
                    {
                        using var fileStream = new FileStream(path, FileMode.Create);
                        await paqueteViewModel.Imagen.CopyToAsync(fileStream);
                    }

                    await _paqueteService.RegistrarPaquete(paquete);
                    return RedirectToAction("index");
                }
                catch (Exception)
                {
                    return NotFound();
                }

            /*}
            else
            {
                return View(paqueteViewModel);
            }*/
        }
        [HttpGet]
        public async Task<IActionResult> EditarPaquete(int id)
        {
            Paquete paquete = await _paqueteService.ObtenerPaquetePorId(id);
            PaqueteViewModel paqueteViewModel = new()
            {
                PaqueteId = paquete.PaqueteId,
                Codigo = paquete.Codigo,
                PesoLibras = paquete.PesoLibras,
                ClienteId = paquete.ClienteId,
                Estado = paquete.Estado,
                NoGuiaUSA = paquete.NoGuiaUSA,
                TransportadoraUSA = paquete.TransportadoraUSA,
                MercanciaId = paquete.MercanciaId,
                RutaImagen = paquete.RutaImagen,
                NoGuiaCO = paquete.NoGuiaCO,
                TransportadoraCO = paquete.TransportadoraCO,
                ValorTotal = paquete.ValorTotal                
            };
            return View(paqueteViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditarPaquete(PaqueteViewModel paqueteViewModel)
        {
            //if (ModelState.IsValid)
            //{

            Paquete paquete = new()
            {
                PaqueteId = paqueteViewModel.PaqueteId,
                Codigo = paqueteViewModel.Codigo,
                PesoLibras = paqueteViewModel.PesoLibras,
                ClienteId = paqueteViewModel.ClienteId,
                Estado = paqueteViewModel.Estado,
                NoGuiaUSA = paqueteViewModel.NoGuiaUSA,
                TransportadoraUSA = paqueteViewModel.TransportadoraUSA,
                MercanciaId = paqueteViewModel.MercanciaId,
                NoGuiaCO = paqueteViewModel.NoGuiaCO,
                TransportadoraCO = paqueteViewModel.TransportadoraCO,
                ValorTotal = paqueteViewModel.ValorTotal
            };

            Paquete paqueteInfo = await _paqueteService.ObtenerPaquetePorId(paqueteViewModel.PaqueteId);
            if (paqueteInfo.PesoLibras != paqueteViewModel.PesoLibras)
            {
                paquete.ValorTotal = 35000 * paqueteViewModel.PesoLibras;
            }            

            string wwwRootPath = null;
            string path = null;

            if (paqueteViewModel.Imagen != null)
            {
                wwwRootPath = _hostEnvironment.WebRootPath;
                string nombreImagen = Path.GetFileNameWithoutExtension(paqueteViewModel.Imagen.FileName);
                string extension = Path.GetExtension(paqueteViewModel.Imagen.FileName);
                paquete.RutaImagen = nombreImagen + DateTime.Now.ToString("yymmssfff") + extension;
                path = Path.Combine(wwwRootPath + "/imagenes/" + paquete.RutaImagen);
            }

            try
            {
                if (path != null)
                {
                    using var fileStream = new FileStream(path, FileMode.Create);
                    await paqueteViewModel.Imagen.CopyToAsync(fileStream);

                    if (paqueteViewModel.RutaImagen != null)
                    {
                        FileInfo file = new FileInfo(wwwRootPath + "/imagenes/" + paqueteViewModel.RutaImagen);
                        file.Delete();
                    }
                }
                else
                {
                    paquete.RutaImagen = paqueteViewModel.RutaImagen;
                }

                await _paqueteService.EditarPaquete(paquete);
                return RedirectToAction("index");
            }
            catch (Exception)
            {
                return NotFound();
            }

            /*}
            else
            {
                return View(paqueteViewModel);
            }*/
        }
    }
}
