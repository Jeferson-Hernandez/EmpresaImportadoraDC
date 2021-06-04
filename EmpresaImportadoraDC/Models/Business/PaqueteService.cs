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
    public class PaqueteService:IPaqueteService
    {
        private readonly AppDbContext _context;

        public PaqueteService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Paquete>> ObtenerListaPaquetes()
        {
            return await _context.Paquete.Include(c=>c.Cliente).Include(m=>m.Mercancia).ToListAsync();
        }
        public async Task<Paquete> ObtenerPaquetePorId(int id)
        {
            return await _context.Paquete.Include(c => c.Cliente).Include(m => m.Mercancia).FirstOrDefaultAsync(p => p.PaqueteId == id);
        }
        public async Task RegistrarPaquete(Paquete paquete)
        {
            _context.Add(paquete);
            await _context.SaveChangesAsync();
        }
        public async Task EditarPaquete(Paquete paquete)
        {
            _context.Update(paquete);
            await _context.SaveChangesAsync();
        }
    }
}
