using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modulos.IO.Infra.Data.Context;
using Modulos.IO.Services.Api.Configurations;
using MediatR;

namespace Modulos.IO.Services.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(env.ContentRootPath)
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                 .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                 .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Contexto do EF para o Identity
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Configurações de Autenticação, Autorização e JWT.
            services.AddMvcSecurity(Configuration);

            // Options para configurações customizadas
            services.AddOptions();

            // MVC com restrição de XML e adição de filtro de ações.
            services.AddMvc(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
            });

            // Versionamento do WebApi
            services.AddApiVersioning("api/v{version}");

            // AutoMapper
            services.AddAutoMapper();

            // Configurações do Swagger
            services.AddSwaggerConfig();


            // MediatR
            services.AddMediatR(typeof(Startup));

            // Registrar todos os DI
            services.AddDIConfiguration();
        }

        public void Configure(IApplicationBuilder app,
                              IHostingEnvironment env)
        {

            #region Configurações MVC

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();

            #endregion

            #region Swagger

            if (env.IsProduction())
            {
                // Se não tiver um token válido no browser não funciona.
                // Descomente para ativar a segurança.
                // app.UseSwaggerAuthorized();
            }

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.DocExpansion("None");
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Eventos.IO API v1.0");
            });

            #endregion
        }
    }
}
