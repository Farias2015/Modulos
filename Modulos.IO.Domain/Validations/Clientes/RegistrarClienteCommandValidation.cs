using Modulos.IO.Domain.Clientes.Commands;

namespace Modulos.IO.Domain.Validations.Clientes
{
    public class RegistrarClienteCommandValidation : ClienteValidation<RegistrarClienteCommand>
    {
        public RegistrarClienteCommandValidation()
        {
            ValidarCnpj();
            ValidarRazaoSocial();
        }
    }
}
