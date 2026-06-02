using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto2026WA.BD.Datos.Entity
{
    public class Estado : EntityBase
    {
        [Required(ErrorMessage = "El datos es obligatorio")]
        [MaxLength(150, ErrorMessage = "Máxima longitud 150 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El datos es obligatorio")]
        public int IdPais { get; set; }
        public Pais Pais { get; set; }
    }
}
