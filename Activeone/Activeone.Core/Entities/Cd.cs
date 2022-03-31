using System;
using System.Collections.Generic;

namespace Activeone.Core.Entities
{
    public partial class Cd
    {
        public Cd()
        {
            Detallealquilers = new HashSet<Detallealquiler>();
        }

        public int IdCd { get; set; }
        public string? Condicion { get; set; }
        public string? Ubicacion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Detallealquiler> Detallealquilers { get; set; }
    }
}
