using EmpresaImportadoraDC.Models.DAL;
using EmpresaImportadoraDC.Models.Entities;
using EmpresaImportadoraDC.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmpresaImportadoraDC.Models.Abstract;

namespace EmpresaImportadoraDC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPaqueteService _paqueteService;
        private readonly IClienteService _clienteService;

        public ClientesController(AppDbContext context, IPaqueteService paqueteService, IClienteService clienteService)
        {
            _context = context;
            _paqueteService = paqueteService;
            _clienteService = clienteService;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _clienteService.ObtenerListaClientes());
        }
        [HttpGet]
        public async Task<IActionResult> VerDetallePaqueteCliente(int? id)
        {
           
            if (id == null)
                return NotFound();

            return View(await _paqueteService.ObtenerListaPaquetesPorId(id.Value));

        }

        public IActionResult CrearCli()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearCli(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Random random = new();
                    cliente.NumeroCasillero = random.Next();
                    await _clienteService.CrearCliente(cliente);
                };
                TempData["Accion"] = "RegistrarCliente";
                TempData["Mensaje"] = "Registro exitoso";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["Accion"] = "RegistrarClienteRC";
                TempData["Mensaje"] = "Registro fallido";
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> EditarCli(int Id)
        {
            Cliente cliente = await _clienteService.ObtenerClientePorId(Id);
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarCli(int Id,Cliente cliente)
        {
            if (Id != cliente.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _clienteService.EditarCliente(cliente);
                    TempData["Accion"] = "EditarCliente";
                    TempData["Mensaje"] = "Modificacion exitosa";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    TempData["Accion"] = "EditarClienteEC";
                    TempData["Mensaje"] = "Modificacion fallida";
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(cliente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarCliente(int Id)
        {
            try
            {
               
                await _clienteService.EliminarCliente(Id);
                TempData["Accion"] = "EliminarCliente";
                TempData["Mensaje"] = "Cliente eliminado exitoso";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["Accion"] = "EliminarClienteEC";
                TempData["Mensaje"] = "Cliente eliminado fallido";
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpGet]
        public async Task<IActionResult> DashboardCli()
        {
            return View(await _context.Cliente.ToListAsync());
        }
    }
}