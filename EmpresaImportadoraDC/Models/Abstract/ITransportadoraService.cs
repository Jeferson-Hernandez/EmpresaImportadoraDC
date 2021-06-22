using EmpresaImportadoraDC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaImportadoraDC.Models.Abstract
{
    public interface ITransportadoraService
    {
        Task<IEnumerable<Transportadora>> ObtenerListaTransportadoras();
        Task RegistrarTransportadora(Transportadora transportadora);
        Task<Transportadora> ObtenerTransportadoraPorId(int Id);
        Task EditarTransportadora(Transportadora transportadora);
        Task EliminarTransportadora(int Id);
        Task<IEnumerable<Transportadora>> ObtenerListaTransportadorasUSA();
        Task<IEnumerable<Transportadora>> ObtenerListaTransportadorasCO();
    }
}
