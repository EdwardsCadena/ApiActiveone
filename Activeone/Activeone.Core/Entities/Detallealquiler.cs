using System;
using System.Collections.Generic;

namespace Activeone.Core.Entities
{
    public partial class Detallealquiler
    {
        public int IdDetallealquiler { get; set; }
        public int? Diasdeprestamos { get; set; }
        public DateTime? Fechadevolucion { get; set; }
        public int? IdCddetalle { get; set; }
        public int? IdAlquilerdetalle { get; set; }

        public virtual Alquiler? IdAlquilerdetalleNavigation { get; set; }
        public virtual Cd? IdCddetalleNavigation { get; set; }
    }
}
