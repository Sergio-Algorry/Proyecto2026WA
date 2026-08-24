using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto2026WA.BD.Datos.Entity
{
    public class Estado : EntityBase
    {
        [Required(ErrorMessage = "El dato es obligatorio")]
        [MaxLength(2, ErrorMessage = "Máxima longitud 2 caracteres.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El dato es obligatorio")]
        [MaxLength(150, ErrorMessage = "Máxima longitud 150 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El dato es obligatorio")]
        public int PaisId { get; set; }
        public Pais Pais { get; set; }
    }
}
