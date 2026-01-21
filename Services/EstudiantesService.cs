using Microsoft.EntityFrameworkCore;
using Registro_estudiantil___Tarea_1.DAL;
using Registro_estudiantil___Tarea_1.Models;
using System.Linq.Expressions;

namespace Registro_estudiantil___Tarea_1.Services
{
    public class EstudiantesService(IDbContextFactory<Contexto> DbFactory)
    {

        //Metodo insertar
        public async Task<bool> Insertar(Estudiantes estudiante)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Estudiantes.Add(estudiante);
            return await contexto.SaveChangesAsync() > 0;

        }
        //Metodo existe
        public async Task<bool> Existe(int estudianteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Estudiantes.AnyAsync(e => e.EstudianteId == estudianteId);
        }
        //Metodo guardar
        public async Task<bool> Guardar(Estudiantes estudiante)
        {
            if (!await Existe(estudiante.EstudianteId))
            {
                return await Insertar(estudiante);
            }
            else
            {
                return await Modificar(estudiante);
            }

        }

        //Metodo modificar
        public async Task<bool> Modificar(Estudiantes estudiante)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(estudiante);
            return await contexto.SaveChangesAsync() > 0;
        }

        //Metodo buscar
        public async Task<Estudiantes?> Buscar(int estudianteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Estudiantes.FirstOrDefaultAsync(e => e.EstudianteId == estudianteId);
        }

        //Metodo eliminar
        public async Task<bool> Eliminar(int estudianteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var estudiante = await contexto.Estudiantes.FindAsync(estudianteId);
            return await contexto.Estudiantes.AsNoTracking().Where(e => e.EstudianteId == estudianteId).ExecuteDeleteAsync() > 0;
        }
        //Metodo listar
        public async Task<List<Estudiantes>> Listar(Expression<Func<Estudiantes,bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Estudiantes.Where(criterio).AsNoTracking().ToListAsync();
        }
    }

}
