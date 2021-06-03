using EmpresaImportadoraDC.Models.Abstract;
using EmpresaImportadoraDC.Models.Entities;
using EmpresaImportadoraDC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaImportadoraDC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteService _clienteService;
        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        [HttpGet]
        public async Task <IActionResult> Index()
        {
        return View(await _clienteService.ObtenerListaClientes());
        }
        [HttpGet]
        public async Task<IActionResult> CrearEditarClientes(int id=0)
        {
            if (id == 0)
                return View(new ClienteViewModel());
            else
            {              
                Cliente cliente = await _clienteService.ObtenerClientePorId(id);
                ClienteViewModel clienteViewModel = new()
                {
                    NombreCliente = cliente.NombreCliente,
                    Correo = cliente.Correo,
                    DireccionEntrega = cliente.DireccionEntrega
                };
                return View(clienteViewModel);
            }
        }
         [HttpPost]     
        public async Task<IActionResult> EliminarCliente(int id)
        {
            try
            {
                await _clienteService.EliminarCliente(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw;
            }
            
        }

    }
}
