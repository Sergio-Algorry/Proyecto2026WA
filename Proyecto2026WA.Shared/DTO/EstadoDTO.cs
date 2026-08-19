using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto2026WA.Shared.DTO
{
    public class EstadoDTO
    {
        public int Id { get; set; }
        public int PaisId { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
