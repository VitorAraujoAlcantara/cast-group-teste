using castgroup.mappers;
using castgroup.repositories;
using castgroup.services;
using castgroup.validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using castgroup.api.Filters;

namespace castgroup.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers( options =>                
                options.Filters.Add( new CustomExceptionFilter()) /// Adiciona filtro para interceptar exceptions tratáveis e retornar badrequest 400
            )
                .AddFluentValidation(); // Adiciona filtro para interceptar e validar entrada de dados 
            services.InjectServices(); // Injeta serviços
            services.InjectRepositories(Configuration); // Injeta repositórios
            services.InjectValidators(); // Injeta validators 
            services.InjectMappers(); // Injeta mapeamentos
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "castgroup.api", Version = "v1" });
            });
            services.AddSingleton(Configuration);            
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CastGroup.api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
