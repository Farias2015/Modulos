using Modulos.IO.Domain.Clientes.Commands;

namespace Modulos.IO.Domain.Validations.Clientes
{
    public class AtualizarClienteCommandValidation : ClienteValidation<AtualizarClienteCommand>
    {
        public AtualizarClienteCommandValidation()
        {
            ValidarCnpj();
            ValidarRazaoSocial();
        }
    }
}
