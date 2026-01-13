using Microsoft.EntityFrameworkCore;

namespace Registro_estudiantil___Tarea_1.Components.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Models.Estudiantes> Estudiantes { get; set; }
    }
}
