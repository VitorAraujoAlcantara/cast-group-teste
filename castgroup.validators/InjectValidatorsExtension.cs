using System.Globalization;
using System.Runtime.CompilerServices;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("castgroup.tests")]
namespace castgroup.validators
{
    /// <summary>
    /// Extensão para injetar validators
    /// </summary>
    public static class InjectValidatorsExtension
    {
        public static void InjectValidators(this IServiceCollection services)
        {
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");
            services.AddValidatorsFromAssemblyContaining<CursoInsertDtoValidator>(ServiceLifetime.Transient);
            services.AddValidatorsFromAssemblyContaining<CursoUpdateDtoValidator>(ServiceLifetime.Transient);
        }
    }
}
