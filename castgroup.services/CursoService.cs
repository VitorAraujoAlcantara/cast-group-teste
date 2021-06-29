using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using castgroup.models;
using castgroup.models.Dtos;
using castgroup.repositories.Interfaces;
using castgroup.services.Exceptions;
using castgroup.services.interfaces;

namespace castgroup.services
{
    internal class CursoService : ICursoService
    {
        private readonly ICursoRepository repository;

        public CursoService(ICursoRepository repository)
        {
            this.repository = repository;
        }

        public Task<IEnumerable<Curso>> All()
        {
            return repository.All();
        }

        public Task Delete(Guid id)
        {
            return repository.Delete(id);
        }

        public Task<Curso> Get(Guid id)
        {
            return repository.Get(id);
        }

        public Task<IEnumerable<Curso>> GetByFilter(FitlerCursosDto filterCurso)
        {
            return repository.GetByFilter(filterCurso);
        }

        public async Task Insert(Curso curso)
        {
            const string MSG = "Existe(m) curso(s) planejados(s) dentro do período informado.";
            var cursoExistenteNaAbertura = await repository.GetActiveCurseByDate(curso.DataInicio);
            if ( cursoExistenteNaAbertura != null)
            {
                throw new CursoExistentePeriodoException(MSG);
            }
            var cursoExistenteNoFechamento = await repository.GetActiveCurseByDate(curso.DataTermino);
            if ( cursoExistenteNoFechamento != null)
            {
                throw new CursoExistentePeriodoException(MSG);
            }
            await repository.Insert(curso);
        }

        public Task Update(Curso curso)
        {
            return repository.Update(curso);
        }
    }
}
