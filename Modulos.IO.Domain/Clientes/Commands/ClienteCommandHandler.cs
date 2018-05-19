using MediatR;
using Modulos.IO.Domain.Clientes.Events;
using Modulos.IO.Domain.Clientes.Repository;
using Modulos.IO.Domain.Core.Notifications;
using Modulos.IO.Domain.Handles;
using Modulos.IO.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Modulos.IO.Domain.Clientes.Commands
{
    public class ClienteCommandHandler : CommandHandler,
                                     IRequestHandler<RegistrarClienteCommand>,
                                     IRequestHandler<AtualizarClienteCommand>
    {

        private readonly IClienteRepository _clienteRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public ClienteCommandHandler(IUnitOfWork uow,
                                        IMediatorHandler mediator,
                                        IClienteRepository clienteRepository,
                                        INotificationHandler<DomainNotification> notifications) : base(uow, mediator, notifications)
        {
            _clienteRepository = clienteRepository;
            _mediatorHandler = mediator;
        }

        public Task Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotificarValidacoesErro(message);
                return Task.CompletedTask;
            }

            var cliente = new Cliente(null, message.RazaoSocial, message.NomeFantasia, message.Cnpj);

            _clienteRepository.Adicionar(cliente);

            if (Commit())
                _mediatorHandler.PublicarEvento(new ClienteRegistradoEvent());

            return Task.CompletedTask;
        }

        public Task Handle(AtualizarClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotificarValidacoesErro(message);
                return Task.CompletedTask;
            }

            var cliente = new Cliente(message.Id, message.RazaoSocial, message.NomeFantasia, message.Cnpj);

            _clienteRepository.Atualizar(cliente);

            if (Commit())
                _mediatorHandler.PublicarEvento(new ClienteAtualizadoEvent());

            return Task.CompletedTask;
        }
    }
}
