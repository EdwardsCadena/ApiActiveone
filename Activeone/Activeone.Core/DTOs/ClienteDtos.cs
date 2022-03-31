using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activeone.Core.DTOs
{
    public class ClienteDtos
    {
        public string? NroDni { get; set; }
        public string? NombreCliente { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public DateTime? Fechanacimiento { get; set; }
        public DateTime? Fechainscripcion { get; set; }
        public string? TemaInteres { get; set; }
        public bool? Estado { get; set; }
    }
}
