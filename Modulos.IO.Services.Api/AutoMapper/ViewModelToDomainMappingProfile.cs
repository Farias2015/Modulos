using AutoMapper;
using Modulos.IO.Domain.Clientes.Commands;
using Modulos.IO.Domain.Usuario;
using Modulos.IO.Services.Api.ViewModels;

namespace Modulos.IO.Services.Api.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, RegistrarClienteCommand>()
               .ConstructUsing(c => new RegistrarClienteCommand(c.RazaoSocial, c.NomeFantasia, c.CNPJ));

            CreateMap<ClienteViewModel, AtualizarClienteCommand>()
                .ConstructUsing(c => new AtualizarClienteCommand(c.Id, c.RazaoSocial, c.NomeFantasia, c.CNPJ));

            CreateMap<LoginViewModel, Usuario>();
        }
    }
}
