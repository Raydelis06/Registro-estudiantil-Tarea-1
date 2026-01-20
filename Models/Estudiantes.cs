using System.ComponentModel.DataAnnotations;

namespace Registro_estudiantil___Tarea_1.Models

{
    public class Estudiantes
    {
        public Estudiantes()
        {
        }

        [Key]
        public int EstudianteId { get; set; }

        [Required (ErrorMessage = "Este campo es obligatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        public string? Nombres { get; set; } 
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo debe tener un formato válido (ej: usuario@dominio.com)")]
        public string? Email { get; set; } 
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(1, 100, ErrorMessage = "Edad inválida")]
        public int? Edad { get; set; }
    }
}
