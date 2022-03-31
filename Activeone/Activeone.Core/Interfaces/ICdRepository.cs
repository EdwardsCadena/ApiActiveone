using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activeone.Core.Entities;

namespace Activeone.Core.Interfaces
{
    public interface ICdRepository
    {
        Task<IEnumerable<Cd>> GetCds();
        Task InsertCD(Cd cd);
        Task<Cd> GetCd(int id);
        Task<bool> UpdateCd(Cd cd);
        Task<bool> DeleteCd(int id);
    }
}
