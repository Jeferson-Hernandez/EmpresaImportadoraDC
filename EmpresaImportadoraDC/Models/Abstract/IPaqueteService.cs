using EmpresaImportadoraDC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaImportadoraDC.Models.Abstract
{
    public interface IPaqueteService
    {
        Task<IEnumerable<Paquete>> ObtenerListaPaquetes();
        Task RegistrarPaquete(Paquete paquete);
        Task<Paquete> ObtenerPaquetePorId(int id);
        Task EditarPaquete(Paquete paquete);
        Task EliminarPaquete(int id);
        Task<IEnumerable<Paquete>> ObtenerListaPaquetesPorId(int id);
    }
}
