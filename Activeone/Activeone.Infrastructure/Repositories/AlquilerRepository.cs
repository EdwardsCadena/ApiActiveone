using Microsoft.EntityFrameworkCore;
using Activeone.Core.Entities;
using Activeone.Core.Interfaces;
using Activeone.Infrastructure.Data;

namespace Activeone.Infrastructure.Repositories
{
    public class AlquilerRepository : IAlquilerRepository
    {
        private readonly activeone1Context _context;

        public AlquilerRepository(activeone1Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Alquiler>> GetAlquilers()
        {
            var posts = await _context.Alquilers.ToListAsync();
            return posts;
        }
        public async Task<Alquiler> GetAlquiler(int id)
        {
            var alquiler = await _context.Alquilers.FirstOrDefaultAsync(x => x.IdAlquiler == id);
            return alquiler;

        }
        public async Task InsertAlquiler(Alquiler alquiler)
        {
            _context.Alquilers.Add(alquiler);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> Updatealquiler(Alquiler alquiler)
        {
            var result = await GetAlquiler(alquiler.IdAlquiler);
            result.IdclienteNavigation = alquiler.IdclienteNavigation;
            result.FechaAkquiler = alquiler.FechaAkquiler;
            result.Valor = alquiler.Valor;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> DeleteAlquiler(int id)
        {
            var delete = await GetAlquiler(id);
            _context.Remove(delete);
            int row = await _context.SaveChangesAsync();
            return row > 0;
        }
    }
}
