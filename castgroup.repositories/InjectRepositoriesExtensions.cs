using System.Runtime.CompilerServices;
using castgroup.repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("castgroup.tests")]
namespace castgroup.repositories
{
    /// <summary>
    /// Extensão para injetar Repositórios
    /// </summary>
    public static class InjectRepositoriesExtensions
    {
        public static void InjectRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICursoRepository, CursoRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddDbContext<CursosContext>(
                options => options.UseNpgsql(configuration.GetConnectionString("Cursos")));

            // Abaixo já aplica as migrações
            using ServiceProvider serviceProvider = services.BuildServiceProvider(validateScopes: true);
            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<CursosContext>();
                db.Database.Migrate();
            }

        }
    }
}
