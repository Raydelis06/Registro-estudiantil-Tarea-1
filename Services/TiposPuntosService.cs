using Microsoft.EntityFrameworkCore;
using Registro_estudiantil___Tarea_1.DAL;
using Registro_estudiantil___Tarea_1.Models;
using System.Linq.Expressions;

namespace Registro_estudiantil___Tarea_1.Services
{
    public class TiposPuntosService(IDbContextFactory<Contexto> DbFactory)
    {
        //Metodo insertar
        public async Task<bool> Insertar(TiposPuntos tipoPunto)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.TiposPuntos.Add(tipoPunto);
            return await contexto.SaveChangesAsync() > 0;

        }
        //Metodo existe
        public async Task<bool> Existe(string puntoNombre)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.TiposPuntos.AnyAsync(a => a.Nombre == puntoNombre);
        }
        public async Task<bool> Existe(int tipoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.TiposPuntos.AnyAsync(a => a.TipoId == tipoId);
        }
        //Metodo guardar
        public async Task<bool> Guardar(TiposPuntos tipoPunto)
        {
            if (!await Existe(tipoPunto.TipoId))//Si no existe por Id
            {
                if (await Existe(tipoPunto.Nombre))//Si existe por nombre
                {
                    return false;
                }
                return await Insertar(tipoPunto);
            }
            else//Si existe por Id
            {
                return await Modificar(tipoPunto);
            }

        }

        //Metodo modificar
        public async Task<bool> Modificar(TiposPuntos tipoPunto)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(tipoPunto);
            return await contexto.SaveChangesAsync() > 0;
        }

        //Metodo buscar
        public async Task<TiposPuntos?> Buscar(int tipoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.TiposPuntos.FirstOrDefaultAsync(a => a.TipoId == tipoId);
        }

        //Metodo eliminar
        public async Task<bool> Eliminar(int tipoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var tipoPunto = await contexto.TiposPuntos.FindAsync(tipoId);
            return await contexto.TiposPuntos.AsNoTracking().Where(a => a.TipoId == tipoId).ExecuteDeleteAsync() > 0;
        }
        //Metodo listar
        public async Task<List<TiposPuntos>> Listar(Expression<Func<TiposPuntos, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.TiposPuntos.Where(criterio).AsNoTracking().ToListAsync();
        }
    }
}
