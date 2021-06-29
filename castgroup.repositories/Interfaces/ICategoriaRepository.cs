
using System.Collections.Generic;
using System.Threading.Tasks;
using castgroup.models;

namespace castgroup.repositories.Interfaces
{

    /// <summary>
    /// Interface que implementa o acesso aos dados para entidade Categoria
    /// Utiliza como padrão : Repository Pattern
    /// </summary>
    public interface ICategoriaRepository
    {
        /// <summary>
        /// Retorna todos os registros
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Categoria>> All();
    }
}
