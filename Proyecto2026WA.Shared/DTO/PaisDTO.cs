using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto2026WA.Shared.DTO
{
    public class PaisDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Código de pais es obligatorio")]
        [MaxLength(2, ErrorMessage = "Máxima longitud 2 caracteres.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El Nombre de pais es obligatorio")]
        [MaxLength(200, ErrorMessage = "Máxima longitud 200 caracteres.")]
        public string Nombre { get; set; }
    }
}
