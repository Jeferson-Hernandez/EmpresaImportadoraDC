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
    public class ValorLibraService : IValorLibraService
    {
        private readonly AppDbContext _context;
        public ValorLibraService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ValorLibra> ObtenerValorLibra()
        {
            return await _context.ValorLibra.FirstOrDefaultAsync(p => p.ValorLibraId == 1);
        }

        public async Task EditarValorLibra(ValorLibra valorLibra)
        {
            _context.Update(valorLibra);
            await _context.SaveChangesAsync();
        }
    }
}
