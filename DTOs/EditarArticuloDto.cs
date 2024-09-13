using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practica02.DTOs
{
    public class EditarArticuloDto
    {
        [MinLength(1), MaxLength(50)]
        public string? Nombre { get; set; }

        [Range(1, double.MaxValue)]
        public decimal? PrecioUnitario { get; set; }
    }
}