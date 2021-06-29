using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using castgroup.models;
using castgroup.repositories.Interfaces;
using castgroup.services;
using castgroup.services.interfaces;
using Moq;
using Xunit;

namespace castgroup.tests.Services
{
    public class CategoriaServiceTest
    {
        private readonly ICategoriaService service;
        private readonly Mock<ICategoriaRepository> repository;

        public CategoriaServiceTest()
        {
            repository = new Mock<ICategoriaRepository>();
            service = new CategoriaService(repository.Object);
        }

        [Fact(DisplayName = "All => Deve utilizar camada de repository")]
        public async Task All_DeveUtilizarCamadaDeRepository()
        {
            await service.All();
            repository.Verify(m => m.All(), Times.Once);
        }

        [Fact(DisplayName = "All => Deve retornar objeto obtido na camada de repository")]
        public async Task All_DeveRetornarObjetoObtidoNaCamadaDeRepository()
        {
            IEnumerable<Categoria> resp = new List<Categoria>();
            repository.Setup(m => m.All()).Returns(Task.FromResult(resp));
            var ret = await service.All();
            Assert.Same(resp, ret);
        }

    }
}
