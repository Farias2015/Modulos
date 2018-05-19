using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Modulos.IO.Domain.Clientes.Events
{
    public class ClienteEventHandler : INotificationHandler<ClienteRegistradoEvent>,
                                       INotificationHandler<ClienteAtualizadoEvent>
    {
        public Task Handle(ClienteRegistradoEvent notification, CancellationToken cancellationToken)
        {
            //fazer algo
            return Task.CompletedTask;
        }

        public Task Handle(ClienteAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            //fazer algo
            return Task.CompletedTask;
        }
    }
}
