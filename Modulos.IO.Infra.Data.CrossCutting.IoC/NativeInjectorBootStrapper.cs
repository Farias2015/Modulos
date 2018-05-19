using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Modulos.IO.Domain.Clientes.Commands;
using Modulos.IO.Domain.Clientes.Events;
using Modulos.IO.Domain.Clientes.Repository;
using Modulos.IO.Domain.Core.Notifications;
using Modulos.IO.Domain.Handles;
using Modulos.IO.Domain.Interfaces;
using Modulos.IO.Domain.Usuario.Repository;
using Modulos.IO.Infra.Data.Context;
using Modulos.IO.Infra.Data.Repository;
using Modulos.IO.Infra.Data.UoW;

namespace Modulos.IO.Infra.Data.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegistrarClienteCommand>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarClienteCommand>, ClienteCommandHandler>();

            // Domain - Eventos
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandler>();
            services.AddScoped<INotificationHandler<ClienteAtualizadoEvent>, ClienteEventHandler>();


            // Infra - Data
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ApplicationDbContext>();
        }
    }
}
