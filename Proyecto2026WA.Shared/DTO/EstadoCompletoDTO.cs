using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto2026WA.Shared.DTO
{
    public class EstadoCompletoDTO
    {
        public int Id { get; set; }
        public int PaisId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Codigo { get; set; }
        public PaisDTO Pais { get; set; }
    }
}
