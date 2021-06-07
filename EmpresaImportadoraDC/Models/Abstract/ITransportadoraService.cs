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
    }
}
