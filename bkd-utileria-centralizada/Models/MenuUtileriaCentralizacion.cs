using System;
using System.Collections.Generic;

namespace bkd_utileria_centralizada.Models
{
    public partial class MenuUtileriaCentralizacion
    {
        public int Id { get; set; }
        public string? IconoOpcion { get; set; }
        public string? NombreOpcion { get; set; }
        public string? IconoSiguiente { get; set; }
        public int? IsActive { get; set; }
    }
}
