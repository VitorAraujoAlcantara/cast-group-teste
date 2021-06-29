using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using castgroup.models;
using castgroup.repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace castgroup.repositories
{
    internal class CategoriaRepository: ICategoriaRepository
    {
        private readonly CursosContext context;

        public CategoriaRepository(CursosContext context) => this.context = context;


        public async Task<IEnumerable<Categoria>> All()
        {
            return await context.Categorias.OrderBy(x => x.Descricao).ToListAsync();
        }
    }
}
