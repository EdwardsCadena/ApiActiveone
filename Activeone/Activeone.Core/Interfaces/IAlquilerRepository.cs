using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activeone.Core.Entities;

namespace Activeone.Core.Interfaces
{
    public interface IAlquilerRepository
    {
        Task<IEnumerable<Alquiler>> GetAlquilers();
        Task<Alquiler> GetAlquiler(int id);
        Task InsertAlquiler(Alquiler alquiler);
        Task<bool> Updatealquiler(Alquiler alquiler);
        Task<bool> DeleteAlquiler(int id);
    }
}
