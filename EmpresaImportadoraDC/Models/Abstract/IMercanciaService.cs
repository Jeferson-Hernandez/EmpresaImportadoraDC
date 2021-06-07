using EmpresaImportadoraDC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaImportadoraDC.Models.Abstract
{
    public interface IMercanciaService
    {
        Task<IEnumerable<Mercancia>> ObtenerListaMercancia();
        Task GuardarMercancia(Mercancia mercancia);
        Task<Mercancia> ObtenerMercanciaPorId(int id);
        Task EditarMercancia(Mercancia mercancia);
        Task EliminarMarcancia(int id);
    }
}