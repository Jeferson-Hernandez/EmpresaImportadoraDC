using EmpresaImportadoraDC.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaImportadoraDC.Models.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):
            base(options)
        {

        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Mercancia> Mercancia { get; set; }
        public DbSet<Paquete> Paquete { get; set; }
        public DbSet<Transportadora> Transportadora { get; set; }
        public DbSet<ValorLibra> ValorLibra { get; set; }
        public DbSet<ValorLibra> Estado { get; set; }

    }
}
