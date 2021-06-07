﻿using EmpresaImportadoraDC.Models.DAL;
using EmpresaImportadoraDC.Models.Entities;

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

        public ClientesController(AppDbContext context, IPaqueteService paqueteService)
        {
            _context = context;
            _paqueteService = paqueteService;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cliente.ToListAsync());
        }

        /* public async Task<IActionResult> Details(int? Id)
         {
             if (Id == null)
             {
                 return NotFound();
             }

             var paquete = await _context.Paquete
                 .FirstOrDefaultAsync(m => m.PaqueteId == Id);
             if (paquete == null)
             {
                 return NotFound();
             }

             return View(paquete);
         }*/
        [HttpGet]
        public async Task<IActionResult> VerDetallePaqueteCliente()
        {
            return View(await _paqueteService.ObtenerListaPaquetes());
        }

        public IActionResult CrearCli()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>CrearCli([Bind("ClienteId,NumeroCasillero,NombreCliente,Correo,DireccionEntrega")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public async Task<IActionResult> EditarCli(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(Id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarCli(int Id, [Bind("ClienteId,NumeroCasillero,NombreCliente,Correo,DireccionEntrega")] Cliente cliente)
        {
            if (Id != cliente.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.ClienteId))
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
            return View(cliente);
        }

        public async Task<IActionResult>EliminarCliente(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.ClienteId == Id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost, ActionName("EliminarCliente")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var cliente = await _context.Cliente.FindAsync(Id);
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int Id)
        {
            return _context.Cliente.Any(e => e.ClienteId == Id);
        }
    }
}