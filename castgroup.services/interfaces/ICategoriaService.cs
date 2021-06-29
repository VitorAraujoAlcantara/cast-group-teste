using System.Collections.Generic;
using System.Threading.Tasks;
using castgroup.models;

namespace castgroup.services.interfaces
{
    public interface ICategoriaService
    {
        /// <summary>
        /// Retorna todos os registros 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Categoria>> All();
    }
}
