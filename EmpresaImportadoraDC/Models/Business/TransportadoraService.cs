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
    public class TransportadoraService:ITransportadoraService
    {
        private readonly AppDbContext _context;
        public TransportadoraService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transportadora>> ObtenerListaTransportadoras()
        {
            return await _context.Transportadora.ToListAsync();
        }
        public async Task<IEnumerable<Transportadora>> ObtenerListaTransportadorasUSA()
        {
            return await _context.Transportadora.Where(u=>u.Pais == "USA").ToListAsync();            
        }
        public async Task<IEnumerable<Transportadora>> ObtenerListaTransportadorasCO()
        {
            return await _context.Transportadora.Where(c => c.Pais == "CO").ToListAsync();
        }

    }
}
