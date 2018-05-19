using Modulos.IO.Domain.Validations.Clientes;

namespace Modulos.IO.Domain.Clientes.Commands
{
    public class AtualizarClienteCommand : BaseClienteCommand
    {
        public AtualizarClienteCommand(int? id, string razaoSocial, string nomeFantasia, string cnpj)
        {
            Id = id;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
        }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
