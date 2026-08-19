using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto2026WA.BD.Datos.Entity
{
    public class PersonaDomicilio : EntityBase          
    {
        [Required(ErrorMessage = "El datos es obligatorio")]
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }

        [Required(ErrorMessage = "El datos es obligatorio")]
        public int DomicilioId { get; set; }
        public Domiclio Domicilio { get; set; }
    }
}
