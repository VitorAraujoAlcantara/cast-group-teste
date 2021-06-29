using System.Runtime.CompilerServices;
using castgroup.services.interfaces;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("castgroup.tests")]
namespace castgroup.services
{
    /// <summary>
    /// Extensão para injetar Serviços
    /// </summary>
    public static class InjectServiceExtension
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<ICursoService, CursoService>();
            services.AddTransient<ICategoriaService, CategoriaService>();
        }
    }
}
