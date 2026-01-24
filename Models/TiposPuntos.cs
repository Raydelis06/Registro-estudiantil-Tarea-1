using System.ComponentModel.DataAnnotations;

namespace Registro_estudiantil___Tarea_1.Models
{
    public class TiposPuntos
    {
        [Key]
        public int TipoId { get; set; }
        [Required(ErrorMessage =" El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = " La descripcion es obligatoria")]
        public string Descripcion { get; set; }
    }
}
