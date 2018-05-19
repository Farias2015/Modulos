using Microsoft.Extensions.DependencyInjection;
using Modulos.IO.Infra.Data.CrossCutting.IoC;

namespace Modulos.IO.Services.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
