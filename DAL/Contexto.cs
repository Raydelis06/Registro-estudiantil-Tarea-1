using Microsoft.EntityFrameworkCore;
using Registro_estudiantil___Tarea_1.Models;

namespace Registro_estudiantil___Tarea_1.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Estudiantes> Estudiantes { get; set; }
    }
}
