﻿using MediatR;
using Modulos.IO.Domain.Core.Commands;
using Modulos.IO.Domain.Core.Events;
using Modulos.IO.Domain.Interfaces;
using System.Threading.Tasks;

namespace Modulos.IO.Domain.Handles
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task EnviarComando<T>(T comando) where T : Command
        {
            await _mediator.Send(comando);
        }

        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            /* if (!evento.MessageType.Equals("DomainNotification"))
                 _eventStore?.SalvarEvento(evento);*/

            await _mediator.Publish(evento);
        }
    }
}
