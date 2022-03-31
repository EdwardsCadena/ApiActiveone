using System;
using System.Collections.Generic;

namespace Activeone.Core.Entities
{
    public partial class Alquiler
    {
        public Alquiler()
        {
            Detallealquilers = new HashSet<Detallealquiler>();
            Sancions = new HashSet<Sancion>();
        }

        public int IdAlquiler { get; set; }
        public DateTime? FechaAkquiler { get; set; }
        public decimal? Valor { get; set; }
        public int? Idcliente { get; set; }

        public virtual Cliente? IdclienteNavigation { get; set; }
        public virtual ICollection<Detallealquiler> Detallealquilers { get; set; }
        public virtual ICollection<Sancion> Sancions { get; set; }
    }
}
