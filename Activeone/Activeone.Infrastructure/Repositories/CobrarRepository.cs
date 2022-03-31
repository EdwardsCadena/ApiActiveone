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
    public class CobrarRepository : ICobrarRepository
    {
        private readonly activeone1Context _context;

        public CobrarRepository(activeone1Context context)
        {
            _context = context;
        }
        public async Task<List<Cliente>> CobrarAlquile()
        {
            Random r = new Random();
            string Multa = "500";
            List<Cliente> ret = new List<Cliente>();
            Cliente repositorio = new Cliente();
            var dtos = repositorio.IdCliente;
            List<Alquiler> retS = new List<Alquiler>();
            Alquiler alquiler = new Alquiler();
            var rND = alquiler.IdAlquiler;
            for (int i = 1; i == dtos; i++)
            {
                Sancion sancions = new Sancion();
                sancions.IdclienteSancion = dtos;
                sancions.IdAlquilerSancion = rND;
                sancions.Numerodiassancion = r.Next(1, 10);
                var respuesta = sancions.Numerodiassancion * Convert.ToInt16(Multa);
                sancions.Tipodesancion = Convert.ToString(respuesta);
                _context.Add(sancions);
            }


        }
    }
}

