using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Modulos.IO.Services.Api.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Corp.IO.Api",
                    Description = "Api .Net Portal Corp",
                    TermsOfService = "Nenhum",
                    Contact = new Contact { Name = "Adjair Farias", Email = "adjair.farias@oi.net.br", Url = "https://portalb2b.oi.net.br" },
                    License = new License { Name = "MIT", Url = "https://portalb2b.oi.net.br" }
                });

                s.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            });

            services.ConfigureSwaggerGen(opt =>
            {
                opt.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            });
        }
    }
}
