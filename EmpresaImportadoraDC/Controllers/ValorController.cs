using EmpresaImportadoraDC.Models.Abstract;
using EmpresaImportadoraDC.Models.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaImportadoraDC.Controllers
{
    public class ValorController : Controller
    {
        private readonly AppDbContext _context;
        

        public ValorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Clientes
       /* public async Task<IActionResult> Index()
        {
            return View(await _context.ValorLi.ToListAsync());
        }*/
    }
    
}
