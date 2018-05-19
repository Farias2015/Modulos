using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modulos.IO.Domain.Clientes.Commands;
using Modulos.IO.Domain.Clientes.Repository;
using Modulos.IO.Domain.Core.Notifications;
using Modulos.IO.Domain.Interfaces;
using Modulos.IO.Services.Api.ViewModels;
using System;
using System.Collections.Generic;

namespace Modulos.IO.Services.Api.Controllers
{
    public class ClienteController : BaseController
    {
        private readonly IMediatorHandler _mediator;
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(INotificationHandler<DomainNotification> notifications,
                                    IMapper mapper,
                                    IClienteRepository clienteRepository,
                                    IMediatorHandler mediator) : base(notifications, mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        [HttpPost]
        [Authorize(Policy = "PodeGravarClientes")]
        [Route("cadastro-cliente")]
        public IActionResult CadastraCliente([FromBody] ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response(clienteViewModel);
            }

            try
            {
                var clienteCommand = _mapper.Map<RegistrarClienteCommand>(clienteViewModel);
                _mediator.EnviarComando(clienteCommand);
                return Response(clienteViewModel);
            }
            catch (Exception ex)
            {
                NotificarErro("", $"Erro ao cadastar Cliente: {ex.Message}");
                return Response(clienteViewModel);
            }
        }

        [HttpPut]
        [Authorize(Policy = "PodeGravarClientes")]
        [Route("atualizar-cliente")]
        public IActionResult AtualizarCliente([FromBody] ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response(clienteViewModel);
            }

            try
            {
                var clienteCommand = _mapper.Map<AtualizarClienteCommand>(clienteViewModel);
                _mediator.EnviarComando(clienteCommand);
                return Response(clienteViewModel);
            }
            catch (Exception ex)
            {
                NotificarErro("", $"Erro ao atualizar Cliente: {ex.Message}");
                return Response(clienteViewModel);
            }
        }

        [HttpGet]
        [Authorize(Policy = "PodeLerClientes")]
        [Route("obtertodos-cliente")]
        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterTodos());
        }
    }
}
