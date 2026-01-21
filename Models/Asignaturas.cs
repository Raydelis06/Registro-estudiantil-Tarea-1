using System.ComponentModel.DataAnnotations;

namespace Registro_estudiantil___Tarea_1.Models
{
    public class Asignaturas
    {
        [Key]
        public int AsignaturaId { get; set; }
        [Required (ErrorMessage = "Este campo es obligatorio")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Aula { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(1, 11, ErrorMessage = "Cantidad de creditos invalida")]
        public int Creditos { get; set; }
    }
}
