using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using castgroup.models;
using castgroup.models.Dtos;

namespace castgroup.services.interfaces
{
    public interface ICursoService
    {       
        Task Insert(Curso curso);
        Task Update(Curso curso);
        Task<Curso> Get(Guid id);
        Task<IEnumerable<Curso>> All();
        Task<IEnumerable<Curso>> GetByFilter(FitlerCursosDto filterCurso);
        Task Delete(Guid id);
    }
}
