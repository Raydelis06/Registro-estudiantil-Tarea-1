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
        public string Nombres { get; set; } = string.Empty;
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Email { get; set; } = string.Empty;
    }
}
