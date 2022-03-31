using Activeone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activeone.Core.Interfaces
{
    public interface ICobrarRepository
    {
        Task<List<Cliente>> CobrarAlquile();
    }
}
