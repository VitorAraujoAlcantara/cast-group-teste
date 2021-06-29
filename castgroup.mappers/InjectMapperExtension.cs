using Microsoft.Extensions.DependencyInjection;

namespace castgroup.mappers
{
    /// <summary>
    /// Extensão para injetar mappers
    /// </summary>
    public static class InjectMapperExtension
    {
        public static void InjectMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperProfile));
        }
    }
}
