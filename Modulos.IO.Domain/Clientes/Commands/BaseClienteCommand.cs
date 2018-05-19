using Modulos.IO.Domain.Core.Commands;

namespace Modulos.IO.Domain.Clientes.Commands
{
    public abstract class BaseClienteCommand : Command
    {
        public int? Id { get; protected set; }
        public string RazaoSocial { get; protected set; }
        public string NomeFantasia { get; protected set; }
        public string Cnpj { get; protected set; }
    }
}
