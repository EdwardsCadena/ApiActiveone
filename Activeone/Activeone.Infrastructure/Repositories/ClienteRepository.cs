using Microsoft.EntityFrameworkCore;
using Activeone.Core.Entities;
using Activeone.Core.Interfaces;
using Activeone.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activeone.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly activeone1Context _context;

        public ClienteRepository(activeone1Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            var posts = await _context.Clientes.ToListAsync();
            return posts;
        }
        public async Task<Cliente> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.IdCliente == id);
            return cliente;

        }   
        public async Task InsertCliente(Cliente clientes)
        {
            _context.Clientes.Add(clientes);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateCliente(Cliente cliente)
        {
            var result = await GetCliente(cliente.IdCliente);
            result.NroDni = cliente.NroDni;
            result.NombreCliente = cliente.NombreCliente;
            result.Email = cliente.Email;
            result.Telefono = cliente.Telefono;
            result.Direccion = cliente.Direccion;
            result.Fechanacimiento = cliente.Fechanacimiento;
            result.Fechainscripcion = cliente.Fechainscripcion;
            result.TemaInteres = cliente.TemaInteres;
            result.Estado = cliente.Estado;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> DeleteCliente(int id)
        {
            var delete = await GetCliente(id);   
            _context.Remove(delete);
            int row = await _context.SaveChangesAsync();
            return row > 0;
        }

    }
}
