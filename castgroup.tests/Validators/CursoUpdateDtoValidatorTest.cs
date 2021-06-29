using System;
using castgroup.models.Dtos;
using castgroup.validators;
using FluentValidation;
using Xunit;

namespace castgroup.tests.Validators
{
    public class CursoUpdateDtoValidatorTest
    {
        private readonly AbstractValidator<CursoUpdateDto> validations;
        private readonly CursoUpdateDto dto;
        public CursoUpdateDtoValidatorTest()
        {
            dto = new CursoUpdateDto();
            validations = new CursoUpdateDtoValidator();

            dto.DataInicio = DateTime.Now.AddDays(1).Date;
            dto.DataTermino = dto.DataInicio.AddDays(40);
            dto.Descricao = "TESTE";
            dto.CategoriaId = Guid.NewGuid();
            dto.QtdAlunos = null;

        }

        [Fact(DisplayName = "Validate => Teste de controle")]
        public void Validate_TesteControle()
        {
            var ret = validations.Validate(dto);
            Assert.True(ret.IsValid);
        }

        [Fact(DisplayName = "Validate => Não será permitida a inclusão de cursos com a data de início menor que a data atual")]
        public void Validate_NaoSeraPermitidoInclusaoComDataDeInicioMenorQueAtual()
        {
            dto.DataInicio = DateTime.Now.AddDays(-1).Date;
            var ret = validations.Validate(dto);
            Assert.False(ret.IsValid);
        }

        [Fact(DisplayName = "Validate => A descrição não pode ser vazia")]
        public void Validate_ADescricaoNaoPodeSerVazial()
        {
            dto.Descricao = string.Empty;
            var ret = validations.Validate(dto);
            Assert.False(ret.IsValid);
        }

        [Fact(DisplayName = "Validate => A descrição não pode ser nula")]
        public void Validate_ADescricaoNaoPodeSerNula()
        {
            dto.Descricao = null;
            var ret = validations.Validate(dto);
            Assert.False(ret.IsValid);
        }

        [Fact(DisplayName = "Validate => A descrição tem que ter pelo menos 5 caracteres")]
        public void Validate_ADescricaoTemQueTerPeloMenosCincoCaracteres()
        {
            dto.Descricao = "1234";
            var ret = validations.Validate(dto);
            Assert.False(ret.IsValid);
        }

        [Fact(DisplayName = "Validate => A descrição tem que ter menos de 100 caracteres")]
        public void Validate_ADescricaoTemQueTerMenosDeCemCaracteres()
        {
            dto.Descricao = "0123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789A";
            var ret = validations.Validate(dto);
            Assert.False(ret.IsValid);
        }

        [Fact(DisplayName = "Validate => A data de término tem que ser maior ou igual a data inicial")]
        public void Validate_ADataDeTerminoTemQueSerMaiorOuIgualADataInicial()
        {
            dto.DataTermino = dto.DataInicio.AddDays(-1);
            var ret = validations.Validate(dto);
            Assert.False(ret.IsValid);
        }

        [Fact(DisplayName = "Validate => A categoria não pode ser vazia")]
        public void Validate_ACategoriaNaoPodeSerVazia()
        {
            dto.CategoriaId = Guid.Empty;
            var ret = validations.Validate(dto);
            Assert.False(ret.IsValid);
        }

        [Fact(DisplayName = "Validate => A quantidade de alunos não pode ser zero")]
        public void Validate_AQuantidadeDeAlunosNaoPodeSerZero()
        {
            dto.QtdAlunos = 0;
            var ret = validations.Validate(dto);
            Assert.False(ret.IsValid);
        }

        [Fact(DisplayName = "Validate => A quantidade de alunos não pode ser negativa")]
        public void Validate_AQuantidadeDeAlunosNaoPodeSerNegativa()
        {
            dto.QtdAlunos = -1;
            var ret = validations.Validate(dto);
            Assert.False(ret.IsValid);
        }
    }
}
