
using Activeone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activeone.Core.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClientes();
        Task InsertCliente(Cliente clientes);
        Task<Cliente> GetCliente(int id);
        Task<bool> UpdateCliente(Cliente cliente);
        Task<bool> DeleteCliente(int id);
    }
}
