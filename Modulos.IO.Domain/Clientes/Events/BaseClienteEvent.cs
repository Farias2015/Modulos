using Modulos.IO.Domain.Core.Events;

namespace Modulos.IO.Domain.Clientes.Events
{
    public abstract class BaseClienteEvent : Event
    {
        public int? Id { get; protected set; }
        public string RazaoSocial { get; protected set; }
        public string NomeFantasia { get; protected set; }
        public string Cnpj { get; protected set; }
    }
}
