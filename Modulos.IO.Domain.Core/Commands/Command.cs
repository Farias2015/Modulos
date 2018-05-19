using FluentValidation.Results;
using MediatR;
using Modulos.IO.Domain.Core.Events;
using System;

namespace Modulos.IO.Domain.Core.Commands
{
    public abstract class Command : Message, IRequest
    {
        public ValidationResult ValidationResult { get; set; }
        public DateTime Timestamp { get; private set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
