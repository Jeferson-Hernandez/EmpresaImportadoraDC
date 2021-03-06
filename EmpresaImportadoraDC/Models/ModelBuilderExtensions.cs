using EmpresaImportadoraDC.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaImportadoraDC.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estado>().HasData(
                new Estado
                {
                    EstadoId = 1,
                    TipoEstado = "En Bodega Miami"
                },
                new Estado
                {
                    EstadoId = 2,
                    TipoEstado = "En tránsito a Colombia"
                },
                new Estado
                {
                    EstadoId = 3,
                    TipoEstado = "En bodega Colombia"
                },
                new Estado
                {
                    EstadoId = 4,
                    TipoEstado = "En tránsito a dirección del cliente"
                },
                new Estado
                {
                    EstadoId = 5,
                    TipoEstado = "Entregado"
                }
            );
            modelBuilder.Entity<ValorLibra>().HasData(
                new ValorLibra
                {
                    ValorLibraId = 1,
                    ValorLi = 0
                }
            );
            modelBuilder.Entity<Mercancia>().HasData(
                new Mercancia
                {
                    MercanciaId = 1,
                    TipoMercancia = "Frágil"
                },
                new Mercancia
                {
                    MercanciaId = 2,
                    TipoMercancia = "Pesadas"
                },
                new Mercancia
                {
                    MercanciaId = 3,
                    TipoMercancia = "Peligrosas"
                },
                new Mercancia
                {
                    MercanciaId = 4,
                    TipoMercancia = "Perecederas"
                }
            );
        }
    }
}
