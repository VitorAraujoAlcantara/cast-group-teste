using castgroup.models.Dtos;
using FluentValidation;

namespace castgroup.validators
{
    public class CursoInsertDtoValidator: AbstractValidator<CursoInsertDto>
    {
        public CursoInsertDtoValidator()
        {
            RuleFor(x => x.DataInicio).GreaterThanOrEqualTo(System.DateTime.Now.Date);
            RuleFor(x => x.Descricao).NotEmpty().MaximumLength(100).MinimumLength(5);
            RuleFor(x => x.DataTermino).GreaterThanOrEqualTo(x => x.DataInicio);
            RuleFor(x => x.CategoriaId).NotEmpty();
            RuleFor(x => x.QtdAlunos).GreaterThan(0);
        }
    }
}
