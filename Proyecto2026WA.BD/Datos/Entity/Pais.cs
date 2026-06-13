using System.ComponentModel.DataAnnotations;

namespace Proyecto2026WA.BD.Datos.Entity
{
    public class Pais : EntityBase
    {
        [Required(ErrorMessage = "El datos es obligatorio")]
        [MaxLength(2, ErrorMessage = "Máxima longitud 2 caracteres.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El datos es obligatorio")]
        [MaxLength(200, ErrorMessage = "Máxima longitud 200 caracteres.")]
        public string Nombre { get; set; }
    }
}
    