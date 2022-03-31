using System;
using System.Collections.Generic;

namespace Activeone.Core.Entities
{ 
    public partial class Cliente
    {
        public Cliente()
        {
            Alquilers = new HashSet<Alquiler>();
            Sancions = new HashSet<Sancion>();
        }

        public int IdCliente { get; set; }
        public string? NroDni { get; set; }
        public string? NombreCliente { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public DateTime? Fechanacimiento { get; set; }
        public DateTime? Fechainscripcion { get; set; }
        public string? TemaInteres { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Alquiler> Alquilers { get; set; }
        public virtual ICollection<Sancion> Sancions { get; set; }
    }
}
