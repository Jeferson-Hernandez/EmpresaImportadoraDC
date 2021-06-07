using EmpresaImportadoraDC.Models.Abstract;
using EmpresaImportadoraDC.Models.Entities;
using EmpresaImportadoraDC.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IClienteService _clienteService;
        private readonly IMercanciaService _mercanciaService;
        private readonly IValorLibraService _valorLibraService;

        public PaquetesController(IPaqueteService paqueteService, IWebHostEnvironment hostEnvironment, IClienteService clienteService, IMercanciaService mercanciaService, IValorLibraService valorLibraService)
        {
            _paqueteService = paqueteService;
            _hostEnvironment = hostEnvironment;
            _clienteService = clienteService;
            _mercanciaService = mercanciaService;
            _valorLibraService = valorLibraService;
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
        public async Task<IActionResult> CrearPaquete()
        {
            ViewBag.ListaClientes = new SelectList(await _clienteService.ObtenerListaClientes(), "ClienteId", "NombreCliente");
            ViewBag.ListaMercancia = new SelectList(await _mercanciaService.ObtenerListaMercancia(), "MercanciaId", "TipoMercancia");
            return View(new PaqueteViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CrearPaquete(PaqueteViewModel paqueteViewModel)
        {
            //if (ModelState.IsValid)
            //{
                ValorLibra valorLibra = await _valorLibraService.ObtenerValorLibra();

                Paquete paquete = new()
                {
                    Codigo = "MIA-" + DateTime.Now.ToString("yymmssfff"),
                    PesoLibras = paqueteViewModel.PesoLibras,
                    ClienteId = paqueteViewModel.ClienteId,
                    Estado = "En Bodega Miami",
                    NoGuiaUSA = paqueteViewModel.NoGuiaUSA,
                    TransportadoraUSA = paqueteViewModel.TransportadoraUSA,
                    MercanciaId = paqueteViewModel.MercanciaId,
                    ValorTotal = valorLibra.ValorLi * paqueteViewModel.PesoLibras
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
                    TempData["Accion"] = "RegistrarPaquete";
                    TempData["Mensaje"] = "Paquete registrado correctamente";
                    return RedirectToAction("index");
                }
                catch (Exception)
                {
                    TempData["Accion"] = "Error";
                    TempData["Mensaje"] = "Ocurrió un error";
                    return RedirectToAction("index");
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
            ViewBag.ListaClientes = new SelectList(await _clienteService.ObtenerListaClientes(), "ClienteId", "NombreCliente");
            ViewBag.ListaMercancia = new SelectList(await _mercanciaService.ObtenerListaMercancia(), "MercanciaId", "TipoMercancia");
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
                TempData["Accion"] = "EditarPaquete";
                TempData["Mensaje"] = "Paquete editado correctamente";
                return RedirectToAction("index");
            }
            catch (Exception)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Ocurrió un error";
                return RedirectToAction("index");
            }

            /*}
            else
            {
                return View(paqueteViewModel);
            }*/
        }

        [HttpPost]
        public async Task<IActionResult> EliminarPaquete(int id)
        {
            try
            {
                Paquete paquete = await _paqueteService.ObtenerPaquetePorId(id);
                
                if (paquete.RutaImagen != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    FileInfo file = new FileInfo(wwwRootPath + "/imagenes/" + paquete.RutaImagen);
                    file.Delete();
                }

                await _paqueteService.EliminarPaquete(id);
                TempData["Accion"] = "EliminarPaquete";
                TempData["Mensaje"] = "Paquete eliminado correctamente";
                return RedirectToAction("index");
            }
            catch (Exception)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Ocurrió un error";
                return RedirectToAction("index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> DespacharPaquete(int id)
        {
            Paquete paquete = await _paqueteService.ObtenerPaquetePorId(id);
            return View(paquete);
        }
        [HttpPost]
        public async Task<IActionResult> DespacharPaquete(Paquete paquete)
        {
            if (ModelState.IsValid)
            {
                paquete.Estado = "En tránsito a dirección del cliente";
                await _paqueteService.EditarPaquete(paquete);
                TempData["Accion"] = "DespacharPaquete";
                TempData["Mensaje"] = "Paquete despachado correctamente";
                return RedirectToAction("index");
            }
            else
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Ocurrió un error";
                return RedirectToAction("index");
            }            
        }
        [HttpGet]
        public async Task<IActionResult> DashboardPaquete()
        {
            return View(await _paqueteService.ObtenerListaPaquetes());
        }
    }
}
