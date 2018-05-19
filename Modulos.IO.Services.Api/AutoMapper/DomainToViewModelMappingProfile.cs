using AutoMapper;
using Modulos.IO.Domain.Clientes;
using Modulos.IO.Domain.Usuario;
using Modulos.IO.Services.Api.ViewModels;

namespace Modulos.IO.Services.Api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Usuario, LoginViewModel>();
        }
    }
}
