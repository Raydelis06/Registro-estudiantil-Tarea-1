using BlazorBootstrap;
using Microsoft.EntityFrameworkCore;
using Registro_estudiantil___Tarea_1.DAL;
using Registro_estudiantil___Tarea_1.Models;
using System.Linq.Expressions;

namespace Registro_estudiantil___Tarea_1.Services
{
    public class AsignaturasService(IDbContextFactory<Contexto> DbFactory)
    {

        //Metodo insertar
        public async Task<bool> Insertar(Asignaturas asignatura)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Asignaturas.Add(asignatura);
            return await contexto.SaveChangesAsync() > 0;

        }
        //Metodo existe
        public async Task<bool> Existe(string asignaturaNombre)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Asignaturas.AnyAsync(a => a.Nombre == asignaturaNombre);
        }
        public async Task<bool> Existe(int asignaturaId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Asignaturas.AnyAsync(a => a.AsignaturaId == asignaturaId);
        }
        //Metodo guardar
        public async Task<bool> Guardar(Asignaturas asignatura)
        {
            if (!await Existe(asignatura.AsignaturaId))//Si no existe por Id
            {
                if (await Existe(asignatura.Nombre))//Si existe por nombre
                {
                    return false;
                }
                return await Insertar(asignatura);
            }
            else//Si existe por Id
            {
                return await Modificar(asignatura);
            }

        }

        //Metodo modificar
        public async Task<bool> Modificar(Asignaturas asignatura)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(asignatura);
            return await contexto.SaveChangesAsync() > 0;
        }

        //Metodo buscar
        public async Task<Asignaturas?> Buscar(int asignaturaId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Asignaturas.FirstOrDefaultAsync(a => a.AsignaturaId == asignaturaId);
        }

        //Metodo eliminar
        public async Task<bool> Eliminar(int asignaturaId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var asignatura = await contexto.Asignaturas.FindAsync(asignaturaId);
            return await contexto.Asignaturas.AsNoTracking().Where(a => a.AsignaturaId == asignaturaId).ExecuteDeleteAsync() > 0;
        }
        //Metodo listar
        public async Task<List<Asignaturas>> Listar(Expression<Func<Asignaturas, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Asignaturas.Where(criterio).AsNoTracking().ToListAsync();
        }
    }
}
