using System;
using System.Collections.Generic;

namespace Activeone.Core.Entities
{ 
    public partial class Sancion
    {
        public int Idsancion { get; set; }
        public string? Tipodesancion { get; set; }
        public decimal? Valor { get; set; }
        public int? Numerodiassancion { get; set; }
        public int? IdclienteSancion { get; set; }
        public int? IdAlquilerSancion { get; set; }

        public virtual Alquiler? IdAlquilerSancionNavigation { get; set; }
        public virtual Cliente? IdclienteSancionNavigation { get; set; }
    }
}
