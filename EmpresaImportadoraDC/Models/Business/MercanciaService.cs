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
    public class MercanciaService : IMercanciaService
    {
        private readonly AppDbContext _context;

        public MercanciaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Mercancia>> ObtenerListaMercancia()
        {
            return await _context.Mercancia.ToListAsync();
        }

        public async Task<Mercancia> ObtenerMercanciaPorId(int id)
        {
            //return await _context.Empleados.Include(x => x.Cargo).FindAsync(id);
            return await _context.Mercancia.FirstOrDefaultAsync(x => x.MercanciaId == id);
        }

        public async Task GuardarMercancia(Mercancia mercancia)
        {
            _context.Add(mercancia);
            await _context.SaveChangesAsync();
        }

        public async Task EditarMercancia(Mercancia mercancia)
        {
            _context.Update(mercancia);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarMarcancia(int id)
        {
            var mercancia = await ObtenerMercanciaPorId(id);
            _context.Remove(mercancia);
            await _context.SaveChangesAsync();
        }



    }
}