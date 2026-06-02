using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto2026WA.BD.Datos.Entity
{
    public class Domiclio : EntityBase
    {
        [Required(ErrorMessage = "El datos es obligatorio")]
        [MaxLength(200, ErrorMessage = "Máxima longitud 200 caracteres.")]
        public string Calle { get; set; } = "S/D";
        
        [Required(ErrorMessage = "El datos es obligatorio")]
        [MaxLength(10, ErrorMessage = "Máxima longitud 10 caracteres.")]
        public string Numero { get; set; } = string.Empty;

        [Required(ErrorMessage = "El datos es obligatorio")]
        public int IdLocalida { get; set; }
        public Localidad Localidad { get; set; }
    }
}
