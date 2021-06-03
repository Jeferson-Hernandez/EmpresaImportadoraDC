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
    public class ClienteService : IClienteService
    {
        private readonly AppDbContext _context;

        public ClienteService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Cliente>> ObtenerListaClientes()
        {
            return await _context.Cliente.ToListAsync();
        }
        public async Task RegistrarCliente(Cliente cliente)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
        }
        public async Task<Cliente> ObtenerClientePorId(int id)
        {
            //return await _context.Empleados.Include(x => x.Cargo).FindAsync(id);
            return await _context.Cliente.FirstOrDefaultAsync(x => x.ClienteId == id);
        }
        public async Task EditarCliente(Cliente cliente)
        {
            _context.Update(cliente);
            await _context.SaveChangesAsync();
        }
        public async Task EliminarCliente(int id)
        {
            var cliente = await ObtenerClientePorId(id);
            _context.Remove(cliente);
            await _context.SaveChangesAsync();
        }

    }
}