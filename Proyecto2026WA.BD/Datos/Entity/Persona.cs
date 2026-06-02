using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto2026WA.BD.Datos.Entity
{
    public class Persona : EntityBase
    {
        [Required(ErrorMessage = "El datos es obligatorio")]
        [MaxLength(10, ErrorMessage ="Máxima longitud 10 caracteres.")] 
        public  string DNI { get; set; }
        
        [Required(ErrorMessage = "El datos es obligatorio")]
        [MaxLength(100, ErrorMessage = "Máxima longitud 100 caracteres.")]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage = "El datos es obligatorio")]
        [MaxLength(100, ErrorMessage = "Máxima longitud 100 caracteres.")]
        public string Apellido { get; set; }
    }
}
