using EmpresaImportadoraDC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaImportadoraDC.Models.Abstract
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> ObtenerListaClientes();
        Task RegistrarCliente(Cliente cliente);
        Task<Cliente> ObtenerClientePorId(int id);
        Task EditarCliente(Cliente cliente);
        Task EliminarCliente(int id);
    }
}
