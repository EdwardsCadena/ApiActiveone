using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Activeone.Core.Entities;
using Activeone.Core.Interfaces;
using Activeone.Infrastructure.Data;

namespace Activeone.Infrastructure.Repositories
{
    public class CdRepository : ICdRepository
    {
        private readonly activeone1Context _context;

        public CdRepository(activeone1Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cd>> GetCds()
        {
            var posts = await _context.Cds.ToListAsync();
            return posts;
        }
        public async Task<Cd> GetCd(int id)
        {
            var Cds = await _context.Cds.FirstOrDefaultAsync(x => x.IdCd == id);
            return Cds;

        }
        public async Task InsertCD(Cd cd)
        {
            _context.Cds.Add(cd);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateCd(Cd cd)
        {
            var result = await GetCd(cd.IdCd);
            result.Condicion = cd.Condicion;
            result.Ubicacion = cd.Ubicacion;
            result.Estado = cd.Estado;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> DeleteCd(int id)
        {
            var delete = await GetCd(id);
            _context.Remove(delete);
            int row = await _context.SaveChangesAsync();
            return row > 0;
        }
    }
}
