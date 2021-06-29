using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using castgroup.models;
using castgroup.models.Dtos;
using castgroup.repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace castgroup.repositories
{
    internal class CursoRepository : ICursoRepository
    {
        private readonly CursosContext context;
        public CursoRepository(CursosContext context) => this.context = context;

        public async Task<IEnumerable<Curso>> All()
        {
            return await context.Cursos.Include(x => x.Categoria).ToListAsync();
        }

        public async Task Delete(Guid id)
        {
            context.Cursos.Remove(await Get(id));
            await context.SaveChangesAsync();
        }

        public async Task<Curso> Get(Guid id)
        {
            return await context.Cursos.Include( x => x.Categoria).FirstOrDefaultAsync(x => x.CursoId == id);
        }

        public async Task<Curso> GetActiveCurseByDate(DateTime data)
        {
            return await context.Cursos.Include( x => x.Categoria).FirstOrDefaultAsync(x =>
                x.DataInicio <= data && x.DataTermino >= data
            );

        }

        public async Task<IEnumerable<Curso>> GetByFilter(FitlerCursosDto filter)
        {
            return await context.Cursos.Include(x => x.Categoria).Where(x =>
              (filter.CategoriaId == Guid.Empty || x.CategoriaId == filter.CategoriaId) &&
              (string.IsNullOrEmpty(filter.Nome) || x.Descricao.Contains(filter.Nome))
                )
                .ToListAsync();
        }

        public async Task Insert(Curso curso)
        {
            await context.AddAsync(curso);
            await context.SaveChangesAsync();
        }

        public async Task Update(Curso curso)
        {
            context.Update(curso);
            await context.SaveChangesAsync();
        }
    }
}
