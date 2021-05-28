using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaImportadoraDC.Controllers
{
    public class MercanciaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
