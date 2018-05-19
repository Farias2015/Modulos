using Modulos.IO.Domain.Validations.Clientes;

namespace Modulos.IO.Domain.Clientes.Commands
{
    public class RegistrarClienteCommand : BaseClienteCommand
    {
        public RegistrarClienteCommand(string razaoSocial, string nomeFantasia, string cnpj)
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegistrarClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
