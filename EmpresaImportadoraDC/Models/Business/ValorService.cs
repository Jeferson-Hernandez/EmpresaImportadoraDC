using EmpresaImportadoraDC.Models.Abstract;
using EmpresaImportadoraDC.Models.DAL;
using EmpresaImportadoraDC.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaImportadoraDC.Models.Business
{
    public class ValorService : IValorService
    {
        private readonly AppDbContext _context;
        public ValorService(AppDbContext context)
        {
            _context = context;
        }

        /*public async Task<IEnumerable<ValorLi>> ObtenerValorLibra()
        {
            return await _context.ValorLi.ToListAsync();

        }*/
    }    
}
