using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using castgroup.models;
using castgroup.models.Dtos;
using castgroup.repositories.Interfaces;
using castgroup.services;
using castgroup.services.Exceptions;
using castgroup.services.interfaces;
using Moq;
using Xunit;

namespace castgroup.tests.Services
{
    public class CursoServiceTest
    {
        private readonly ICursoService service;
        private readonly Mock<ICursoRepository> repository;
        private readonly Curso model;
        public CursoServiceTest()
        {
            repository = new Mock<ICursoRepository>();
            service = new CursoService(repository.Object);

            model = new Curso();

        }

        [Fact(DisplayName = "Insert => Deve utilizar camada de repository")]
        public async Task Insert_DeveUtilizarCamadaDeRepository()
        {
            await service.Insert(model);
            repository.Verify(m => m.Insert(model), Times.Once);
        }

        [Fact(DisplayName = "Update => Deve utilizar camada de respository")]
        public async Task Update_DeveUtilizarCamadaDeRepository()
        {
            await service.Update(model);
            repository.Verify(m => m.Update(model), Times.Once);
        }

        [Fact(DisplayName = "Get => Deve utilizar camada de repository")]
        public async Task Get_DeveUtilizarCamadaDeRepository()
        {
            Guid ID = Guid.NewGuid();
            await service.Get(ID);
            repository.Verify(m => m.Get(ID), Times.Once);
        }

        [Fact(DisplayName = "Get => Deve devolver objeto obtido na camdada de repository")]
        public async Task Get_DeveDevolverObjetoObtidoNaCamadaDeRepository()
        {
            Guid ID = Guid.NewGuid();
            repository.Setup(m => m.Get(ID)).Returns(Task.FromResult(model));
            var ret = await service.Get(ID);
            Assert.Same(model, ret);
        }

        [Fact(DisplayName = "All => Deve utilizar camdada de repository")]
        public async Task All_DeveUtilizarCamadaDeRepostiory()
        {
            await service.All();
            repository.Verify(m => m.All(), Times.Once);
        }

        [Fact(DisplayName = "All => Deve retornar objeto obtido na camada de repository")]
        public async Task All_DeveUtilizarObjetoObtidoNaCamadaDeRepository()
        {
            IEnumerable<Curso> cursos = new List<Curso>();
            repository.Setup(m => m.All()).Returns(Task.FromResult(cursos));
            var ret = await service.All();
            Assert.Same(cursos, ret);
        }

        [Fact(DisplayName = "GetByFilter => Deve utilizar camada de repository")]
        public async Task GetByFilter_DeveUtilizarCamadaDeRepository()
        {
            FitlerCursosDto filter = new();
            await service.GetByFilter(filter);
            repository.Verify(m => m.GetByFilter(filter), Times.Once);
        }

        [Fact(DisplayName = "GetByFilter => Deve retornar objeto obtido na camada de repository")]
        public async Task GetByFilter_DeveRetornarObjetoObtidoNaCamadaDeRepository()
        {
            FitlerCursosDto filter = new();
            IEnumerable<Curso> cursos = new List<Curso>();
            repository.Setup(m => m.GetByFilter(filter)).Returns(Task.FromResult(cursos));
            var ret = await service.GetByFilter(filter);
            Assert.Same(cursos, ret);
        }

        [Fact(DisplayName = "Insert => Deve chamar a camada de repository para verificar algum curso pela data de abertura")]
        public async Task Insert_DeveChamarA_CamadaDeRepositoryParaVerificarAlgumCursoPelaDataDeAbertura()
        {
            model.DataInicio = DateTime.Now.Date;
            await service.Insert(model);
            repository.Verify(m => m.GetActiveCurseByDate(model.DataInicio), Times.Once);
        }

        [Fact(DisplayName = "Insert => Deve chamar a camada de repository para verificar algum curso pela data de fechamento")]
        public async Task Insert_DeveChamarA_CamadaDeRepositoryParaVerificarAlgumCursoPelaDataDeFechamento()
        {
            model.DataTermino = DateTime.Now.Date;
            await service.Insert(model);
            repository.Verify(m => m.GetActiveCurseByDate(model.DataTermino), Times.Once);
        }

        [Fact(DisplayName = "Insert => Caso exista algum curso no período de abertura deve subir CursoExistentePeriodoException")]
        public async Task Insert_CasoExistaAlgumCursoNoPeriodoDeAberturaDeveSubirCursoExistentePeriodoException()
        {
            model.DataInicio = DateTime.Now.Date;
            repository.Setup(m => m.GetActiveCurseByDate(model.DataInicio)).Returns(Task.FromResult(new Curso()));
            var ex = await Assert.ThrowsAsync<CursoExistentePeriodoException>(() => service.Insert(model));
            Assert.Equal("Existe(m) curso(s) planejados(s) dentro do período informado.", ex.Message);
        }

        [Fact(DisplayName = "Insert => Caso exista algum curso no período de fechamento deve subir CursoExistentePeriodoException")]
        public async Task Insert_CasoExistaAlgumCursoNoPeriodoDeFechamentoDeveSubirCursoExistentePeriodoException()
        {
            model.DataTermino = DateTime.Now.Date;
            repository.Setup(m => m.GetActiveCurseByDate(model.DataTermino)).Returns(Task.FromResult(new Curso()));
            var ex = await Assert.ThrowsAsync<CursoExistentePeriodoException>(() => service.Insert(model));
            Assert.Equal("Existe(m) curso(s) planejados(s) dentro do período informado.", ex.Message);
        }

        [Fact(DisplayName = "Delete => Deve utilizar repository para remover o item")]
        public async Task Delete_DeveUtilizarRepositoryParaRemoverOItem()
        {
            Guid id = Guid.NewGuid();
            await service.Delete(id);
            repository.Verify(m => m.Delete(id), Times.Once);
        }






    }
}
