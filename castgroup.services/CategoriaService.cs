using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using castgroup.models;
using castgroup.repositories.Interfaces;
using castgroup.services.interfaces;

namespace castgroup.services
{
    internal class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            this.repository = repository;
        }

        public Task<IEnumerable<Categoria>> All()
        {
            return repository.All();
        }
    }
}
