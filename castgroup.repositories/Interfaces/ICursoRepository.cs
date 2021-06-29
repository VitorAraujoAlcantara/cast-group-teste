using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using castgroup.models;
using castgroup.models.Dtos;

namespace castgroup.repositories.Interfaces
{
    /// <summary>
    /// Interface que implementa o acesso aos dados para entidade Curso
    /// Utiliza como padrão : Repository Pattern
    /// </summary>
    public interface ICursoRepository
    {
        /// <summary>
        /// Adiciona um novo registro
        /// </summary>
        /// <param name="curso"></param>
        /// <returns></returns>
        Task Insert(Curso curso);
        /// <summary>
        /// Atualiza um registro existente
        /// </summary>
        /// <param name="curso"></param>
        /// <returns></returns>
        Task Update(Curso curso);
        /// <summary>
        /// Retorna um registro pelo seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Curso> Get(Guid id);
        /// <summary>
        /// Traz todos os registros 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Curso>> All();
        /// <summary>
        /// Traz os registros aplicando um filtro
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<IEnumerable<Curso>> GetByFilter(FitlerCursosDto filter);
        /// <summary>
        /// Traz o registro que está em vigência na data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<Curso> GetActiveCurseByDate(DateTime data);
        /// <summary>
        /// Remove um registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(Guid id);
    }
}
